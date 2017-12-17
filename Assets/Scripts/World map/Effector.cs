using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Effector : MonoBehaviour {
	private GameObject nextScene;
	private string sceneName;
	private bool moveScene;
	private SpriteRenderer renderer;
	private float alfa;
	private bool effect;

	public GameObject[] sliders;

	public Transform player;
	private Controller pController;

	private AsyncOperation async;
	public GameObject loadingBack;
	public Image loadingBar;
	private bool loadScene;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		pController = player.gameObject.GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		renderer.color = new Color (0, 0, 0, alfa);
		if (effect)
		{
			if (alfa < 1f)
				alfa += 0.025f;
			else 
			{
				if (!moveScene) 
				{
					Camera.main.GetComponent<CameraController> ().NextScene (nextScene.transform.position);
					float min = nextScene.transform.parent.GetComponent<Location> ().minX;
					float max = nextScene.transform.parent.GetComponent<Location> ().maxX;
					pController.GetPositions (min, max);
					player.position = nextScene.transform.position;
					effect = false;
				} 
				else 
				{
					WorldMap map = Camera.main.GetComponent<WorldMap> ();

				}
			}
		}
		else 
		{
			if (alfa > 0)
				alfa -= 0.025f;
			
		}
	}

	private IEnumerator LoadScene()
	{
		
		yield return new WaitForSeconds (1f);
	}

	public void GoToNextScene(string name)
	{
		sceneName = name;
		moveScene = true;
		effect = true;
	}

	public void GoToNextLocation(GameObject next)
	{
		nextScene = next;
		moveScene = false;
		effect = true;
	}
}
