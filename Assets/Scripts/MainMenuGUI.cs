using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	
	void OnGUI () {

		float buttonW = Screen.width / 4.0f;
		float buttonH = Screen.height / 10.0f;
		float buttonHDif = Screen.height / 8.0f;
		float YStart = Screen.height / 2.0f;
		float XStart = Screen.width / 32.0f;

		if (GUI.Button (new Rect (XStart,YStart + buttonHDif*0,buttonW,buttonH), "Start Game")) {
			Application.LoadLevel("testLevel");
		}
		if( GUI.Button (new Rect (XStart,YStart + buttonHDif*1,buttonW,buttonH), "Instructions")) {
			//Application.LoadLevel("instructions");
		}
		if( GUI.Button (new Rect (XStart,YStart + buttonHDif*2,buttonW,buttonH), "Settings")) {
			//Application.LoadLevel("settings");
		}
		if( GUI.Button (new Rect (XStart,YStart + buttonHDif*3,buttonW,buttonH), "Exit Game")) {
			Application.Quit();
		}
	}
}
