using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		moveSpeed = 4.0f;
	
	}
	
	// Update is called once per frame
	void Update() {
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);	

		}
	}

