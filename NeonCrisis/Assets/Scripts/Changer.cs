using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer : MonoBehaviour {

	Material sprite_rend_mat;
	float colour_base = 125f;

	// Use this for initialization
	void Start () {
		sprite_rend_mat = GetComponent <SpriteRenderer> ().sharedMaterial;
		if(sprite_rend_mat != null)
		{
			StartCoroutine (Cycle_Colour ());
		}
	}

	IEnumerator Cycle_Colour()
	{
		yield return new WaitForSeconds (0);
	}


}
