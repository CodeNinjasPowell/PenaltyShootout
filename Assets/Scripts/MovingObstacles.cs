using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
	public float maxHeight;
	public float minHeight;
	public float time;
	public bool goingUp;

	private float speed;
	private float currSpeed;

	void Start()
	{
		float distance = maxHeight - minHeight;
		speed = distance / time;
		currSpeed = goingUp ? speed : -speed;
		transform.position = new Vector3(
			transform.position.x, 
			goingUp ? minHeight : maxHeight, 
			transform.position.z
		);
	}

	void Update()
	{
		
		transform.Translate(new Vector3(0, currSpeed * Time.deltaTime, 0));
		if(transform.position.y < minHeight)
		{
			currSpeed = speed;
			// transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
		}
		if(transform.position.y > maxHeight)
		{
			currSpeed = -speed;
			// transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
		}
	}
}
