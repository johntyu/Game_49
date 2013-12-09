using UnityEngine;
using System.Collections;

public class ProjectCameraViewToMiniMap : MonoBehaviour {

	private Vector3 botLeft;
	private Vector3 botRight;
	private Vector3 topLeft;
	private Vector3 topRight;

	// Update is called once per frame
	void Update () {

		Ray ray;
		RaycastHit []hit;

		ray = Camera.mainCamera.ScreenPointToRay(new Vector3(0.0f, 0.0f, 0.0f));
		hit = Physics.RaycastAll(ray);
		foreach(RaycastHit hitPoint in hit){
			if(hitPoint.point.y == -5.0f){
				botLeft = new Vector3(hitPoint.point.x, 80.0f, hitPoint.point.z);
			}
		}
		ray = Camera.mainCamera.ScreenPointToRay(new Vector3(Screen.width, 0.0f, 0.0f));
		hit = Physics.RaycastAll(ray);
		foreach(RaycastHit hitPoint in hit){
			if(hitPoint.point.y == -5.0f){
				botRight = new Vector3(hitPoint.point.x, 80.0f, hitPoint.point.z);
			}
		}
		ray = Camera.mainCamera.ScreenPointToRay(new Vector3(0.0f, Screen.height, 0.0f));
		hit = Physics.RaycastAll(ray);
		foreach(RaycastHit hitPoint in hit){
			if(hitPoint.point.y == -5.0f){
				topLeft = new Vector3(hitPoint.point.x, 80.0f, hitPoint.point.z);
			}
		}
		ray = Camera.mainCamera.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0.0f));
		hit = Physics.RaycastAll(ray);
		foreach(RaycastHit hitPoint in hit){
			if(hitPoint.point.y == -5.0f){
				topRight = new Vector3(hitPoint.point.x, 80.0f, hitPoint.point.z);
			}
		}
	}

	public Vector2[] ReturnPoints(){
		Vector2[] vertices2D = new Vector2[] {
			new Vector2(botLeft.x,botLeft.z),
			new Vector2(botRight.x,botRight.z),
			new Vector2(topRight.x,topRight.z),
			new Vector2(topLeft.x,topRight.z)
		};
		return vertices2D;
	}

}
