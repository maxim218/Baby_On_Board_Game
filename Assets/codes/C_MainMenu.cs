using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class C_MainMenu : MonoBehaviour {
	public Camera camera;
	public GUISkin skin;
	
	void OnGUI() {
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
		GUI.Box(new Rect(xxx - width / 2 - 20, 180 - dy, width + 40, 380),"");
		// label
		GUI.Label(new Rect(xxx - width / 2, 200 - dy, width, height), "Baby On Board");
		// elements
		if(GUI.Button(new Rect(xxx - width / 2, 270 - dy, width, height), "Level 1")) {			
			Application.LoadLevel("SceneA");
		}
		if(GUI.Button(new Rect(xxx - width / 2, 340 - dy, width, height), "Level 2")) {			
			Application.LoadLevel("SceneB");
		}
		if(GUI.Button(new Rect(xxx - width / 2, 410 - dy, width, height), "Level 3")) {			
			Application.LoadLevel("SceneC");
		}				
		if(GUI.Button(new Rect(xxx - width / 2, 480 - dy, width, height), "Exit game")) {			
			Application.Quit();
		}
	}
}
