using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

	RaycastHit hit = new RaycastHit();
	MicrophoneInput micIn;
	public GameObject audioInputObject;


	// Use this for initialization
	void Start () {
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("MicMonitor");
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput");
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
		
		if (Physics.Raycast (ray, out hit, 100)) {
			print("OBJECT HIT!");
			// TEST - 19/4-14 - NOT TRIED YET
//			Instantiate(GameObject.Find("LightPrefab"), transform.position, transform.rotation) as Rigidbody;
			micIn.audio.Play();
		}
	}
}
