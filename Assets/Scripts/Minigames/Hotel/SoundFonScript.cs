using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFonScript : MonoBehaviour 
{
	public static AudioSource audioSource;

	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();
	}
	

	void Update ()
	{
		
	}
}
