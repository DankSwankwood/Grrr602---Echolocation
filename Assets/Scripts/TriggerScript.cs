using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	public GameObject audioInputObject;
	MicrophoneInput micIn;

	// Use this for initialization
	void Start () {
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("MicMonitor");
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "PrefabLight") {
			micIn.audio.mute = false;
			micIn.audio.Play ();
			Destroy(other.gameObject);
		}
	}
}
