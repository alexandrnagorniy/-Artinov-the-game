using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour 
{
	Renderer renderer;
	public bool fadeIn = false;

	// Use this for initialization
	void Start () 
	{
		renderer = GetComponent<SpriteRenderer> ();
		if (!fadeIn)
			StartCoroutine ("FadeOut");
		else 
			StartCoroutine ("FadeIn");	
	}


	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.F) && !fadeIn)
			StartCoroutine ("FadeIn");

		if (Input.GetKeyDown(KeyCode.O) && fadeIn || GameController.gameOn == false)
			StartCoroutine ("FadeOut");
		
	}


	public IEnumerator FadeIn ()
	{
		for (float i = 0; i <=1; i+= 0.5f)
		{
			Color color = renderer.material.color;
			color.a = i;
			renderer.material.color = color;
			yield return new WaitForEndOfFrame();
		}

		fadeIn = false; //защита от параллельного запуска двох корутин
	}

	IEnumerator FadeOut ()
	{
		yield return new WaitForSeconds (0.5f);
		for (float i = 1; i >= 0; i-= 0.02f)
		{
			Color color = renderer.material.color;
			color.a = i;
			renderer.material.color = color;
			yield return new WaitForEndOfFrame ();

		}
		fadeIn = true;
	}

}
