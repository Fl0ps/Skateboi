using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardController : MonoBehaviour {

    public PlayerMovement pm;

    private bool braked = false;
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

        //frontTruck.transform.eulerAngles = new Vector3(0, -rotation * maxSteeringAngle, 0);
        //backTruck.transform.eulerAngles = new Vector3(0, rotation * maxSteeringAngle, 0);
        //board.transform.eulerAngles = new Vector3(0, 0, rotation * maxSteeringAngle);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            if (!braked)
            {
                Debug.Log("touched the border");
                pm.Stop();
                braked = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            braked = false;
        }
    }
}
