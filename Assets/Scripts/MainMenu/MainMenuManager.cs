using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;
    
    
        private void Awake()
        {
            ApplicationManager.Instance.MainMenuManager = this;
            
            playButton.onClick.AddListener(OnPlayButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);

        }

        private void OnPlayButtonClicked() => SceneManager.LoadScene(ApplicationScenes.Game.ToString());

        private void OnSettingsButtonClicked() {}

        private void OnExitButtonClicked() => UnityEngine.Application.Quit();

        private void OnDestroy()
        {
            ApplicationManager.Instance.MainMenuManager = null;
        }
    }
}
