using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Player>().GetTube();
            gameObject.SetActive(false);
            
        }
    }
}
