using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoworkingPlayerController : Controller {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move (Input.GetAxis ("Horizontal"));
		CameraMove ();
	}
}
