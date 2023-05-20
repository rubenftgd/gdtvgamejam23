using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class switchLevels : MonoBehaviour
{
    
    public GameObject level1;
    public GameObject level2;
    // Update is called once per frame
    void Update()
    {
    
    }

    public void switchWorlds(InputAction.CallbackContext context)
    {
        if(context.performed && level1.activeSelf)
        {
            level1.SetActive(false);
            level2.SetActive(true);
        }
        else if(context.performed && level2.activeSelf)
        {
            level1.SetActive(true);
            level2.SetActive(false);
        }
    }
}
