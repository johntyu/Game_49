using UnityEngine;
using System.Collections;

public class FogUpEverything : MonoBehaviour {

	public Transform fogBlock;

	public int xFrom;
	public int xTo;
	public int xLength;
	public int zFrom;
	public int zTo;
	public int zLength;
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

		for (int z = zFrom; z * zLength < zTo; z++) {
			for (int y = 0; y < yBlockCount; y++) {
				for (int x = xFrom; x * xLength < xTo; x++) {
					Instantiate(fogBlock, new Vector3(x * xLength, y * yBlockHeight + yLiftBy, z * zLength), Quaternion.identity);
				}
			}
		}
	}
}
