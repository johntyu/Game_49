using UnityEngine;
using System.Collections;

public class CivilianManager : MonoBehaviour {

	public int totalCiviliansAllowed = 200;
	public int currentCivilians = 0;

	public void AddCivilian(){
		currentCivilians++;
	}

	public void RemoveCivilian(){
		currentCivilians--;
	}

	public int NumCivilians(){
		return currentCivilians;
	}
}
