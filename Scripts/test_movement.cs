using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {

	public GameObject player;
	public GameObject follow;
	public GameObject cannon;
	private Rigidbody rb;
	private float speed;
	private bool grounded;
	private Vector2 angleOrigin;

	// Use this for initialization
	void Start () {
		angleOrigin = new Vector2(1, 0);
		grounded = true;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		//shifts speed depending on whether left shift is pressed or not
		speed = Input.GetKey(KeyCode.LeftShift) ? 15 : 10;
			
		// calculates where the follow object should be
		if(Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0){
			follow.transform.localPosition = new Vector3 (Input.GetAxis ("Horizontal"), 0,
				Input.GetAxis ("Vertical")).normalized;
		}

		// rotates tank cannon accordingly
		if(Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0){
			float flip = Input.GetAxis("Vertical") > 0 ? -1 : 1;
			Vector2 angleRotate = new Vector2 (follow.transform.localPosition.x, follow.transform.localPosition.z);
			float angle = flip * Vector2.Angle(angleOrigin, angleRotate);
			cannon.transform.eulerAngles = new Vector3(0, angle, 0);
		}
		else{
			cannon.transform.eulerAngles = new Vector3(0, cannon.transform.eulerAngles.y, 0);
		}

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
		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			rb.AddForce(0, 30, 0, ForceMode.Impulse);
		}
	}

	//ground check for jumping
	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.tag == "ground"){
			grounded = true;
		}
	}

	void OnCollisionExit(Collision coll){
		if(coll.gameObject.tag == "ground"){
			grounded = false;
		}
	}
}
