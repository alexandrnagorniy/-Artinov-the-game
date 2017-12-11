using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneButton : MonoBehaviour {
	public enum buttonType
	{
		location,
		scene
	};
	public buttonType type;
	public GameObject next;
	public string scene;
	private Effector effector;
	private bool isStay;
	// Use this for initialization
	void Start () 
	{
		effector = GameObject.FindGameObjectWithTag ("Effector").GetComponent<Effector> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		if (isStay)
		{
			if(type == buttonType.location)
				effector.GoToNextLocation (next);
			if(type == buttonType.scene)
				effector.GoToNextScene (scene);
			
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
			isStay = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
			isStay = false;
	}
}
