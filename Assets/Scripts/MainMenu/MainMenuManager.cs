using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button gameButton;
    
    
        private void Awake()
        {
            ApplicationManager.Instance.MainMenuManager = this;
            
            gameButton.onClick.AddListener(OnGameButtonClicked);

        }
    
        private void OnGameButtonClicked() => SceneManager.LoadScene(ApplicationScenes.Game.ToString());
    
        private void OnDestroy()
        {
            ApplicationManager.Instance.MainMenuManager = null;
        }
    }
}
