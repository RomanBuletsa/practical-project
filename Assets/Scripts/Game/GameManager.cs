using System.Collections;
using System.Collections.Generic;
using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameUIManager gameUIManager;
        [SerializeField] private Player player;
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private Transform parentSpawn;
        [SerializeField] private Transform[] positionSpawn;

        

        private Round currentRound;
        private int roundNumber;
        private int countFallingObjects = 0;
        private Dictionary<TypesPrefabs,List<GameObject>> objectsDictionary = new Dictionary<TypesPrefabs, List<GameObject>>();
        private Random rand; 
        private int score;
        private Coroutine coroutine;
        
        private void Awake()
        {
            ApplicationManager.Instance.GameManager = this;
            
            player.Caught += Caught; 

            gameUIManager.BackButtonClicked += OnBackButtonClicked;
            gameUIManager.PauseButtonClicked += Pause;
            gameUIManager.ResumeButtonClicked += Unpause;
        }

        private void Start()
        {
            StartGame();
        }

        private void OnBackButtonClicked() => SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());

        private void Pause() => Time.timeScale = 0;

        private void Unpause() => Time.timeScale = 1;

        private void StartGame()
        {
            roundNumber = 0;
            gameUIManager.UpdateScoreText(score);
            StartRound();
        }

        private void StartRound()
        {
            currentRound = gameConfig.Rounds[roundNumber];
            var objectTypeName = ApplicationConstants.TypesPrefabsNames[currentRound.ObjectsToCatch];
            gameUIManager.UpdateTargetObjectText(objectTypeName);
            objectsDictionary.Clear();
            foreach (TypesPrefabs type in currentRound.AllObject)
            {
                foreach (FallingObject obj in gameConfig.FallingObjects)
                {
                    if (type.Equals(obj.Type))
                    {
                        objectsDictionary.Add(type,obj.Prefabs);
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
                    int spawnPositionIndex = rand.Next(0, positionSpawn.Length);
                    int objTypeIndex = rand.Next(0, currentRound.AllObject.Count);
                    TypesPrefabs type = currentRound.AllObject[objTypeIndex];

                    int prefIndex = rand.Next(0, objectsDictionary[type].Count);
                    Instantiate(objectsDictionary[type][prefIndex],
                        positionSpawn[spawnPositionIndex].position, Quaternion.identity, parentSpawn);
                    countFallingObjects++;
                }
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            countFallingObjects = 0;
            NextRound();

        }


        private void Caught(TypesPrefabs type)
        {
            if (type.Equals(currentRound.ObjectsToCatch)) score += currentRound.TrueAnswerPrice;
                else score += currentRound.FalseAswerPrice;
            gameUIManager.UpdateScoreText(score);
        }


        private void NextRound()
        {
            StopCoroutine(coroutine);
            roundNumber++;
            if (roundNumber.Equals(gameConfig.Rounds.Count)) roundNumber = 0;
            StartRound();
        }

        public Round GetCurrentRound() => currentRound;

        private void OnDestroy()
        {
            ApplicationManager.Instance.GameManager = null;
         
            Unpause();
            
            player.Caught -= Caught;

            gameUIManager.BackButtonClicked -= OnBackButtonClicked;
            gameUIManager.PauseButtonClicked -= Pause;
            gameUIManager.ResumeButtonClicked -= Unpause;
        }
    }
}
