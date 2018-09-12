using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject controller;
	public AudioSource skateSound;

    private SteamVR_TrackedController controllerScript;
	private SteamVR_Controller.Device device;

	private float speed;
	private float neigung;
    private float lastNeigung;
	private float breakSpeed;




	// Use this for initialization
	void Start () {
		controllerScript = controller.GetComponent<SteamVR_TrackedController>();
		device  = SteamVR_Controller.Input((int)controllerScript.controllerIndex);
        skateSound.loop = true;
		speed = 0.0f;
		breakSpeed = 0.002f;

        //neigung = lastNeigung = 0f;
	}

	// Update is called once per frame
	void Update () {

        //Debug.Log("is playing sound: " + skateSound.isPlaying);
		if(Input.GetKeyDown(KeyCode.Space)){
			speed += 1;
		}

		neigung = controller.transform.eulerAngles.z;
		if (neigung > 180) {
			neigung = neigung - 360;
		}

        //Debug.Log("actual neigung is: " + neigung);
        neigung = (lastNeigung + neigung) / 2;
        //Debug.Log("damped neigung is: " + neigung);
        lastNeigung = neigung/5;

        if (controller.transform.eulerAngles.x <= 330) {
			breakSpeed = breakSpeed * 10f;
		} else {
			breakSpeed = breakSpeed / 10f;
		}

		if (speed > 0) {

            if (!skateSound.isPlaying)
            {
                skateSound.Play(0);
                skateSound.time = 0f;
                //Debug.Log("started playing");
            }

            //Get forward vector of skateboard and set y direction to 0
            Vector3 fwd = controller.transform.forward;
			fwd.y = 0;

			//set the new position times the speed and a damper
			transform.position += fwd * speed * 0.01f;
            //rotate the camera rig according to the neigung

			transform.RotateAround (this.transform.position, Vector3.up, -neigung * 0.1f);

			//reduce the speed each frame
			speed -= breakSpeed;
		} else {
            if (skateSound.isPlaying)
            {
                //skateSound.Pause ();
                skateSound.Stop();
                //skateSound.time = 0;
                //Debug.Log("stopped playing...");
            }
		}
	}

	public void AddSpeed(float speed){
		this.speed += speed;
	}

    public void Stop()
    {
        this.speed = 0f;
    }
}
