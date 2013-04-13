using UnityEngine;
using System.Collections;

public class GUI_root : MonoBehaviour {
	private GUI_Element test;
	private bool _isMousePlaceInProgress;
	
	void Start() {
		test = new GUI_Element(GUI_Type.Button, new Vector2(100, 1), new Vector2(100, 100));
		_isMousePlaceInProgress = false;
	}
	
	void OnGUI() {
		if(test.OnClick()) {
			if(!_isMousePlaceInProgress) {
				GameObject _objectToPlace = Instantiate(Resources.LoadAssetAtPath ("Assets/Prefabs/enemyAITest.prefab", typeof(GameObject))) as GameObject;
				_objectToPlace.GetComponent<BoxCollider>().enabled = false;
				
				Messenger<GameObject>.Broadcast("placeObject", _objectToPlace);
			}
		}
	}
	
	public void OnEnable() {
		Messenger<bool>.AddListener("mousePlaceRegister", mousePlaceRegister);
	}
	
	public void OnDisable() {
		Messenger<bool>.RemoveListener("mousePlaceRegister", mousePlaceRegister);
	}
	
	private void mousePlaceRegister(bool yesNo) {
		_isMousePlaceInProgress = yesNo;
	}
}
