using UnityEngine;
using System.Collections;

public class CreateSelectionBox : MonoBehaviour {

	public Texture2D selectionHighlight = null;
	public static Rect selection = new Rect(0, 0, 0, 0);
	private Vector3 startClick = -Vector3.one;

	public bool selecting = false;

	private PauseMenuGUI pauseMenu;

	void Start(){
		pauseMenu = gameObject.GetComponent<PauseMenuGUI>();
	}

	void Update(){

		if(!pauseMenu.paused){
			if(Input.GetMouseButtonDown(0)){
				startClick = Input.mousePosition;
			}else if(Input.GetMouseButtonUp(0)){
				startClick = -Vector3.one;
			}

			if(Mathf.Abs(Input.mousePosition.x - startClick.x) > 10 && 
			   Mathf.Abs(Input.mousePosition.y - startClick.y) > 10 &&
			   Input.GetMouseButton(0)){
				selecting = true;
			}else{
				selecting = false;
			}

			if(selecting){
				CheckCamera();
			}
		}else{
			selecting = false;
		}
	}

	void CheckCamera(){

		if(Input.GetMouseButton(0)){

			if(startClick.x > Input.mousePosition.x && startClick.y > Input.mousePosition.y){ //drag left/down
				selection = new Rect(Input.mousePosition.x, 
				                     InvertMouseY(startClick.y),
				                     startClick.x - Input.mousePosition.x,
				                     InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
			}else if(startClick.x > Input.mousePosition.x && startClick.y < Input.mousePosition.y){ //drag left/up
				selection = new Rect(Input.mousePosition.x, 
				                     InvertMouseY(Input.mousePosition.y),
				                     startClick.x - Input.mousePosition.x,
				                     InvertMouseY(startClick.y) - InvertMouseY(Input.mousePosition.y));
			}else if(startClick.x < Input.mousePosition.x && startClick.y < Input.mousePosition.y){ //drag right/up
				selection = new Rect(startClick.x, 
				                     InvertMouseY(Input.mousePosition.y),
				                     Input.mousePosition.x - startClick.x,
				                     InvertMouseY(startClick.y) - InvertMouseY(Input.mousePosition.y));
			}else{ //drag right/down
				selection = new Rect(startClick.x, 
				                     InvertMouseY(startClick.y), 
				                     Input.mousePosition.x - startClick.x,
				                     InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
			}
		}

	}

	private void OnGUI(){
		if(startClick != -Vector3.one && selecting){
			GUI.color = new Color(1, 1, 1, 0.5f);
			GUI.DrawTexture(selection, selectionHighlight);
		}
	}

	public static float InvertMouseY(float y){
		return Screen.height - y;
	}
}
