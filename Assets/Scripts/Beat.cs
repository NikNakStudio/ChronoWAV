using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

    public float beatPeriod = 2; //Valid values (0-inf)
    public float maxScaleFactor = 1.5F; // Valid values [0-1]
    public float diastoleFactor = 0.125f;// Valid values [0-1]

    private float counter = 0f;
    private float x, y, z, m1, m2, diastole, fix;

	// Use this for initialization
	void Start () {
        InitValues();
	}
	
    void InitValues() {
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;

        diastole = diastoleFactor * beatPeriod;
        m1 = (maxScaleFactor - 1f) / diastole;
        m2 = (1f - maxScaleFactor) / (beatPeriod - diastole);
        fix = applyF1(diastole) - (m2 *diastole);
    }

	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        var factor = getScaleFactor();
        Scale(factor);

        if (counter > beatPeriod)
            counter = 0f;
    }

    float getScaleFactor(){
        var factor = 1f;

        if (counter <= diastole)
            factor = applyF1(counter);
        else if (counter <= beatPeriod)
            factor = applyF2(counter);

        return factor;
    }

    float applyF1(float x){
        return m1 * x + 1f;
    }

    float applyF2(float x){
        return m2 * x + fix;
    }
        
    void Scale(float scaleFactor){
        gameObject.transform.localScale = new Vector3(x*scaleFactor, y*scaleFactor, z);
    }

    void ResetScale(){
        gameObject.transform.localScale = new Vector3(x, y, z);
    }
}
