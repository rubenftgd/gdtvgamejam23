using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement player = other.GetComponent<playerMovement>();
            if (player != null && player.HasKey())
            {
                player.OpenDoor();
                Debug.Log("Door unlocked and opened!");
                Destroy(gameObject);
            }
        }
    }
}
