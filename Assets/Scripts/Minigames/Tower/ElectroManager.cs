using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroManager : MonoBehaviour {
	public GameObject backStage;
	private int part;
	public int need;

	public bool reset;
	public GameObject unlockObj;
	public GameObject unlockObj1;
    private int button;
	// Use this for initialization
	void Start () {
		//effector = GameObject.FindGameObjectWithTag("Effector").GetComponent<DarkEffect>();
	}

    public void Rotate() { button++; }
	
	// Update is called once per frame
	void LateUpdate () 
	{
        if (reset && button == 5)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.rotation = Quaternion.identity;
            }
            part = 0;
            button = 0;
            reset = false;
        }
    }

	public void Part()
	{
       
		part++;
		if (need == part) {
			
			unlockObj.SetActive (!unlockObj.activeSelf);
			unlockObj1.SetActive (!unlockObj1.activeSelf);
			this.enabled = false;
		}
	}
}
