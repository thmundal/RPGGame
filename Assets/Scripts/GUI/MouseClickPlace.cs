using UnityEngine;
using System.Collections;

public class MouseClickPlace : MonoBehaviour {
	private float _mouseposX;
	private Vector3 _rayHitWorldPos;
	private Vector3 targetPosition;
	private GameObject _objectToPlace;

	// Use this for initialization
	void Start () {
		//_objectToPlace = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//_objectToPlace.GetComponent<BoxCollider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(_objectToPlace != null) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			LayerMask layerMask = 1 << 8;
			layerMask = ~layerMask;
			
			if(Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {
				_objectToPlace.transform.position = hit.point;
			}
			
			if(Input.GetMouseButtonDown(0)) {
				Debug.Log ("Remove object to move");
				_objectToPlace.GetComponent<BoxCollider>().enabled = true;
				_objectToPlace = null;
				Messenger<bool>.Broadcast("mousePlaceRegister", false);
			}
				
		}
	}
	
	public void OnEnable() {
		Messenger<GameObject>.AddListener("placeObject", StartPlacing);
	}
	
	public void OnDisable() {
		Messenger<GameObject>.RemoveListener("placeObject", StartPlacing);
	}
	
	public void StartPlacing(GameObject objToPlace) {
		if(_objectToPlace == null) {
			_objectToPlace = objToPlace;
			
			Messenger<bool>.Broadcast("mousePlaceRegister", true);
		}
	}
	
}
