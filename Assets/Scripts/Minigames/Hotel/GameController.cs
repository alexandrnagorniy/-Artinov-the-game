using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public float speed;
	private float direction = 0;
	private float timer;
	public Rigidbody2D rig;
	public static AudioSource audioSource;
	public AudioClip moneyDown;
	public AudioClip bonus;
	public List<GameObject> hotelBlocks;
	float [] blockPlaceX = new float [15];
	float [] blockPlaceY = new float [15];
	public Text panelText;
	public Text timeText;
	public Text recordTime;
	public static int recordT;
	public ButtonScript leftButton;
	public ButtonScript rightButton;
	public static bool pauseGame = false;
	private float t = 0;
	public static int CountMoney = 0;
	private float blockSize = 1.21f;
	private int temp = 200;
	private int curBlock = 0;
	private bool gameMenu = false;
	public GameObject muteSymbol;
	public GameObject pauseSymbol;
	public GameObject userMenu;
	public GameObject infoMenu;
	public GameObject stayButton;
	public GameObject awayButton;
	public static bool sound = true;
	public static bool gameOn = true;
	public static bool infaOn = false;
	public static bool exit_1 = false;
	private float time_of_pause = 0;
	private float time_of_pause2 = 0;
	private bool pause_flag = true;

	void Start () 
	{
		rig = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		recordT = PlayerPrefs.GetInt ("record");
		timer = Time.realtimeSinceStartup;
		muteSymbol.active = false;
		pauseSymbol.active = false;
		userMenu.active = false;
		infoMenu.active = false;
		stayButton.active = false;
		awayButton.active = false;

		for (int i = 0; i < 5; i++) 
		{
			blockPlaceX [i] = blockSize * i + 2 + blockSize;
			blockPlaceX [i+5] = blockPlaceX [i];
			blockPlaceX [i+10] = blockPlaceX [i];
		}

		for (int j = 0; j < 3; j++) 
		{
			blockPlaceY [j] = blockSize * j + 2 + blockSize; 
			blockPlaceY [j+3] = blockPlaceY [j];
			blockPlaceY [j+6] = blockPlaceY [j];
			blockPlaceY [j+9] = blockPlaceY [j];
			blockPlaceY [j+12] = blockPlaceY [j]; 
		}


	}


	void Update () 
	{
		panelText.text = CountMoney.ToString ();
		recordTime.text = "Record: " + recordT.ToString("f0");
		if (!pauseGame)
			timeText.text = "Time: " + (Time.realtimeSinceStartup - time_of_pause2).ToString ("f0");
		
		if (pauseGame == true)
		{
			if (pause_flag) 
			{
				time_of_pause = Time.realtimeSinceStartup;  //время начала паузы
				pause_flag = false;
			}
			 
			pauseSymbol.active = true;
			Sound_Off (true);
			Time.timeScale = 0;
		} 
		else if (pauseGame == false) 
		{
			if (!pause_flag)   
			{	
				time_of_pause2 = (int)(Time.realtimeSinceStartup - time_of_pause + time_of_pause2); //общее время паузы
			    pause_flag = true;
	    	}
			    pauseSymbol.active = false;
				Sound_Off (false);
				Time.timeScale = 1;
			}

		if (sound)
			muteSymbol.active = false;
		   else 
		{
			muteSymbol.active = true;
			Sound_Off (true);
		}

		if (infaOn)
			infoMenu.active = true;
		  else 
			infoMenu.active = false;

		if (!exit_1)
		{
			stayButton.active = false;
			awayButton.active = false;
		} 
		else 
		{
			stayButton.active = true;
			awayButton.active = true;
		}

		if (!gameOn)
			StopGame ();
			


		if (monetka.cashMoney) 
		{
			audioSource.clip = moneyDown;
			audioSource.Play();
			monetka.cashMoney = false;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) || rightButton.isButtonDown) 
		{
				direction = 1;
				transform.rotation = Quaternion.Euler (0, 0, 0);
		} 
		else if (Input.GetKeyDown (KeyCode.LeftArrow) || leftButton.isButtonDown)
		 {
				direction = -1;
				transform.rotation = Quaternion.Euler (0, 180, 0);
		 }

		if (leftButton.isButtonUp || rightButton.isButtonUp || Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow))
		{
			direction = 0;
			leftButton.isButtonUp = false;
			rightButton.isButtonUp = false;
		}
	
		rig.MovePosition (transform.position + new Vector3(speed * direction, 0, 0));
						
		t = CountMoney/10f;
		if (t - (int)(t) == 0 & temp != CountMoney & CountMoney > 9)
		{
			
				audioSource.clip = bonus;
				audioSource.Play ();		
			if (CountMoney < 160) 
			{
				Vector3 newPosition = new Vector3 (blockPlaceX [curBlock] - 5.7f, blockPlaceY [curBlock] - 5f, 0);
				GameObject tempBlock = GameObject.Instantiate (hotelBlocks [curBlock], newPosition, Quaternion.identity);
			} else
				Debug.Log ("Win");

				if (curBlock == 14) 
			     {
					Vector3 newPosition2 = new Vector3 (0, 1.63f, 0);
					GameObject tempBlock2 = GameObject.Instantiate (hotelBlocks [15], newPosition2, Quaternion.identity);
					StopGame ();
				
				 }

				curBlock++;
				temp = CountMoney;
		}

	}

	public void StopGame ()
	{
		
		if (recordT > (int)(Time.realtimeSinceStartup - time_of_pause2) || recordT == 0)
		{
			PlayerPrefs.SetInt ("record", (int)(Time.realtimeSinceStartup - time_of_pause2));
			PlayerPrefs.Save ();
		}

		Application.Quit();
	}

	public void Sound_Off (bool trigger) // true: soundOFF, false: soundON
	{
		SoundFonScript.audioSource.mute = trigger;  //  sound fon
		audioSource.mute = trigger;                // sound effect
	}
}