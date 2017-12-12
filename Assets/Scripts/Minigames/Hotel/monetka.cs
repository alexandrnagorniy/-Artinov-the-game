using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monetka : MonoBehaviour
{
	public static bool cashMoney = false;
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "telega")
		{ 
			cashMoney = true;
			GameController.CountMoney ++;
			Destroy (gameObject);
		}
	}
}