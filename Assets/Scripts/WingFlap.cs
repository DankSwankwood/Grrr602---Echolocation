using UnityEngine;
using System.Collections;

public class WingFlap : MonoBehaviour {

	public GameObject human;
	public GameObject wingMoFo;

	ZigSkeleton skeletonScript;
	Vector3 wingZ;
	float rotationAmount = 0.1f;

	Vector3 tempX;

	Vector3 torsoZ;

	// Use this for initialization
	void Start () {
		skeletonScript = human.GetComponent<ZigSkeleton>();
	}
	
	// Update is called once per frame
	void Update () {
		//Rotates the body left and right depending sideways movement of the user
		wingZ = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, skeletonScript.Torso.transform.localEulerAngles.z);
		if(wingZ.z>180){
			wingZ.z = wingZ.z-360;
		}

		if (transform.rotation.eulerAngles.x > -35) {
			Quaternion rot = new Quaternion();
			rot.eulerAngles = new Vector3(-35, 0, 0);
			transform.rotation = rot;
		} else if (transform.rotation.eulerAngles.x < 35) {
			Quaternion rot = new Quaternion();
			rot.eulerAngles = new Vector3(35, 0, 0);
			transform.rotation = rot;
		}

		transform.Rotate(wingZ.z * rotationAmount, 0, 0);

//		wingX = new Vector3(skeletonScript.RightHand.transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
//		if(wingX.x>180){
//			wingX.x = wingX.y-360;
//		}
//		transform.Rotate(wingX.x * rotationAmount, 0, 0);
//		Debug.Log("WINGS: " + wingX.x);
	}
}
