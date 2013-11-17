using UnityEngine;
using System.Collections;

public class DragSelect : MonoBehaviour {
	
	public GameObject selector;
	private Vector3 corner;
	private GameObject selectorInstance;
	
	void OnMouseDown(){
		//raycast to determine position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit info;
		Physics.Raycast(ray, out info, Mathf.Infinity, 1);
		corner = info.point;
		
		//instantiate drag selector widget with position
		selectorInstance = Instantiate(selector, corner, selector.transform.rotation) as GameObject;
	}
	
	void OnMouseDrag(){
		//raycast to determine position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit info;
		Physics.Raycast(ray, out info, Mathf.Infinity, 1);
		
		//resize selector widget with new position
		Vector3 resizeVector = info.point - corner;
		Vector3 newScale = selectorInstance.transform.localScale;
		newScale.x = resizeVector.x;
		newScale.z = -resizeVector.z;
		selectorInstance.transform.localScale = newScale;
		
	}
	
	void OnMouseUp(){
		//destroy selector widget
		Destroy(selectorInstance);
	}
}
