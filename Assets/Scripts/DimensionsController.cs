using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DimensionsController : MonoBehaviour {

	private enum dimensions  {
		blue,
		red
	};

	private int currentDimension;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void ChangeToNextDimension(){
        currentDimension = (currentDimension + 1) % GetDimensionsNumber();
	}

	public int GetDimensionsNumber() {
		return System.Enum.GetNames(typeof(dimensions)).Length;
	}

	public int GetCurrentDimension(){
		return currentDimension;
	}

	public bool IsBlueDimension(){
        return currentDimension == (int)dimensions.blue;
	}

	public bool IsRedDimension(){
        return currentDimension == (int)dimensions.red;
	}
}
