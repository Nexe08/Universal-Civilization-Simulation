using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void OnPlayButtonPressed() {
        SceneManager.LoadScene("GameplayState");
    }

    public void QuitApplication() {
        Application.Quit();
    }
}
