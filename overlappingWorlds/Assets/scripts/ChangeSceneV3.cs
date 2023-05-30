using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneV3 : MonoBehaviour
{
    public float delay = 5.0f;
    private bool canSkip = false;

    private void Start()
    {
        StartCoroutine(DelayedSceneLoad());
    }

    private IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(delay);
        if (canSkip)
        {
            yield break;
        }
        
        LoadNextScene();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            canSkip = true;
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Level1");
    }
}