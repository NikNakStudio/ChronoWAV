using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {   
            if(Input.GetKeyDown(KeyCode.Escape)){
                Application.Quit();
            }
            else
            Application.LoadLevel("Level1");
        }
	}
}
