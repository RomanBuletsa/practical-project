using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Application;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Land land;
        [SerializeField] private Button menuButton;
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private Transform parentSpawn;
        [SerializeField] private Transform[] positionSpawn;
        [SerializeField] private  TextMeshProUGUI countText;
        [SerializeField] private  TextMeshProUGUI targetText;

        

        private Round currentRound;
        private int roundNumber;
        private int countFallingObjects=0;
        private Queue<TypesPrefabs> objectsQueue = new Queue<TypesPrefabs>();
        private Dictionary<TypesPrefabs,List<GameObject>> bjectsDictionary = new Dictionary<TypesPrefabs, List<GameObject>>();
        private Random rand;
        private int currentCount;
        private Coroutine coroutine;
        
        private void Awake()
        {
            ApplicationManager.Instance.GameManager = this;
            
            menuButton.onClick.AddListener(OnMenuButtonClicked);
            player.Caught += Caught; // TODO: you're not unsubscribing
            land.Delete += Delete; // TODO: you're not unsubscribing
        }

        private void Start()
        {
            StartGame();
        }
        
        private void StartGame()
        {
            roundNumber = 0;
            UpdateCountText();
            StartRound();
        }

        private void StartRound()
        {
            currentRound = gameConfig.Rounds.ElementAt(roundNumber);
            UpdateTargetText();
            bjectsDictionary.Clear();
            foreach (TypesPrefabs type in currentRound.AllObject)
            {
                foreach (FallingObject obj in gameConfig.FallingObjects)
                {
                    if (type.Equals(obj.Type))
                    {
                        bjectsDictionary.Add(type,obj.Prefabs);
                    }
                }
            }

            coroutine = null;
            coroutine = StartCoroutine(SpawnCoroutine());
            
        }

        private IEnumerator SpawnCoroutine()
        {
            float timeElapsed = 0f;
            while (countFallingObjects<=currentRound.CountFallingObjPerPound)
            {
                if (timeElapsed >= currentRound.RoundSpawnRate)
                {
                    timeElapsed = 0f;
                    rand = new Random();
                    int pos1 = rand.Next(0, positionSpawn.Length);
                    int pos2 = rand.Next(0, currentRound.AllObject.Count);
                    TypesPrefabs typ = currentRound.AllObject[pos2];
                    objectsQueue.Enqueue(typ);
                    int pos3 = rand.Next(0, bjectsDictionary[typ].Count);
                    var newObj = Instantiate(bjectsDictionary[typ][pos3],parentSpawn);
                    newObj.transform.position = positionSpawn[pos1].position;
                    
                    
                    countFallingObjects++;
                }
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            countFallingObjects = 0;
            NextRound();

        }

        private void Delete()
        {
            if(objectsQueue.Count>0)objectsQueue.Dequeue();
        }

        private void Caught()
        {
            if(objectsQueue.Count>0)
            if (objectsQueue.Dequeue().Equals(currentRound.ObjectsToCatch))
                currentCount += currentRound.TrueAnswerPrice;
            else currentCount += currentRound.FalseAswerPrice;
            UpdateCountText();
        }
        
        private void UpdateCountText()
        {
            countText.text = $"{currentCount}";
        }
        
        private void UpdateTargetText()
        {
            targetText.text = currentRound.ObjectsToCatch.ToString();
        }


        private void NextRound()
        {
            StopCoroutine(coroutine);
            roundNumber++;
            if (roundNumber < gameConfig.Rounds.Count)
            {
                StartRound();
            }
        }

        public Round GetCurrentRound() => currentRound;

        private void OnMenuButtonClicked() => SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());

        private void OnDestroy()
        {
            ApplicationManager.Instance.GameManager = null;
        }
    }
}
