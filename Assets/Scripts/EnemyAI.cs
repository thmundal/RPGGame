using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotateSpeed;
	public int maxDistance;
	
	private Transform myTransform;
	
	// Starts before anything else
	void Awake() {
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		// Find the player by tag
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		// Set the target to the player's transform
		target = go.transform;
		
		maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(target.position, myTransform.position, Color.red);
	
		// Look at target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotateSpeed * Time.deltaTime);
		
		if(Vector3.Distance(target.position, myTransform.position) > maxDistance) {
			// Move towards the target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
