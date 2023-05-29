using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume normal time scale
        SceneManager.UnloadSceneAsync("pauseMenu"); // Unload the pause menu scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}