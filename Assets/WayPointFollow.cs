using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{
	public GameObject[] WayPoints;
	int currentWP = 0;

	public float speed = 5.0f;
	public float accuracy = 1.0f;
	public float rotspeed = 4.4f;

	private void Start()
	{
		
		WayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
	}

	private void LateUpdate()
	{
		if (WayPoints.Length == 0) return;

		Vector3 lookAtGoal = new Vector3(WayPoints[currentWP].transform.position.x, this.transform.position.y, WayPoints[currentWP].transform.position.z);
		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotspeed);

		if (direction.magnitude < accuracy) 
		{
			currentWP++; 
			if (currentWP >= WayPoints.Length)
			{
				currentWP = 0;
			}
		}

		this.transform.Translate(0, 0, speed * Time.deltaTime);
		
	}
}
