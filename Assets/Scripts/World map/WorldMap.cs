using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WorldMap : MonoBehaviour {
	public GameObject map;
	public int energy = 100;
	public Image energyImage;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		energyImage.fillAmount = (float)energy / 100;
		if (energy < 0)
			energy = 0;
		else if (energy > 100)
			energy = 100;
	}

	public void Map()
	{
		map.SetActive (!map.activeSelf);
	}

	public void GetEnergy(int costEnergy)
	{
		energy -= costEnergy;
		PlayerPrefs.SetFloat ("Energy", energy);
	}

	public void MoveToLevel(string levelName)
	{
		SceneManager.LoadScene (levelName);
	}
}
