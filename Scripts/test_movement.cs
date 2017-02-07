using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		Debug.Log (rb.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
