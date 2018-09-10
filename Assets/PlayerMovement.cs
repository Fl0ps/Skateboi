using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject controller;
	private SteamVR_TrackedController controllerScript;
	private SteamVR_Controller.Device device;

	private float speed;
	private float neigung;




	// Use this for initialization
	void Start () {
		controllerScript = controller.GetComponent<SteamVR_TrackedController>();
		device  = SteamVR_Controller.Input((int)controllerScript.controllerIndex);
		speed = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			speed += 1;
		}

		neigung = controller.transform.eulerAngles.z;
		if (neigung > 180) {
			neigung = neigung - 360;
		}

		if (speed > 0) {
			//Get forward vector of skateboard and set y direction to 0
			Vector3 fwd = controller.transform.forward;
			fwd.y = 0;

			//set the new position times the speed and a damper
			transform.position += fwd * speed * 0.01f;
			//rotate the camera rig according to the neigung
			transform.RotateAround (this.transform.position, Vector3.up, -neigung * 0.05f);

			//reduce the speed each frame
			speed -= 0.005f;
		}
	}
}
