﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPlayerController : MonoBehaviour {
	public float minX, maxX;
	public float speed;
	// Use this for initialization
	void Start () 
	{
		
	}

	public void GetPositions(float min, float max)
	{
		minX = min;
		maxX = max;
	}

	// Update is called once per frame
	void Update () 
	{
		CameraMove ();
		Move ();

	}

	void CameraMove()
	{
		Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y + 3, -10);
	}

	void Move()
	{
		//if (transform.position.x < maxX && transform.position.x > minX)
			transform.Translate (Vector2.right * speed * Input.GetAxis ("Horizontal"));

		if (transform.position.x > maxX)
			transform.position = new Vector2 (maxX, transform.position.y);

		if (transform.position.x < minX)
			transform.position = new Vector2 (minX, transform.position.y);
	}
}
