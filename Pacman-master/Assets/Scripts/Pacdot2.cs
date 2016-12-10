using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pacdot2 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "pacman")
		{
			GameManager.score += 10;
		    GameObject[] pacdots = GameObject.FindGameObjectsWithTag("pacdot");
            Destroy(gameObject);

		    if (pacdots.Length == 1)
		    {
				SceneManager.LoadScene("game 3");
		    }
		}
	}
}
