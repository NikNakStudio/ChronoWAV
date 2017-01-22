using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DimensionController : MonoBehaviour {

    public Dimension redDimension;
    public Dimension blueDimension;

	public enum dimensions  {
		blue,
		red
	};

	private Dimension currentDimension;

	// Use this for initialization
	void Start () {
        currentDimension = blueDimension;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Dimension ChangeToNextDimension(){
        currentDimension = IsBlueDimension() ? redDimension : blueDimension;
        return currentDimension;
	}

    public Dimension ChangeDimension(dimensions dimension){


        switch (dimension)
        {
            case dimensions.red:
                if (!IsRedDimension())
                    currentDimension = redDimension;
                break;
            case dimensions.blue:
                if (!IsBlueDimension())
                    currentDimension = blueDimension;
                break;
        }
        return currentDimension;
    }

	public int GetDimensionsNumber() {
		return 2;
	}

	public Dimension GetCurrentDimension(){
		return currentDimension;
	}

	public bool IsBlueDimension(){
        return currentDimension == blueDimension;
	}

	public bool IsRedDimension(){
        return currentDimension == redDimension;
	}
}
