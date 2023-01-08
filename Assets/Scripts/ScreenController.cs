using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _playButton.onClick.AddListener(LoadGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}