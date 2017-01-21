using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public WavePlotter plotter;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var headerPosition = plotter.GetWaveHeader().transform.position;
		Debug.Log (headerPosition.x);
		transform.position =  new Vector3(headerPosition.x - 10, 0, -10); 
	}
}
