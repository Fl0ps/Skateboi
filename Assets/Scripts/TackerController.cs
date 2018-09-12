using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackerController : MonoBehaviour {

	public PlayerMovement pm;

	private int deltaTime;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += 1;
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("FWB")){
			deltaTime = 0;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("BWB")){
			if (deltaTime <= 50) {
				float i = Map (deltaTime, 50f, 5f, 0.5f, 4f);
				Debug.Log (i);
				pm.AddSpeed (i);
			}
		}
	}

	private float Map(float s, float a1, float a2, float b1, float b2){
		return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
	}
}
