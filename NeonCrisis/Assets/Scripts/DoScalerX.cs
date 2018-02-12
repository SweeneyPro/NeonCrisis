using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;

public class DoScalerX : MonoBehaviour {
    public float Xscaletarget1, Xscaletarget2;
    public float speed, stagger_time;


    // Use this for initialization
    void Start()
    {
        Invoke("Do_ScalingX", stagger_time);
    }

    void Do_ScalingX()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        this.transform.DOScaleX(Xscaletarget1, speed).OnComplete(On_Complete);
    }

    void On_Complete()
    {
        this.transform.DOScaleX(Xscaletarget2, speed);
     
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
