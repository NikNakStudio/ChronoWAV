using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour {

    public GameObject tailWaveObject;
    public GameObject headerWaveObject;
    public int numberOfPoints= 100;
    public float animSpeed =1.0f;
    public float scaleInputRange = 2*Mathf.PI; // scale number from [0 to 99] to [0 to 2Pi]
    public float scaleResult = 10.0f;
    public float frecuency = 1;
    public bool animate = true;
    public float motionSpeed = 0;
    public Color backgroundColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
