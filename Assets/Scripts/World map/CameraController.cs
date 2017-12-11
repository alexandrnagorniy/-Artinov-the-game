using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float x, y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void NextScene(Vector2 tmp)
	{
		x = tmp.x;
		y = tmp.y;
		transform.position = new Vector3 (x, y, -10);
	}
}
