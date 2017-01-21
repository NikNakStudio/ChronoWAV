using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public LevelController levelController;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var headerPosition = levelController.GetWaveHeader().transform.position;
		transform.position =  new Vector3(headerPosition.x + 5, 0, -10);
	}
}
