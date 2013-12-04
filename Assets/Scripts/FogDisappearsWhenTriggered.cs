using UnityEngine;
using System.Collections;

public class FogDisappearsWhenTriggered : MonoBehaviour {

	//void Start () {
	//	friendlyLayer = LayerMask.NameToLayer("Friendlies");
	//}

	void OnTriggerEnter(Collider other) {
		//if (other.gameObject.layer == friendlyLayer) {
			Destroy (this.gameObject);
		//}
	}
}
