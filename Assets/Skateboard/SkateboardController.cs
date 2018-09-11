using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardController : MonoBehaviour {

    public GameObject frontTruck;
    public GameObject backTruck;
    public GameObject board;
    public float maxSteeringAngle = 15.0f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        frontTruck.transform.eulerAngles = new Vector3(0, -rotation * maxSteeringAngle, 0);
        backTruck.transform.eulerAngles = new Vector3(0, rotation * maxSteeringAngle, 0);
        board.transform.eulerAngles = new Vector3(0, 0, rotation * maxSteeringAngle);
    }
}
