using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour {
	public GameObject player;
	public Scrollbar slider;
	public float minX;
	public float maxX;
	private float distance;
	private bool inLocation;
	// Use this for initialization
	void Start () {
		minX = transform.position.x - 29.8f;
		maxX = transform.position.x + 29.8f;
		distance = player.transform.position.x - minX;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//Debug.Log (gameObject.name + " | " + Vector2.Distance (transform.position, player.transform.position));
		inLocation = Vector2.Distance (transform.position, player.transform.position) <= 31f && ((player.transform.position.x - minX) / 60) <= 1;
		slider.gameObject.SetActive (inLocation);
		slider.value = (player.transform.position.x - minX) / 60;
	}
}
