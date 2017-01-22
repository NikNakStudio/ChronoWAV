using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDeaf : MonoBehaviour {

    public bool isDeaf;
    public float deafnessDuration = 2f;
    private float remainingDeafnessTime = 0;
    private AudioSource audioSource;
	private AudioSource wrongSource;

	// Use this for initialization
	void Start () {
        audioSource = GameObject.Find("MainSource").GetComponent<AudioSource>();
		wrongSource = GameObject.Find("WrongSource").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
    void Update(){
        remainingDeafnessTime -= Time.deltaTime;
        if (remainingDeafnessTime <= 0)
            UnMute();
    }


    void OnTriggerEnter(Collider other){
        if (other.GetType() == typeof(BoxCollider))
            Mute();
    }

    /*void OnTriggerExit(Collider other){
        if (other.GetType() == typeof(BoxCollider))
            UnMute();
    }*/

    void Mute(){
        isDeaf = true;
        remainingDeafnessTime = deafnessDuration;
        audioSource.volume = 0;
		wrongSource.volume = 1;
    }

    void UnMute(){
        isDeaf = false;
        remainingDeafnessTime = 0;
        audioSource.volume = 1;
		wrongSource.volume = 0;
    }
}
