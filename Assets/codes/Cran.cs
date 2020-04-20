using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cran : MonoBehaviour {
	private float speedRotating; 
	private int vectorIndex;
	private float rotatingSUMMA = 0.0f;
	
	private float moveSpeed;
	private int moveIndex;
	private float moveDeltaSumma;
	
	private float upOrDown_Speed;
	private int upOrDown_INDEX;
	private float upOrDown_SUMMA;
	
	public void setVectorIndex(int valueParam) {
		vectorIndex = valueParam;
	}
	
	public void setMoveInd(int valParam) {
		moveIndex = valParam;
	}
	
	public void updownIndex(int k) {
		upOrDown_INDEX = k;
	}
	
	void Start () {
		// up-or-down
		upOrDown_Speed = 10.0f;
		upOrDown_INDEX = 0;
		upOrDown_SUMMA = 0.0f;
		// rotating params
		speedRotating = -2.0f;
		rotatingSUMMA = 0.0f;
		vectorIndex = 0;
		// moving params
		moveSpeed = -6.5f;
		moveIndex = 0;
		moveDeltaSumma = 0.0f;
		// childs init
		gameObject.transform.Find("Pult-moving").gameObject.GetComponent<Pult>().initCranObject(gameObject);
		gameObject.transform.Find("Pult-rotating").gameObject.GetComponent<Pult>().initCranObject(gameObject);
		gameObject.transform.Find("Pult-up-down").gameObject.GetComponent<Pult>().initCranObject(gameObject);
	}
	
	void Update () {	
		//
		//
		// rotating
		float rrrr = vectorIndex * speedRotating * Time.deltaTime;
		float FUTURE = rotatingSUMMA + rrrr;
		if(-5.0f < FUTURE && FUTURE < 5.0f) {
			transform.Translate(0, 0, rrrr);
			rotatingSUMMA += rrrr;
		}
		//
		//
		// moving
		GameObject Child = gameObject.transform.Find("CranMovingElement").gameObject;
		float mmm = moveIndex * moveSpeed * Time.deltaTime;
		if(0.0 > moveDeltaSumma + mmm && moveDeltaSumma + mmm > -30.0f) {
			Child.transform.Translate(mmm, 0, 0);
			moveDeltaSumma += mmm;
		}
		// up-and-down
		GameObject BottomPlatform = Child.transform.Find("BottomPlatform").gameObject;
		float bbbbbbb = upOrDown_INDEX * upOrDown_Speed * Time.deltaTime;
		if(0 > upOrDown_SUMMA + bbbbbbb && upOrDown_SUMMA + bbbbbbb > -16.34f) {
			BottomPlatform.transform.Translate(0, bbbbbbb, 0);
			upOrDown_SUMMA += bbbbbbb;
		}
		// verevka
		GameObject Verevka = Child.transform.Find("Verevka").gameObject;
		float dy = Child.transform.position.y - BottomPlatform.transform.position.y;
		Vector3 scaleObj = Verevka.transform.localScale;
		scaleObj.y = dy * 1.4f;
		Verevka.transform.localScale = scaleObj;
		Vector3 posObj = Verevka.transform.position;
		Vector3 newObjPos = new Vector3(posObj.x, Child.transform.position.y - 0.5f - dy / 2, posObj.z);		
		Verevka.transform.position = newObjPos;
	}
}
