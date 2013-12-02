using UnityEngine;
using System.Collections;

public class PauseMenuGUI : MonoBehaviour {

	public bool paused = false;
	public Texture pauseMenuBackground;
	public Texture pauseMenuForeground;
	public Texture buttonTexture;

	private Rect resumeGame;
	private Rect settings;
	private Rect mainMenu;

	void Start(){
		float buttonW = Screen.width / 2.0f;
		float buttonH = Screen.height / 8.0f;
		float YStart = Screen.height / 2.0f - buttonH / 2.0f;
		float XStart = Screen.width / 2.0f - buttonW / 2.0f;

		resumeGame = new Rect(XStart,YStart + buttonH*0,buttonW,buttonH);
		settings = new Rect (XStart,YStart + buttonH*1,buttonW,buttonH);
		mainMenu = new Rect (XStart,YStart + buttonH*2,buttonW,buttonH);
	}

	void Update(){
		if( Input.GetKeyDown(KeyCode.Escape)){
			paused = !paused;
		}
		if(paused){
			Time.timeScale = 0;
		}else{
			Time.timeScale = 1;
		}
	}

	void OnGUI () {

		if(paused){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseMenuBackground, ScaleMode.StretchToFill);

			Vector2 mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

			if (GUI.Button (resumeGame, " ", GUI.skin.label)) {
				paused = !paused;
			}
			if( GUI.Button (settings, " ", GUI.skin.label)) {
				//Application.LoadLevel("settings");
			}
			if( GUI.Button (mainMenu, " ", GUI.skin.label)) {
				Application.LoadLevel("mainMenu");
			}

			if(resumeGame.Contains(mouse)){
				GUI.DrawTexture(resumeGame, buttonTexture, ScaleMode.StretchToFill);
			}else if(settings.Contains(mouse)){
				GUI.DrawTexture(settings, buttonTexture, ScaleMode.StretchToFill);
			}else if(mainMenu.Contains(mouse)){
				GUI.DrawTexture(mainMenu, buttonTexture, ScaleMode.StretchToFill);
			}

			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseMenuForeground, ScaleMode.StretchToFill);
		}
	}

}
