using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
	public GameObject mainSprite;
	public GameObject outlineSprite;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) // replace this with your actual condition
		//if (Input.GetKeyDown(KeyCode.E)) // replace this with your actual condition
		{
			bool isActive = mainSprite.activeSelf;
			mainSprite.SetActive(!isActive);
			outlineSprite.SetActive(isActive);
		}
	}
}
