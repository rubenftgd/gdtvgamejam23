using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Door") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
          Debug.Log("You Win");
          SceneManager.LoadScene("theend");
        }
    }
}
