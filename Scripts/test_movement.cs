using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {

	public GameObject player;
	public GameObject follow;
	private Rigidbody rb;
	public float speed;
	public bool grounded;

	// Use this for initialization
	void Start () {
		grounded = true;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift)){
			speed = 15;
		}
		else{
			speed = 10;
		}
		// calculates where the follow object should be
		float distPosX = Input.GetAxis("Horizontal") / Mathf.Sqrt(1 + Mathf.Abs(Input.GetAxis("Vertical")));
		float distPosZ = Input.GetAxis("Vertical") / Mathf.Sqrt(1 + Mathf.Abs(Input.GetAxis("Horizontal")));
		follow.transform.localPosition = new Vector3 (distPosX, 0, distPosZ);

		// calculates velocity by comparing the difference between the object
		Vector3 difference = follow.transform.position - player.transform.position;
		Vector3 direction = new Vector3(speed * difference.x, rb.velocity.y, speed * difference.z);

		// sets speed to the difference or lerps it to 0
		if(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0){
			rb.velocity = direction;
		}
		else{
			rb.velocity = Vector3.Slerp (rb.velocity, new Vector3(0, rb.velocity.y, 0), Time.deltaTime);
		}

		// space => jump
		if(Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(0, 30, 0, ForceMode.Impulse);
		}
	}

//  TO DO!
//	void OnCollisionEnter(){
//	}
}
