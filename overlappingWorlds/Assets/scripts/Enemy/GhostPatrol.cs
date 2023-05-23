using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour
{
	public Transform[] waypoints;
	public Sprite idleSprite;
	public Sprite aggressiveSprite;
	public float speed = 2.0f;
	public float chaseDistance = 5.0f;  // The distance at which the monster will start chasing the player
	private int currentWaypoint = 0;
	private Transform player;
	private SpriteRenderer spriteRenderer;

	void Start()
	{
		// Find the player in the scene
		player = GameObject.FindWithTag("Player").transform;

		// Get the SpriteRenderer component
		spriteRenderer = GetComponent<SpriteRenderer>();

		// Set the initial sprite
		spriteRenderer.sprite = idleSprite;
	}
	

	void Update()
	{
		// Check the distance to the player
		if (Vector2.Distance(transform.position, player.position) < chaseDistance)
		{
			// If the player is close, chase the player and change the sprite
			FollowPlayer();
			spriteRenderer.sprite = aggressiveSprite;
		}
		else
		{
			// If the player is far, patrol and use the idle sprite
			Patrol();
			spriteRenderer.sprite = idleSprite;
		}
	}

	void Patrol()
	{
		// Move towards the current waypoint
		Vector2 targetPosition = waypoints[currentWaypoint].position;
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

		// Flip sprite depending on direction
		if (targetPosition.x > transform.position.x)
		{
			// Going right
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (targetPosition.x < transform.position.x)
		{
			// Going left
			transform.localScale = new Vector3(1, 1, 1);
		}

		// If the monster is at the current waypoint, switch to the next one
		if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
		{
			currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
		}
	}

	void FollowPlayer()
	{
		// Move towards the player
		Vector2 targetPosition = player.position;
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

		// Flip sprite depending on direction
		if (targetPosition.x > transform.position.x)
		{
			// Going right
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (targetPosition.x < transform.position.x)
		{
			// Going left
			transform.localScale = new Vector3(1, 1, 1);
		}
	}

}