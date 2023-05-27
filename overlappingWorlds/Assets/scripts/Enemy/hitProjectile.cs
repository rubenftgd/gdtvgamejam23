using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitProjectile : MonoBehaviour
{   public bool isFrozen;
    public float startFrozenTime;
    public float frozenTime;
    public GhostPatrol ghostmovement; 


    public void FixedUpdate()
    {
        
        if(isFrozen)
        {
            ghostmovement.enabled = false;
            frozenTime -= Time.deltaTime;
            
            
        }
        if (frozenTime <= 0f)
        {
            frozenTime = startFrozenTime;
            ghostmovement.enabled = true;
            isFrozen = false;
        }
        
    }

     private void OnTriggerEnter2D(Collider2D other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "CaptureProjectile") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            Destroy(gameObject);
        }
        else if ( other.gameObject.tag == "Freeze Projectile")
        {
            isFrozen = true;
        }
    }
}
