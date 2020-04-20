using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowTeleportScript : MonoBehaviour {
	public GameObject placeObject;
	public GameObject soundPrefab;
	
	void makeSound() {
		GameObject mySound = Instantiate(soundPrefab) as GameObject;		
		mySound.transform.position = placeObject.transform.position;
	}
	
	void Update () {
		float speedRotating = 30.0f;
		transform.Rotate(0, 0, speedRotating * Time.deltaTime);
		// to pos
		GameObject hero = GameObject.Find("Hero");	
		float d = Vector3.Distance(hero.transform.position, transform.position);
		if(d < 3.0f) {
			hero.transform.position = new Vector3(
			     placeObject.transform.position.x,  
			     placeObject.transform.position.y,  
			     placeObject.transform.position.z
			);
			makeSound();
		}
	}
}
