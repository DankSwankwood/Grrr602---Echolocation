using UnityEngine;
using System.Collections;
 
public class Rotate : MonoBehaviour {
    
	public GameObject human;
	ZigSkeleton skeletonScript;
	Vector3 torsoZ;
	Vector3 torsoForward;
	float rotationAmount = 0.1f;
	float rotationAmountFwd = 2.0f;

	Vector3 previous;
	float velocity;
	float posY;
	float gravityDownY = -0.2f;
	float gravityUpY = 1.0f;

    // Use this for initialization
    void Start ()
    {
		skeletonScript = human.GetComponent<ZigSkeleton>();

		//Initilizing the gravity vector
		Physics.gravity = new Vector3(0.0f,gravityDownY,0.0f);
		posY = transform.position.y;

    }
 
    // Update is called once per frame
    void Update ()
    {
		//Rotates the body left and right depending sideways movement of the user
		torsoZ = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, skeletonScript.Torso.transform.localEulerAngles.z);
		if(torsoZ.z>180){
			torsoZ.z = torsoZ.z-360;
		}
		transform.Rotate(0, -torsoZ.z * rotationAmount, 0);

		//Rotate forward (forward and backwards leaning)
		torsoForward = new Vector3(skeletonScript.Torso.transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
		//Debug.Log(torsoForward.x);
		if(torsoForward.x>180){
			torsoForward.x = torsoForward.x-360;
		}
		transform.Rotate(torsoForward.x * rotationAmountFwd, 0, 0);
		//Debug.Log(torsoZ.z);

		//Defining the speed/velocity of the right hand
		velocity =  ((skeletonScript.RightHand.transform.position - previous).magnitude) / Time.deltaTime;
		previous = skeletonScript.RightHand.transform.position;
		Debug.Log(velocity);
		
		//Giving the gameobject updrift depending on the velocity of the right hand
		if (velocity > 2.0f) {
			
			Physics.gravity = new Vector3 (0.0f, gravityUpY, 0.0f);
			posY = posY - 2.0f;	
		} else {
			Physics.gravity = new Vector3(0.0f,gravityDownY,0.0f);		
		}
	}
 
}
 
