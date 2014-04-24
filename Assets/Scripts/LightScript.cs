using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

	public Rigidbody lightProjectile;
	public Rigidbody clone;
	public Rigidbody micClone;

	public GameObject lightChangeObj;

	public float lightSpeed;
	public float lightTime;
	public float lightIncrease;
	public float lightIntenseIncrease;

	public GameObject audioInputObject;
	public float threshold = 1.0f;
	MicrophoneInput micIn;
	public float micLoudness;

	void Awake() {

		lightTime = 3.0f;
		lightIncrease = 20.0f;
		lightIntenseIncrease = 10;
	}

	// Use this for initialization
	void Start () {
		//Hides the mouse cursor
		Screen.showCursor = false;

		if (audioInputObject == null)
			audioInputObject = GameObject.Find("MicMonitor");
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput");
	}

	// Update is called once per frame
	void Update () {

		micLoudness = micIn.loudness; // Sets float to be equal to michrophones loudness 
		if (micLoudness > threshold)  // Check if loudness exeeds threshold, and instanciate a lightwave if it does
		{
			micClone = Instantiate(lightProjectile, transform.position, transform.rotation) as Rigidbody;
			//SPEED OF SOUND
			//micClone.velocity = transform.TransformDirection(Vector3.forward * (1255 / 3.6f));
			//DEFINED SPEED - Mostly for testing
			micClone.velocity = transform.TransformDirection(Vector3.forward * 90);

			micClone.light.intensity = micIn.loudness;
			micClone.light.range = micIn.loudness;

			//Debug.Log("range: " + micClone.light.range + "      intensity: " + micClone.light.intensity + "    speed: " + lightSpeed);


			//Destroy(micClone.gameObject, lightTime);

//			if(micClone.transform.position.y<0){
//				Destroy(micClone.gameObject);
//			}
		}


//		if (Input.GetMouseButtonDown(0)){ // Mouseclick, instanciate lightwave 
//			//Debug.Log("museclick");
//
//			clone = Instantiate(lightProjectile, transform.position, transform.rotation) as Rigidbody;
//			//clone.velocity = transform.TransformDirection(Vector3.forward * lightSpeed);
//			clone.velocity = transform.TransformDirection(Vector3.forward * 1255 / 3.6f);
//			Destroy(clone.gameObject, lightTime);
//			
//			if(clone.transform.position.y<0){
//				Destroy(clone.gameObject);
//			}
//			
//		}


		// Following two will check if lightwave exists. If so, their intensity and range will increase
		// They do the same but mic and mouse instancites different waves.
		// MICROPHONE CLONE
		if(micClone){
			micClone.light.range += lightIncrease * Time.deltaTime;
			micClone.light.intensity += lightIntenseIncrease * Time.deltaTime;
			//Debug.Log("range: " + micClone.light.range + "      intensity: " + micClone.light.intensity + "    speed: " + lightSpeed);
		}

//		// MOUSE CLONE
//		if(clone){
//			clone.light.range += lightIncrease * Time.deltaTime;
//			clone.light.intensity += lightIntenseIncrease * Time.deltaTime;
//			//Debug.Log("range: " + clone.light.range + "      intensity: " + clone.light.intensity + "    speed: " + lightSpeed);
//		}

			
		
	}






	

}