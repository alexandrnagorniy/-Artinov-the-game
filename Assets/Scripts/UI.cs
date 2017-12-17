using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    Vector2 speed;
    public GameObject menu, resume, pause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickResume()
    {
       
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic =false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = speed;
        menu.SetActive(false);
        resume.SetActive(false);
        pause.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enabled = true;
    }

    public void OnClickPause()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = true;
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        menu.SetActive(true);
        resume.SetActive(true);
        pause.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enabled = false;
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(Application.loadedLevelName);
    }

    public void OnClickNext()
    {
        SceneManager.LoadScene(1);
    }
}
