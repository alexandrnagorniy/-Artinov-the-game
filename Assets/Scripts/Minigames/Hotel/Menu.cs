using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour 
{
	public GameObject panelMenu; 
	private int countClick_menu_Button = 0;
	private int countClick_menu_Mute = 0;

	public void menu_Button()
	{
		panelMenu.SetActive (!panelMenu.activeSelf);
		countClick_menu_Button ++;

		if (GameController.pauseGame = true & countClick_menu_Button % 2 == 0)
			countClick_menu_Button = 1;

		if (countClick_menu_Button % 2 != 0 )       // непарное нажатие на кнопку меню
			GameController.pauseGame = true;
		else if (countClick_menu_Button % 2 == 0)   // парное нажатие на кнопку меню
			GameController.pauseGame = false;

	}

	public void pause_Button()
	{
		GameController.pauseGame = !GameController.pauseGame;
		panelMenu.SetActive (false);
		GameController.exit_1 = false;
	}

	public void Exit_level_1()
	{
		GameController.exit_1 = !GameController.exit_1;
	}

	public void Exit_level_2()
	{
		GameController.gameOn = false;
	}


	public void Mute ()
	{
		countClick_menu_Mute++;
		if (countClick_menu_Mute % 2 != 0)  // непарное нажатие на кнопку меню
		  GameController.sound = false;

		else if (countClick_menu_Mute % 2 == 0)  // парное нажатие на кнопку меню
		  GameController.sound = true;
	}

	public void Infa ()
	{
		GameController.infaOn = !GameController.infaOn;
	}

}
