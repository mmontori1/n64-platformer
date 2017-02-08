using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {

	public GameObject player;
	public GameObject follow;
	private Rigidbody rb;
	public float speed;
	public float playerRotation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 difference = follow.transform.position - player.transform.position;
		Vector3 direction = new Vector3(Input.GetAxis("Vertical") * speed * difference.x, 
			rb.velocity.y, Input.GetAxis("Vertical") * speed * difference.z);
		player.transform.Rotate(Vector3.up * Input.GetAxis ("Horizontal") * 2f);
		if(Input.GetAxisRaw("Vertical") != 0){
			rb.velocity = direction;
		}
		else{
			rb.velocity = Vector3.Slerp (rb.velocity, new Vector3(0, rb.velocity.y, 0), 1);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			Debug.Log ("WHAT");
			rb.AddForce(0, 30, 0, ForceMode.Impulse);
		}
//		else{
//			rb.velocity = rb.velocity;
//		}

//		rb.velocity = speed * Input.GetAxis("Vertical") * 



//		Debug.Log (Input.GetAxis("Vertical") * Vector3.MoveTowards (player.transform.position, follow.transform.position, 1f));
//		Debug.Log(follow.transform.position);
//		player.transform.position = Input.GetAxis("Vertical") * Vector3.MoveTowards (player.transform.position, 
//			follow.transform.position, 10f);
//		follow.transform.position = new Vector3(5 * Mathf.Sin(Input.GetAxis("Horizontal")), 
//			follow.transform.position.y, 5 * Mathf.Cos(Input.GetAxis("Horizontal")));
//		speed = Input.GetAxis("Vertical") * 20;
//		playerRotation = player.transform.rotation.y + Input.GetAxis("Horizontal");
//		rb.velocity = new Vector3(speed * Input.GetAxis("Horizontal"), rb.velocity.y, speed * Input.GetAxis("Vertical"));
//		if(Input.GetAxisRaw("Horizontal") != 0){
//			player.transform.rotation = new Quaternion (player.transform.rotation.x, 
//				player.transform.rotation.y * Mathf.PI / 180 + Input.GetAxis ("Horizontal") * Mathf.PI/2, 
//				player.transform.rotation.z, player.transform.rotation.w);
//		}
//		else{
//			player.transform.rotation = new Quaternion (player.transform.rotation.x, 
//				player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
//		}
//		playerRotation = 0;
//
//		Debug.Log (player.transform.rotation.y + Input.GetAxis("Horizontal"));
	}
}
