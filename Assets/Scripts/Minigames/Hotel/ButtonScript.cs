using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour 
{
	public bool isButtonDown = false;  //клавиша мышки-тачпада нажата
	public bool isButtonUp = false;  //клавиша мышки-тачпада отжата
	Renderer renderer;

	void Start ()
	{
		renderer = GetComponent<SpriteRenderer> ();
	}


	void OnMouseDown ()  //нажали мышку
	{
		isButtonDown = true;
		isButtonUp = false;
		Color color = renderer.material.color;
		color.a = 0.5f;
		renderer.material.color = color;
	}

	void OnMouseUp ()  //отжали мышку
	{
		isButtonDown = false;
		isButtonUp = true;
		Color color = renderer.material.color;
		color.a = 1f;
		renderer.material.color = color;
	}

}
