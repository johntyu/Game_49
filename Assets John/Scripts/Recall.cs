using UnityEngine;
using System.Collections;

public class Recall : MonoBehaviour {

	// Use this for initialization
	public Ray ray;
	public RaycastHit hit;
	private Camera _camera;
	public LayerMask mask;
	public float radius;
	public GameObject targetAlly;
	
	public bool Recaller;
	void Start () {
		Recaller = false;
		radius = 3;
		_camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		getRecall();
		doRecall();
	}
	
	
	public void doRecall() {
		if(Recaller == true) {
			//If mouse click recall your units
			if (Input.GetMouseButtonDown(0)) {
            	Debug.Log ("Left Clicked");
				Recaller = false;
				ray = _camera.ScreenPointToRay(Input.mousePosition); 
				
				//If we hit...
				if(Physics.Raycast (ray, out hit, Mathf.Infinity))
				{
					//Tell the system what we clicked something if in debug
					if(true)
					{
						Debug.Log("You right clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
					}
					Collider[] recallArray = Physics.OverlapSphere(hit.point, radius, mask);
					
					if(recallArray.Length > 0) {
						for(int i = 0; i < recallArray.Length; i++) {			
							targetAlly = recallArray[i].gameObject;
							targetAlly.transform.position = transform.position;
							targetAlly.SendMessage("AttackMoveOrder", transform.position);	
						}
					}
					
					
							
					//Run the Clicked() function on the clicked object
					//hit.transform.gameObject.SendMessage("RightClicked", hit.point, SendMessageOptions.DontRequireReceiver);
				}		
				
				
            }
		}
		
	}
	
	
	
	
	public void getRecall() {
		
		if(Input.GetKeyUp(KeyCode.R) && Recaller == false){
			Debug.Log("hello r");
			Recaller = true;
		}
		else if(Input.GetKeyUp(KeyCode.Escape) && Recaller == true) {

			Debug.Log("hello esc");
			Recaller = false;
			
		}
	}
		
}
