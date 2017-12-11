using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money_rain : MonoBehaviour 
{

	public GameObject moneta;
	private float timer;


	void Start ()
	{
		timer = Time.realtimeSinceStartup;
	}


	void Update ()
	{
		if (GameController.pauseGame == false)
	     {
			if ((Time.realtimeSinceStartup - timer) >= 0.9f)  //генерация монет
			{ 
		    	Vector3 newPosition = new Vector3 (-4.74f + Random.Range (1, 10), 2.34f, 0);
		    	GameObject.Instantiate (moneta, newPosition, Quaternion.identity);
			    timer = Time.realtimeSinceStartup;
		
		     }
	     }
					
	}
}
