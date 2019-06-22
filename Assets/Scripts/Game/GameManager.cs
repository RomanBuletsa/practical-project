using System.Collections.Generic;
using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button menuButton;
        [SerializeField] private GameConfig gameConfig;

        private Round currentRound;
    
        private void Awake()
        {
            ApplicationManager.Instance.GameManager = this;
            
            menuButton.onClick.AddListener(OnMenuButtonClicked);
        }

        public Round GetCurrentRound() => currentRound;

        private void OnMenuButtonClicked() => SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());

        private void OnDestroy()
        {
            ApplicationManager.Instance.GameManager = null;
        }
    }
}
