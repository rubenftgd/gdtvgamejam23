using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isPickedUp = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement player = other.GetComponent<playerMovement>();
            if (player != null)
            {
                player.PickupKey();
                isPickedUp = true;
                gameObject.SetActive(false);
            }
        }
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}
