using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class switchLevels : MonoBehaviour
{
    
    public GameObject level1;
    public GameObject level2;
    

    public bool canSwitch;


    public void switchWorlds(InputAction.CallbackContext context)
    {
        if(context.performed && level1.activeSelf && canSwitch)
        {
            level1.SetActive(false);
            level2.SetActive(true);
        }
        else if(context.performed && level2.activeSelf && canSwitch)
        {
            level1.SetActive(true);
            level2.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "SwitchSpot") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
          canSwitch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "SwitchSpot") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
          canSwitch = false;
        }
    }
}
