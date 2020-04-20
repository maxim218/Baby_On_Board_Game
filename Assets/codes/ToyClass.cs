using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToyClass : MonoBehaviour {
	public GameObject soundPrefab;
	
	void makeSound() {
		GameObject mySound = Instantiate(soundPrefab) as GameObject;
		GameObject Hero = GameObject.Find("Hero");
		mySound.transform.position = Hero.transform.position;
	}
	
	void Update () {
		// rotate
		float speedRotating = 40.0f;
		transform.Rotate(0, speedRotating * Time.deltaTime, 0);
		// hit control
		GameObject PUPSIK = GameObject.Find("PUPSIK");
		if( ! PUPSIK) return;
		float d = Vector3.Distance(PUPSIK.transform.position, gameObject.transform.position);
		if(d < 2.2f) {
			makeSound();
			Destroy(gameObject);			
		}		
	}
}
