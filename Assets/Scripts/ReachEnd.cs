using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachEnd : MonoBehaviour {

	public bool Ended = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Ended = true;
		//if (other.GetType () == typeof(CapsuleCollider))
	}
}
