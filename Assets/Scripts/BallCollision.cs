using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
	//Ball Pos: 22.77, -0.96, 4.1
	public int nextLevelNum;
	public SceneLoader sl;
	public GameObject gameoverScreen;
	public AudioManager am;

	void Start()
	{
		gameoverScreen.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("net"))
		{
			Destroy(gameObject);
			PlayerPrefs.SetInt("Level", nextLevelNum);
			sl.LoadScene(nextLevelNum);
		}

		if(collision.gameObject.CompareTag("obstacle"))
		{
			Destroy(gameObject);
			// SceneManager.LoadScene("GameOver");
			gameoverScreen.SetActive(true);
			am.StopSound("crowd");
			am.PlaySound("boo");
		}
	}
}
