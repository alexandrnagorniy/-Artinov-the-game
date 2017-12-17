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
	public int energyCost;
	private Effector effector;
	private bool isStay;
	private WorldMap wMap;
	// Use this for initialization
	void Start () 
	{
		effector = GameObject.FindGameObjectWithTag ("Effector").GetComponent<Effector> ();	
		wMap = Camera.main.GetComponent<WorldMap> ();
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
			if (type == buttonType.scene) {
				if (wMap.energy >= energyCost) {
					effector.GoToNextScene (scene);
					wMap.GetEnergy (energyCost);
				}	
			}
			
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
