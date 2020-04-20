using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoToMain : MonoBehaviour {
	public Camera camera;
	public GUISkin skin;
	public string message;
	
	void OnGUI () {
		// cursor
		Screen.lockCursor = false;
		// get center
		float xxx = camera.pixelWidth / 2;
        float yyy = camera.pixelHeight / 2;
		// y control
		int dy = 100;
		// buttons params
		float width = 300;
		float height = 50;
		// skin
		GUI.skin = skin;
		// box
		GUI.Box(new Rect(xxx - width / 2 - 20, 180 - dy, width + 40, 160),"");
		// label
		GUI.Label(new Rect(xxx - width / 2, 200 - dy, width, height), message);
		// button
		if(GUI.Button(new Rect(xxx - width / 2, 270 - dy, width, height), "Main menu")) {
			Application.LoadLevel("SceneMenu");
		}
	}
}
