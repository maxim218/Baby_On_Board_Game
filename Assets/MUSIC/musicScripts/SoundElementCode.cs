using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundElementCode : MonoBehaviour {
	void Start () {
        StartCoroutine( killMe() );
    }
	
	void Update() {
		GameObject Hero = GameObject.Find("Hero");
		if(Hero) gameObject.transform.position = Hero.transform.position;
	}
	
	private IEnumerator killMe() {
        yield return new WaitForSeconds(2);
        Debug.Log("Destroy sound object");
        Destroy(gameObject);
    }
}
