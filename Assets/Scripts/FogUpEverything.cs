using UnityEngine;
using System.Collections;

public class FogUpEverything : MonoBehaviour {

	public GameObject ground;
	public Transform fogBlock;

	public int xFrom;
	public int xTo;
	public int zFrom;
	public int zTo;
	public float yLiftBy;
	public int yBlockHeight;
	public int yBlockCount;

	// Use this for initialization
	void Start () {
		if (xFrom > xTo) {
			int x = xFrom;
			xFrom = xTo;
			xTo = x;
		}

		if (zFrom > zTo) {
			int z = zFrom;
			zFrom = zTo;
			zTo = z;
		}

		for (int z = zFrom; z < zTo; z++) {
			for (int y = 0; y < yBlockCount; y++) {
				for (int x = xFrom; x < xTo; x++) {
					Instantiate(fogBlock, new Vector3(x, y * yBlockHeight + yLiftBy, z), Quaternion.identity);
				}
			}
		}
	}
}
