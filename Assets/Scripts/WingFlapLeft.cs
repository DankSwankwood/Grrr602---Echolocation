using UnityEngine;
using System.Collections;

public class WingFlapLeft : MonoBehaviour {

	public GameObject human;
	
	ZigSkeleton skeletonScript;
	Vector3 wingZ;
	float rotationAmount = 0.1f;
	Vector3 torsoZ;
	Vector3 tempZ;

	// Use this for initialization
	void Start () {
		skeletonScript = human.GetComponent<ZigSkeleton>();
	}
	
	// Update is called once per frame
	void Update () {
		//Rotates the body left and right depending sideways movement of the user
		wingZ = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, skeletonScript.LeftShoulder.transform.localEulerAngles.z);
		//tempZ = skeletonScript.RightShoulder.transform.localEulerAngles.z;
		transform.localEulerAngles = -tempZ;
		tempZ = wingZ;
	}
}
