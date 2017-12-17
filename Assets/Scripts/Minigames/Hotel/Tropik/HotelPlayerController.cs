using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HotelPlayerController : MonoBehaviour {

	public GameObject tutorial;
	public GameObject gameUI;
	public GameObject pauseUI;
	public GameObject gameOverUI;
	public GameObject winUI;

	public GameObject[] hotelParts;
	private float timer = 180f;
	public Text timerText;
	private bool moveTimer;
	private int coins;
	public Text coinText;
	private float x;
	public GameObject[] coin;
	private float cd;
	private bool isPause;
	public bool timeBonus;
	public float timeBonusTime;
	private int coinType;
	// Use this for initialization
	void Start () {
		
	}


	
	// Update is called once per frame
	void Update () 
	{
		timerText.text = timer.ToString ("f0");
		coinText.text = coins.ToString ();


		if (!isPause) {
			if (moveTimer && timer > 0) {
				timer -= Time.deltaTime;	
				Move (Input.GetAxis ("Horizontal"));

				if (timeBonusTime > 0)
					timeBonusTime -= Time.deltaTime;
				else 
				{
					timeBonusTime = 0;
					timeBonus = false;
				}
				if (cd > 0)
					cd -= Time.deltaTime;
				else 
				{
					int random = Random.Range (0, 100);
					if (random >= 0 && random <= 3)
						coinType = 1;
					if (random >= 4 && random <= 10)
						coinType = 2;
					if (random >= 11 && random <= 16)
						coinType = 3;
					if (random >= 17 && random <= 100)
						coinType = 0;
					Instantiate (coin[coinType], new Vector2 (Random.Range (-6, 7), 5.25f), Quaternion.identity);
					if(!timeBonus)
						cd = Random.Range (0, 2f);
					else
						cd = Random.Range (0, 1f);
				}
			} else if (moveTimer && timer <= 0) {
				gameUI.SetActive (false);
				Move (0);
				gameOverUI.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.Space))
				Coin ();

			transform.Translate (Vector2.right * x * 0.125f);

			if (transform.position.x > 6f)
				transform.position = new Vector2 (6, transform.position.y);

			if (transform.position.x < -6f)
				transform.position = new Vector2 (-6, transform.position.y);
		} 
		Debug.Log (Time.timeScale);
	}

	public void Pause()
	{
		isPause = !isPause;
		Time.timeScale = System.Convert.ToInt32(!isPause);
		pauseUI.SetActive (isPause);
		gameUI.SetActive (!isPause);
	}

	public void Retry()
	{
		SceneManager.LoadScene (Application.loadedLevelName);
	}

	public void Menu()
	{
		SceneManager.LoadScene ("WirldMap");
	}

	public void Bonus()
	{
		timeBonusTime = 5f;
		timeBonus = true;
	}

	public void AddTime()
	{
		timer += 5f;
	}

	public void MinusTime()
	{
		timer -= 5f;
	}

	public void Coin()
	{
		coins++;
		if(coins >= 5 && coins <= 105)
			hotelParts [(coins / 5) - 1].SetActive (true);
		if (coins > 105) {
			moveTimer = false;
			gameUI.SetActive (false);
			winUI.SetActive (true);
		}
	}

	public void StartTimer()
	{
		tutorial.SetActive (false);
		gameUI.SetActive (true);
		moveTimer = true;
	}

	public void Move(float i)
	{
		if (i > 0)
			transform.localScale = new Vector3 (1, 1, 1);
		else if(i < 0)
			transform.localScale = new Vector3 (-1, 1, 1);
		x = i;
	}
}