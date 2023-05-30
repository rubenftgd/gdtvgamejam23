using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneV4 : MonoBehaviour
{
    public float delay = 5.0f;

    private void Start()
    {
        StartCoroutine(DelayedSceneLoad());
    }

    private IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(delay);  
        LoadNextScene();
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene("mainMenu");
    }
}