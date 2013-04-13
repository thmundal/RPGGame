using UnityEngine;
using System.Collections;

public class GUI_root : MonoBehaviour {
	GUI_Element test;
	void Start() {
		test = new GUI_Element(GUI_Type.Box, new Vector2(1, 1), new Vector2(10, 10));
	}
	
	void OnGUI() {
		test.Display();
	}
}
