using UnityEngine;
using System.Collections;

public class AbilitiesLockDown : MonoBehaviour {

	public LayerMask mask;
	public float radius;
	public bool triggerLockdown;

	public Ray ray;
	public RaycastHit hit;
	private Camera _camera;
	public GameObject targetEnemy;

	void Start () {
		triggerLockdown = false;
		radius = 0.2f;
		_camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		getLockdown();
		doLockdown();
	}
	
	
	public void doLockdown() {
		if(triggerLockdown == true) {
			
			if (Input.GetMouseButtonDown(0)) {
            	Debug.Log ("Left Clicked LD");
				triggerLockdown = false;
				ray = _camera.ScreenPointToRay(Input.mousePosition); 
				
				//If we hit...
				if(Physics.Raycast (ray, out hit, Mathf.Infinity))
				{
					//Tell the system what we clicked something if in debug
				
					Collider[] lockdownArray = Physics.OverlapSphere(hit.point, radius, mask);
					
					if(lockdownArray.Length > 0) {
						Debug.Log("lockedown 1");
						for(int i = 0; i < lockdownArray.Length; i++) {			
							targetEnemy = lockdownArray[i].gameObject;
							targetEnemy.SendMessage("setLockdown", true);	
						}
					}
					
					
							
					//Run the Clicked() function on the clicked object
					//hit.transform.gameObject.SendMessage("RightClicked", hit.point, SendMessageOptions.DontRequireReceiver);
				}		
				
				
            }
		}
		
	}
	
	
	
	
	public void getLockdown() {
		
		if(Input.GetKeyUp(KeyCode.W) && triggerLockdown == false){
			Debug.Log("hello W");
			triggerLockdown = true;
		}
		else if(Input.GetKeyUp(KeyCode.Escape) && triggerLockdown == true) {

			Debug.Log("hello esc");
			triggerLockdown = false;
			
		}
	}
		
}
