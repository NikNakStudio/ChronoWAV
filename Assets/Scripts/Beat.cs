using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

    public float beatPeriod = 2;
    public float scaleFactor = 1.5F;
    private float counter = 0.0f;

	// Use this for initialization
	void Start () {
        gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0F);
        
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter <= beatPeriod / 2.0f)
            gameObject.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
        else if (counter >= beatPeriod / 2.0f && counter < beatPeriod)
            gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0F);
        else
            counter = 0;
    }
       	
}
