using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleRotation : MonoBehaviour {
	void Update () {
		float speedRotating = 5.0f;
		transform.Rotate(0, speedRotating * Time.deltaTime, 0);
	}
}
