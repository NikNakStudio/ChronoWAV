using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public DimensionController dimensionController;
    public GameObject mainCamera;
    public float verticalLimit;
    public float secondsToRegenerate = 2;


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
    private float timeCounter = 0;
    private bool animate = true;
    private bool needToFixY = false;
    private AudioSource dimensionSource;
	private ReachEnd end;

	// Use this for initialization
	void Start () {

        currentDimension = dimensionController.GetCurrentDimension();
        MapDimension(currentDimension);

		plotPoints = new GameObject[numberOfPoints]; //creat an array of 100 points.

		for (int i = 0; i < numberOfPoints - 1; i++)
		{
           
            plotPoints[i] = (GameObject)GameObject.Instantiate(tailWaveObject, new Vector3(i - (numberOfPoints), 0, 0), Quaternion.identity); //this specifies what object to create, where to place it and how to orient it
		}

        plotPoints[numberOfPoints - 1] = headerWaveObject;

        tailWaveObject.SetActive(false);
        dimensionSource = GameObject.Find("DimensionSource").GetComponent<AudioSource>();
		end = GameObject.Find ("End").GetComponent<ReachEnd> ();
	}

	// Update is called once per frame
	void Update()
	{
        int blockedPoints = 0;
        /*if (timeCounter < secondsToRegenerate)
        {
            timeCounter += Time.deltaTime;
            blockedPoints = (int)(numberOfPoints - (numberOfPoints * timeCounter / secondsToRegenerate));
            Debug.Log("timeCounter: " + timeCounter);
            Debug.Log("Puntos bloqueados: " + blockedPoints);
        }*/

		if (end.Ended) {
			Application.LoadLevel ("Credits");
		}

        CheckInput();

		for (int i = 0; i < numberOfPoints; i++)
		{
            var isBlocked = i < blockedPoints;
            var position = CalculateNextPosition(i, isBlocked);
            plotPoints[i].transform.position = position;

		}
	}

    private void CheckInput(){
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
    }

    private Vector2 CalculateNextPosition(int pointIndex, bool isBlocked){
        float functionXvalue = pointIndex * scaleInputRange / numberOfPoints; // scale number from [0 to 99] to [0 to 2Pi]
        if (animate) {
            functionXvalue += Time.time * animSpeed;
        }

        if(needToFixY){
            needToFixY = false;
            var origin = GetWaveHeader().transform.position.y;
            var destiny = (ComputeFunction (functionXvalue) * scaleResult);
            yFix = origin - destiny ;
        }
            
        var x = plotPoints [pointIndex].transform.position.x + motionSpeed;
        var y = plotPoints[pointIndex].transform.position.y;

        if (!isBlocked)
        {
            y = yFix + ComputeFunction(functionXvalue) * scaleResult;
            y = CheckYLimit(y);
        }
        return new Vector2(x, y);
    }

	private float ComputeFunction(float x)
	{
        return Mathf.Sin(frecuency * x);
	}

    private float CheckYLimit(float y){
        if (y > verticalLimit)
            y = verticalLimit;
        else if (y < -verticalLimit)
            y = -verticalLimit;
        return y;
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
            Debug.Log(dimensionSource);
            dimensionSource.Play();
            MapDimension(nextDimension);
            needToFixY = true;
            cameraComponent.backgroundColor = nextDimension.backgroundColor;
            timeCounter = 0;
        }
    }

    public void MuteMusic(){
        var header = GetWaveHeader();
        var source = header.GetComponent<AudioSource>();
        source.volume = 0;
    }
}