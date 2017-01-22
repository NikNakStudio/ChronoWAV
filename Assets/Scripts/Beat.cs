using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

    public float beatPeriod = 2;
    public float scaleFactor = 1.5F;
    private float counter = 0.0f;
    private float x;
    private float y;
    private float z;

	// Use this for initialization
	void Start () {
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter <= beatPeriod / 2.0f)
            ResetScale();
        else if (counter >= beatPeriod / 2.0f && counter < beatPeriod)
            Scale();
        else
            counter = 0;
    }
      
    void Scale(){
        gameObject.transform.localScale = new Vector3(x*scaleFactor, y*scaleFactor, z);
    }

    void ResetScale(){
        gameObject.transform.localScale = new Vector3(x, y, z);
    }
}
