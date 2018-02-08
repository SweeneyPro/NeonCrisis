using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_pew : MonoBehaviour {

	public Animator Pew;

	// Use this for initialization
	void Start () {

		Pew.GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("p")){
			if (Pew != null) {
				print ("BLOOP");
			}
			Pew.SetTrigger ("Shoot");


			}
		


		

	}

}