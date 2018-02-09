using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonhit : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Enemy") {

			Destroy(gameObject);}

	}
}
