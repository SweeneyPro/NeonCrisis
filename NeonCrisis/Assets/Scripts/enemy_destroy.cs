using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {

	GameObject Explosion;

	// Use this for initialization
	void Start () {


	}
	
	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Pew") {

			GameObject Explosion = Instantiate (Resources.Load ("Explosion_1"), new Vector3(0.03f, -1.42f, -1), Quaternion.identity)  as GameObject;

			Destroy(gameObject);
		}


	}
}