using UnityEngine;
using System.Collections;

public class WavePlotter : MonoBehaviour {

	public GameObject plotPointObject;
	public GameObject plotHeaderObject;
	public int numberOfPoints= 100;
	public float animSpeed =1.0f;
	public float scaleInputRange = 2*Mathf.PI; // scale number from [0 to 99] to [0 to 2Pi]
	public float scaleResult = 10.0f;
	public float frecuency = 1;
	public bool animate = true;
	public float motionSpeed = 0;
	private float lastX = 0;
	private float lastY = 0;
	private int counter = 0;


	GameObject[] plotPoints;

	// Use this for initialization
	void Start () {
		//motionSpeed = animSpeed / 10.0f;
		if (plotPointObject == null) //if user did not fill in a game object to use for the plot points
			plotPointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere); //create a sphere

		plotPoints = new GameObject[numberOfPoints]; //creat an array of 100 points.

		for (int i = 0; i < numberOfPoints; i++)
		{
			GameObject gameObject = i != numberOfPoints - 1 ? plotPointObject : plotHeaderObject;
			plotPoints[i] = (GameObject)GameObject.Instantiate(gameObject, new Vector3(i - (numberOfPoints), 0, 0), Quaternion.identity); //this specifies what object to create, where to place it and how to orient it
		}
				
		//we now have an array of 100 points- your should see them in the hierarchy when you hit play
		plotPointObject.SetActive(false); //hide the original

	}

	// Update is called once per frame
	void Update()
	{
		frecuency = Input.anyKey ? 2 : 1;
					
		if (counter != 0)
			counter--;
		
		for (int i = 0; i < numberOfPoints; i++)
		{
			float functionXvalue = i * scaleInputRange / numberOfPoints; // scale number from [0 to 99] to [0 to 2Pi]
			if (animate) {
				functionXvalue += Time.time * animSpeed;
			}
			var x = plotPoints [i].transform.position.x + motionSpeed;
			plotPoints [i].transform.position = new Vector2 (x + lastX, lastY + ComputeFunction (functionXvalue) * scaleResult);
		}
	}
	private float ComputeFunction(float x)
	{
		return Mathf.Sin(frecuency*x);
	}

	public GameObject GetWaveHeader(){
		return plotPoints [numberOfPoints - 1];
	}
}