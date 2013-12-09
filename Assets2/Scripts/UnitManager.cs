using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {
	
	public List<GameObject> selectedUnits;
	public List<GameObject> savedUnitsOne;
	public List<GameObject> savedUnitsTwo;
	public List<GameObject> savedUnitsThree;
	public List<GameObject> savedUnitsFour;
	public List<GameObject> savedUnitsFive;

	public int numUnitsAllowed = 200;
	public int currentUnits = 0;
	
	// Use this for initialization
	void Start () {
		selectedUnits.Clear();
		savedUnitsOne.Clear();
		savedUnitsTwo.Clear();
		savedUnitsThree.Clear();
		savedUnitsFour.Clear();
		savedUnitsFive.Clear();
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
				savedUnitsOne = new List<GameObject>();
				savedUnitsOne.AddRange(selectedUnits);
			}else{
				selectedUnits = new List<GameObject>();
				selectedUnits.AddRange(savedUnitsOne);
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
				savedUnitsTwo = new List<GameObject>();
				savedUnitsTwo.AddRange(selectedUnits);
			}else{
				selectedUnits = new List<GameObject>();
				selectedUnits.AddRange(savedUnitsTwo);
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
				savedUnitsThree = new List<GameObject>();
				savedUnitsThree.AddRange(selectedUnits);
			}else{
				selectedUnits = new List<GameObject>();
				selectedUnits.AddRange(savedUnitsThree);
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
				savedUnitsFour = new List<GameObject>();
				savedUnitsFour.AddRange(selectedUnits);
			}else{
				selectedUnits = new List<GameObject>();
				selectedUnits.AddRange(savedUnitsFour);
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
				savedUnitsFive = new List<GameObject>();
				savedUnitsFive.AddRange(selectedUnits);
			}else{
				selectedUnits = new List<GameObject>();
				selectedUnits.AddRange(savedUnitsFive);
			}
		}
	}
	
	public bool IsSelected(GameObject unit){
		if(selectedUnits.Contains(unit)){
			return true;
		}else{
			return false;
		}
	}
	
	public void SelectSingleUnit(GameObject unit){
		selectedUnits.Clear();
		selectedUnits.Add(unit);
	}
	
	public void SelectAdditionalUnit(GameObject unit){
		if(!IsSelected(unit)){
			selectedUnits.Add(unit);
		}
	}
	
	public void SelectAllUnitsOfType(GameObject unit){
		GameObject[] val = GameObject.FindGameObjectsWithTag(unit.tag);
		foreach(GameObject tmp in val){
			SelectAdditionalUnit(tmp);
		}
	}
	
	public void DeselectUnit(GameObject unit){
		selectedUnits.Remove(unit);
	}
	
	public void UnitDeath(GameObject unit){
		selectedUnits.Remove(unit);
		savedUnitsOne.Remove(unit);
	}
	
	public void DeselectAllUnits(){
		selectedUnits.Clear();
	}
	
	public void StopMovingSelectedUnits(){
		foreach(GameObject unit in selectedUnits){
			unit.SendMessage("StopMoveOrder", SendMessageOptions.DontRequireReceiver);
		}
	}
	
	public List<GameObject> GetSelectedUnits(){
		return selectedUnits;
	}
	
	public int getNumSelectedUnits(){
		return selectedUnits.Count;
	}
	
	public bool UnitsAreSelected(){
		if(selectedUnits.Count > 0){
			return true;
		}else{
			return false;
		}
	}

	public void AddUnit(){
		currentUnits++;
	}

	public void RemoveUnit(){
		currentUnits--;
	}

	public int NumUnits(){
		return currentUnits;
	}
}
