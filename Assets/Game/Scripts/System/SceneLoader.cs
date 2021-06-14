using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam.System
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        protected override void Init()
        {
        }
        public void LoadScene(int index)
        {
            // SceneManager.LoadScene(index);
            SceneFader.GetInstance().LoadLevel(index);
        }

        public void LoadScene(string name)
        {
            // SceneManager.LoadScene(name);
            SceneFader.GetInstance().LoadLevel(name);
        }

        public void LoadNextScene()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentIndex >= SceneManager.sceneCountInBuildSettings)
            {
                LoadStartMenu();
            }
            else
            {
                // SceneManager.LoadScene(currentIndex + 1);
                SceneFader.GetInstance().LoadLevel(currentIndex + 1);
            }

        }

        public void LoadStartMenu()
        {
            SceneFader.GetInstance().LoadLevel("StartMenu");
        }

        public void LoadGameOverMenu()
        {
            // SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            SceneFader.GetInstance().LoadLevel("GameOver");
        }

        public void Quit(){
            Application.Quit();
        }

        // private string GetSceneNameByIndex(int index){
        //     return SceneManager.GetSceneByBuildIndex(index).name;
        // }

    }
}