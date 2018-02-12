using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFixer : MonoBehaviour {
    Quaternion fixedRotation;
	// Use this for initialization
	void Start () {
        fixedRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        this.transform.rotation = fixedRotation;
	}
}
