using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : MonoBehaviour {
	void Update () {
		float speedRotating = 30.0f;
		transform.Rotate(0, speedRotating * Time.deltaTime, 0);
		// hero up
		GameObject hero = GameObject.Find("Hero");	
		float d = Vector3.Distance(hero.transform.position, transform.position);
		if(d < 3.0f) {			
			hero.transform.Translate(0, 12, 0, Space.World);
		}
	}
}
