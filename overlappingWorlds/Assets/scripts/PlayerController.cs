using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
	public int maxLives = 1;
	private int currentLives;

	private void Start()
	{
		currentLives = maxLives;
	}

	public void LoseLife()
	{
		currentLives--;

		if (currentLives <= 0)
		{
			// Player is out of lives, handle game over here
			Debug.Log("Game Over");
			maxLives = 1;
			SceneManager.LoadScene("Level1");
		}
		else
		{
			// Player still has lives, handle life loss here
			Debug.Log("Life Lost");

			// Reset player position or perform other necessary actions
			// Example: transform.position = startPosition;
		}
	}
}
