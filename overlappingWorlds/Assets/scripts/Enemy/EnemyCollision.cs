using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerController player = collision.GetComponent<PlayerController>();
			if (player != null)
			{
				player.LoseLife();
			}
		}
	}
}
