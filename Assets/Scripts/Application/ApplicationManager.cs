using Game;
using MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application
{
    public class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }
        
        public MainMenuManager MainMenuManager { get; set; }
        public GameManager GameManager { get; set; }
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        
        private void Start()
        {
            SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());
        }
    }
}
