using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {

	public GameObject player;
	public GameObject follow;
	public GameObject cannon;
	public Camera camera;
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
//		Vector3 vec_1 = new Vector3 (-1, 0, 0);
//		Vector3 vec_2 = new Vector3(player.transform.position.x + Input.GetAxis ("Mouse X"), 0, 
//			player.transform.position.z + Input.GetAxis("Mouse Y"));
//		print (Mathf.Pow(player.transform.position.x + Input.GetAxis ("Mouse X"),2) + 
//			Mathf.Pow(player.transform.position.z + Input.GetAxis("Mouse Y"),2));
//		Vector3 vec_2 = camera.ScreenToWorldPoint(Input.mousePosition);
//		float angle = Mathf.Acos(vec_1.magnitude * vec_2.magnitude);
//		Debug.Log(Input.mousePosition);
//		Debug.Log (vec_2);
		// calculates where the follow object should be
		if(Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0){
			follow.transform.localPosition = new Vector3 (Input.GetAxis ("Horizontal"), 0,
				Input.GetAxis ("Vertical")).normalized;
		}
//		float angle = Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical");
//		if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
		float flip = Input.GetAxis("Vertical") > 0 ? -1 : 1;
			float angle = flip * Vector2.Angle(new Vector2(1, 0),
			new Vector2(follow.transform.localPosition.x, follow.transform.localPosition.z));
//			float angle = 360 * (Mathf.Atan2(follow.transform.position.y, follow.transform.position.x)) / (Mathf.PI * 2);
//			float angle = Vector3.Angle (origin, follow.transform.localPosition);
			cannon.transform.eulerAngles = new Vector3(0, angle, 0);
//		}
//		Vector3.RotateTowards (player.transform.position, follow.transform.position, Time.deltaTime, 0);

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

//  TO DO!
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
