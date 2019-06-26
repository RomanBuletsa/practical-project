using Application;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button infoButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button backButton;
        [SerializeField] private GameObject rulesPannel;
        [SerializeField] private TextMeshProUGUI bestScoreText;
    
    
        private void Awake()
        {
            ApplicationManager.Instance.MainMenuManager = this;
            
            playButton.onClick.AddListener(OnPlayButtonClicked);
            infoButton.onClick.AddListener(OnInfoButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
            backButton.onClick.AddListener(OnBackButtonClicked);
            
            rulesPannel.SetActive(false);
            UpdateBestScoreText(PlayerPrefs.GetInt("Best",0));
        }

        private void OnPlayButtonClicked() => SceneManager.LoadScene(ApplicationScenes.Game.ToString());

        private void OnInfoButtonClicked() => rulesPannel.SetActive(true);

        private void OnExitButtonClicked() => UnityEngine.Application.Quit();

        private void OnBackButtonClicked() => rulesPannel.SetActive(false);
        
        public void UpdateBestScoreText(int bestScore) => bestScoreText.text = $"{bestScore}";

        private void OnDestroy()
        {
            ApplicationManager.Instance.MainMenuManager = null;
        }
    }
}
