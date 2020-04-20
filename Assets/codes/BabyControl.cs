using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BabyControl : MonoBehaviour {
	private float speedMove = 1.5f;
	
	void Update () {
		// control main hero death
		GameObject MyHero = GameObject.Find("Hero");
		if(MyHero.transform.position.y < -5.0f) {
			Application.LoadLevel("SceneLosing");
			return;
		}
		// control death
		if(gameObject.transform.position.y < -5.0f) {
			Destroy(gameObject);
			Application.LoadLevel("SceneLosing");
			return;
		}
		// control play
		ToyClass [] arr;
		arr = FindObjectsOfType(typeof(ToyClass)) as ToyClass[];
		int n = arr.Length;
		if(n == 0) {
			// empty array - you WIN
			Application.LoadLevel("SceneWIN");
			return;
			// empty array - you WIN
		} else {
			// find goal
			float minDistance = 99999999f;
			Vector3 goal = transform.position;
			for(int i = 0; i < arr.Length; i++) {
				Vector3 toyPos = arr[i].gameObject.transform.position;
				float d = Vector3.Distance(toyPos, gameObject.transform.position);
				if(d <= minDistance) {
					minDistance = d;
					goal = toyPos;
				}
			}
			// move to goal
			Vector3 pos = goal - transform.position;
			Quaternion rotation = Quaternion.LookRotation(pos);
			transform.rotation = rotation;
			transform.Translate(0, 0, speedMove * Time.deltaTime);
		}
	}
}
