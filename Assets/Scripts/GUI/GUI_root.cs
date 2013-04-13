using UnityEngine;
using System.Collections;

public class GUI_root : MonoBehaviour {
	GUI_Element test;
	void Start() {
		test = new GUI_Element(GUI_Type.Button, new Vector2(100, 1), new Vector2(100, 100));
	}
	
	void OnGUI() {
		test.Display();
	}
}
