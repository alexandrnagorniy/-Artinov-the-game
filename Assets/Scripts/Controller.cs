using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	[SerializeField]
	protected float minX, maxX;
	[SerializeField]
	protected float speed;

	public void GetPositions(float min, float max)
	{
		minX = min;
		maxX = max;
	}

	protected void CameraMove()
	{
		Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y + 3, -10);
	}

	protected void Move(float x)
	{
		transform.Translate (Vector2.right * speed * x);

		if (transform.position.x > maxX)
			transform.position = new Vector2 (maxX, transform.position.y);

		if (transform.position.x < minX)
			transform.position = new Vector2 (minX, transform.position.y);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
