using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {

    private SteamVR_TrackedController controller;
    private SteamVR_Controller.Device device;

    // Use this for initialization
    void Start () {
        controller = this.GetComponent<SteamVR_TrackedController>();
        device  = SteamVR_Controller.Input((int)controller.controllerIndex);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Velocity X: " + device.velocity.x + " --- Velocity Y: " + device.velocity.y + " --- Velocity Z: " + device.velocity.z);
        // lenken mit Z achse zwischen -10 & 10
        // bremsen wenn X achse grösser als -30
        Debug.Log(this.transform.eulerAngles.z);
	}
}
