using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelCoin : MonoBehaviour {

	public enum bonusType
	{
		addTime,
		minusTime,
		speedSpawn,
		coin
	};
	public bonusType type;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			HotelPlayerController ctrl = coll.GetComponent<HotelPlayerController> ();
			if (type == bonusType.coin)
				ctrl.Coin ();
			else if (type == bonusType.addTime)
				ctrl.AddTime ();
			else if (type == bonusType.minusTime)
				ctrl.MinusTime ();
			else if (type == bonusType.speedSpawn)
				ctrl.Bonus ();
			
			Destroy (gameObject);
		}
		else if(coll.gameObject.tag != "money")
		{
			GetComponent<Rigidbody2D> ().isKinematic = true;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Destroy (gameObject, 0.5f);
		}
	}
}
