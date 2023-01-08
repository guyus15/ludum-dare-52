using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
