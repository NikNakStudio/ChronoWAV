using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDeaf : MonoBehaviour {

    public bool isDeaf;
    public bool isDeafOnCollide = true;
    public float deafnessDuration = 2f;
    private float remainingDeafnessTime = 0;
    public float totalDeafnessTime = 0f;
    private AudioSource audioSource;
	private AudioSource wrongSource;

	// Use this for initialization
	void Start () {
        audioSource = GameObject.Find("MainSource").GetComponent<AudioSource>();
		wrongSource = GameObject.Find("WrongSource").GetComponent<AudioSource>();
        UnMute();
	}
	
	// Update is called once per frame
    private void Update(){
        if (isDeaf)
            totalDeafnessTime += Time.deltaTime;
        
        remainingDeafnessTime -= Time.deltaTime;
        if (!isDeafOnCollide && remainingDeafnessTime <= 0)
            UnMute();
    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.GetType() == typeof(BoxCollider2D))
            Mute();
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.GetType() == typeof(BoxCollider2D))
            UnMute();
    }

    private void Mute(){
        isDeaf = true;
        remainingDeafnessTime = deafnessDuration;
        audioSource.volume = 0;
		wrongSource.volume = 0.2f;
    }

    private void UnMute(){
        isDeaf = false;
        remainingDeafnessTime = 0;
        audioSource.volume = 1;
		wrongSource.volume = 0;
    }

    public float GetTotalDeafnessTime(){
        return totalDeafnessTime;
    }
}
