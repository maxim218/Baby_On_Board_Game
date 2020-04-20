using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pult : MonoBehaviour {
	private bool Q; 
    private bool E;
	private Rect rectObject;
	private string rectMessage;
	
	private GameObject cranObject;
	public string type = "ROTATION";
	
	public void initCranObject(GameObject cranObjectParam) {
		cranObject = cranObjectParam;
	}
	
	void Start () {
		Q = false;
		E = false;
		rectObject = new Rect(20, 20, 300, 32);
		rectMessage = "Operating with the Q and E keys";
	}
	
	public void setIndex(int index) {
		Cran scr = cranObject.GetComponent<Cran>();
		if("ROTATION" == type) scr.setVectorIndex(index);
		if("MOVEMENT" == type) scr.setMoveInd(index);
		if("UP_AND_DOWN" == type) scr.updownIndex(index);
	}
	
	void Update () {
		// is hero NOT near - stop cran - return
		if(isHeroNear() == false) {
			Q = false;
			E = false;
			setIndex(0);
			return;
		};
		// Q
		if (Input.GetKeyDown(KeyCode.Q)) Q = true;
		if (Input.GetKeyUp(KeyCode.Q)) Q = false;
		// E
		if (Input.GetKeyDown(KeyCode.E)) E = true;
		if (Input.GetKeyUp(KeyCode.E)) E = false;
		// control
		if(Q == true)
			setIndex(1);
		else if(E == true)
			setIndex(-1);
		else
			setIndex(0);		 
	}
	
	private bool isHeroNear() {
		GameObject hero = GameObject.Find("Hero");		
		float d = Vector3.Distance(hero.transform.position, transform.position);
		if(d < 2.8f) return true;
		return false;
	}
	
	void OnGUI() {
		 // is hero NOT near - stop cran - return
		 if(isHeroNear() == false) {
			 Q = false;
			 E = false;
			 setIndex(0);
			 return;
		 };
		 GUI.Box(rectObject, rectMessage);
	}
}
