using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachEnd : MonoBehaviour {

	public bool Ended = false;
    public float TimeSinceEnd = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Ended)
            TimeSinceEnd += Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){
		Ended = true;
	}
}
