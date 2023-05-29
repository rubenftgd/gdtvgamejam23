using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuInstance == null)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        pauseMenuInstance = Instantiate(pauseMenuPrefab);
        SceneManager.LoadScene("pauseMenu", LoadSceneMode.Additive);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume normal time scale
        SceneManager.UnloadSceneAsync("pauseMenu"); // Unload the pause menu scene
        Destroy(pauseMenuInstance);
        pauseMenuInstance = null;
    }
}