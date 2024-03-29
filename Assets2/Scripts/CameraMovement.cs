﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public float camSpeed = 25.0f;
	public float GUIregion  = 0.05f;

	private float GUIhSize;
	private float GUIwSize;
	private Rect recDown;
	private Rect recUp;
	private Rect recLeft;
	private Rect recRight;

	private CreateSelectionBox selectionBox;

	void Start () {
		GUIhSize = Screen.height * GUIregion;
		GUIwSize = Screen.width * GUIregion;

		recDown  = new Rect(0, 0, Screen.width, GUIhSize);
		recUp    = new Rect(0, Screen.height-GUIhSize, Screen.width, GUIhSize);
		recLeft  = new Rect(0, 0, GUIwSize, Screen.height);
		recRight = new Rect(Screen.width-GUIwSize, 0, GUIwSize, Screen.height);

		selectionBox = gameObject.GetComponent<CreateSelectionBox>();
	}
	
	void Update () {
		Start ();
		
		Vector3 towards = new Vector3();
		
		if (recDown.Contains(Input.mousePosition)) {
			towards.z = -1;
		}

		if (recUp.Contains(Input.mousePosition)) {
			towards.z = 1;
		}

		if (recLeft.Contains(Input.mousePosition)) {
			towards.x = -1;
		}

		if (recRight.Contains(Input.mousePosition)) {
			towards.x = 1;
		}

		if ((towards.x != 0 || towards.z != 0) && !selectionBox.selecting) {
			transform.Translate(towards.normalized * camSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0){
			transform.position = new Vector3(transform.position.x, transform.position.y + 100*Time.deltaTime, transform.position.z);
			if(transform.position.y > 60.0f){
				transform.position = new Vector3(transform.position.x, 60.0f, transform.position.z);
			}
	    }
	    if (Input.GetAxis("Mouse ScrollWheel") > 0){
			transform.position = new Vector3(transform.position.x, transform.position.y - 100*Time.deltaTime, transform.position.z);
			if(transform.position.y < 10.0f){
				transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);
			}
	    }
	}
}
