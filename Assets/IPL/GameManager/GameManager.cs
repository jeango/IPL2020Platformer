using UnityEngine;
using UnityEngine.SceneManagement;

namespace IPL
{
    public class GameManager : SingletonMb<GameManager>
    {
        [SerializeField] private ScoreManager scoreManager;
        public ScoreManager ScoreManager => scoreManager;

        protected override void Initialize()
        {
        }
        protected override void Cleanup()
        {
        }

        public void NewGame()
        {
            LoadScene("Level1");
            ScoreManager.SetScore(0);
        }

        public void GameOver()
        {
            LoadScene("GameOver");
        }

        public void MainMenu()
        {
            LoadScene("MainMenu");
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            var asyncload = SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}