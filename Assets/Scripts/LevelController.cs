using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public DimensionController dimensionController;
    public GameObject mainCamera;
    public float verticalLimit;

    private GameObject tailWaveObject;
    private GameObject headerWaveObject;
    private GameObject[] plotPoints;

    private Dimension currentDimension;
    private int numberOfPoints= 100;
    private float animSpeed =1.0f;
    private float scaleInputRange = 2*Mathf.PI; // scale number from [0 to 99] to [0 to 2Pi]
    private float scaleResult = 10.0f;
    private float frecuency = 1;
    private float motionSpeed = 0;
    private float yFix = 0;
    private bool animate = true;

	// Use this for initialization
	void Start () {

        currentDimension = dimensionController.GetCurrentDimension();
        MapDimension(currentDimension);

		plotPoints = new GameObject[numberOfPoints]; //creat an array of 100 points.

		for (int i = 0; i < numberOfPoints; i++)
		{
            GameObject gameObject = i != numberOfPoints - 1 ? tailWaveObject : headerWaveObject;
			plotPoints[i] = (GameObject)GameObject.Instantiate(gameObject, new Vector3(i - (numberOfPoints), 0, 0), Quaternion.identity); //this specifies what object to create, where to place it and how to orient it
		}

        headerWaveObject.SetActive(false);
        tailWaveObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
        if (Input.anyKey)
        {
            if(Input.GetKeyDown(KeyCode.Escape)){
                Application.LoadLevel("Title");
            }
            else
                ChangeDimension(DimensionController.dimensions.red);
        }
        else
        {
            ChangeDimension(DimensionController.dimensions.blue);
        }
		
		for (int i = 0; i < numberOfPoints; i++)
		{
			float functionXvalue = i * scaleInputRange / numberOfPoints; // scale number from [0 to 99] to [0 to 2Pi]
			if (animate) {
				functionXvalue += Time.time * animSpeed;
			}
			var x = plotPoints [i].transform.position.x + motionSpeed;
            var y = yFix + ComputeFunction(functionXvalue) * scaleResult;
            if (y > verticalLimit)
                y = verticalLimit;
            else if (y < -verticalLimit)
                y = -verticalLimit;
            
			plotPoints [i].transform.position = new Vector2 (x, y);
		}
	}
	private float ComputeFunction(float x)
	{
        return Mathf.Sin(frecuency * x);
	}

    private void MapDimension(Dimension dimension){
        currentDimension = dimension;
        tailWaveObject = dimension.tailWaveObject;
        headerWaveObject = dimension.headerWaveObject;
        numberOfPoints = dimension.numberOfPoints;
        animSpeed = dimension.animSpeed;
        scaleInputRange = dimension.scaleInputRange;
        scaleResult = dimension.scaleResult;
        frecuency = dimension.frecuency;
        animate = dimension.animate;
        motionSpeed = dimension.motionSpeed;
    }

	public GameObject GetWaveHeader(){
		return plotPoints [numberOfPoints - 1];
	}

    private void ChangeDimension(DimensionController.dimensions dimension){
        var nextDimension = dimensionController.ChangeDimension(dimension);
        var cameraComponent = mainCamera.GetComponent<Camera>();

        if (currentDimension != nextDimension)
        {
            var functionXvalue = (numberOfPoints-1) * scaleInputRange / numberOfPoints;
            yFix = GetWaveHeader().transform.position.y - (ComputeFunction (functionXvalue) * scaleResult);
            cameraComponent.backgroundColor = nextDimension.backgroundColor;

        }
        MapDimension(nextDimension);
    }

}