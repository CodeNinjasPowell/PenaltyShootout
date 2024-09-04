using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
	[Header("Values")]
	public float speed = 50f;

	[Header("Components")]
	public Transform ballPos;
	public Rigidbody rb;
	public GameObject child;
	public GameObject asset;
	
	[Header("Rot Y Values")]
	public float maxRotY = 25f;
	public float minRotY = -25f;
	public float rotSpeedY;
	private float currRotY;

	[Header("Rot Z Values")]
	public float maxRotZ = 2.13f;
	public float minRotZ = -16.7f;
	public float rotSpeedZ;
	private float currRotZ;

	//[HideInInspector]
	public bool isPaused;

	private bool horizontalDone;
	private bool ballShot;

	private void Start()
	{
		currRotY = rotSpeedY;
		currRotZ = 0f;
		horizontalDone = false;
		ballShot = false;
		isPaused = false;
	}

	void Update()
    {
		Vector3 currRot = ballPos.eulerAngles;

		//Debug.Log(ballPos.eulerAngles.y);

		if (!horizontalDone)
		{
			if (currRot.y <= 360 + minRotY && currRot.y > 180)
			{
				currRotY = rotSpeedY;
				//Debug.Log("Go right");
				//Debug.Log(currRotY);
			}

			if (currRot.y >= maxRotY && currRot.y < 180)
			{
				currRotY = -rotSpeedY;
				//Debug.Log("Go left");
				//Debug.Log(currRotY);
			}

			if ((Input.GetButtonDown("Shoot") || Input.GetMouseButtonDown(0)) && !isPaused)
			{
				currRotY = 0f;
				currRotZ = rotSpeedZ;
				horizontalDone = true;
			}
		} 
		else if (!ballShot)
		{
			if (currRot.z <= 360 + minRotZ && currRot.z > 180)
			{
				currRotZ = rotSpeedZ;
				//Debug.Log("Go down");
				//Debug.Log(currRotZ);
			}

			if (currRot.z >= maxRotZ && currRot.z < 180)
			{
				currRotZ = -rotSpeedZ;
				//Debug.Log("Go up");
				//Debug.Log(currRotZ);
				//Debug.Log("space");
			}

			if ((Input.GetButtonDown("Shoot") || Input.GetMouseButtonDown(0)) && !isPaused)
			{
				//Debug.Log("Shoot");
				currRotZ = 0f;
				ballShot = true;

				rb.isKinematic = false;
				Vector3 force = child.transform.position - transform.position;
				force = force.normalized;
				force = force * speed;
				rb.gameObject.transform.rotation = gameObject.transform.rotation;
				rb.AddForce(force, ForceMode.Impulse);
				//Debug.Log(force);

				Destroy(child);
				Destroy(asset);
			}
		}

		transform.Rotate(new Vector3(0, currRotY * Time.deltaTime, currRotZ * Time.deltaTime));

		if(isPaused == true)
		{
			rotSpeedY = 0;
			rotSpeedZ = 0;
		} else if(isPaused == false)
		{
			rotSpeedY = 75;
			rotSpeedZ = 50;
		}
	}

}