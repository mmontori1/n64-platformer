using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {

	public GameObject player;
	public GameObject follow;
	private Rigidbody rb;
	public float distPosX;
	public float distPosZ;
	public float speed;
	public float playerRotation;
	public bool grounded;

	// Use this for initialization
	void Start () {
		grounded = true;
		distPosX = 0;
		distPosZ = 0;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		float curLocX = follow.transform.localPosition.x;
		float curLocZ = follow.transform.localPosition.z;
		float changeX = 0;
		float changeZ = 0;
		if(Input.GetAxisRaw ("Vertical") != 0 && Input.GetAxisRaw ("Horizontal") != 0){
			changeX = 0.5f;
			changeZ = 0.5f;
		}
		else if(Input.GetAxisRaw("Vertical") != 0){
			changeZ = 1f;
		}
		else if(Input.GetAxisRaw("Horizontal") != 0){
			changeX = 1f;	
		}
//		distPosX = Mathf.Lerp(curLocX, changeX, 1f) * Mathf.Sin((Mathf.PI / 2) * Input.GetAxis("Horizontal"));
//		distPosZ = Mathf.Lerp(curLocZ, changeZ, 1f) * Mathf.Cos((Mathf.PI / 2) * Input.GetAxis("Vertical"));
//		distPosX = Mathf.Lerp(curLocX, changeX, 3 * Time.deltaTime) * Mathf.Abs(Input.GetAxis("Horizontal"));
//		distPosZ = Mathf.Lerp(curLocZ, changeZ, 3 * Time.deltaTime) * Mathf.Abs(Input.GetAxis("Vertical"));
//		distPosX = Mathf.Sin((Mathf.PI / 2) * Input.GetAxisRaw("Horizontal")) * Mathf.Abs(Input.GetAxis("Horizontal"));
//		distPosZ = Mathf.Sin((Mathf.PI / 2) * Input.GetAxisRaw("Vertical")) * Mathf.Abs(Input.GetAxis("Vertical"));
		distPosX = Input.GetAxisRaw("Horizontal");
		distPosZ = Input.GetAxisRaw("Vertical");
		follow.transform.localPosition = new Vector3 (distPosX, 0, distPosZ);
//		if(Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0){
//			//			follow.transform.position = new Vector3(5 * Mathf.Sin(Mathf.PI * Input.GetAxis("Horizontal")), 
//			//				follow.transform.position.y, 5 * Mathf.Cos(Mathf.PI * Input.GetAxis("Vertical")));
////			follow.transform.localPosition = new Vector3(5 * Mathf.Sin(Input.GetAxis("Horizontal")), 
////				0, 5 * Mathf.Cos(Input.GetAxis("Vertical")));
////			follow.transform.localPosition = new Vector3(5 * Input.GetAxis("Horizontal"), 0,
////				5 * Input.GetAxis("Vertical"));
////			float distPos = Mathf.Sqrt(Mathf.Pow(5 * Input.GetAxis("Horizontal"), 2)
////				+ Mathf.Pow(5 * Input.GetAxis("Horizontal"), 2));
//			follow.transform.localPosition = new Vector3(distPosX, 0, distPosZ);
//		}
//		else if(Input.GetAxisRaw("Vertical") != 0){
//			follow.transform.localPosition = new Vector3(0, 0, distPosZ);
//		}
//		else if(Input.GetAxisRaw("Horizontal") != 0){
//			follow.transform.localPosition = new Vector3(distPosX, 0, 0);
//		}
//		else{
//			follow.transform.localPosition = new Vector3 (0, 0, 0);
//		}
		Vector3 difference = follow.transform.position - player.transform.position;
//		Vector3 direction = new Vector3(Input.GetAxis("Horizontal") * speed * difference.x, 
//			rb.velocity.y, Input.GetAxis("Vertical") * speed * difference.z);
		Vector3 direction = new Vector3(speed * difference.x, rb.velocity.y, speed * difference.z);
		if(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0){
			rb.velocity = direction;
		}
		else{
			rb.velocity = Vector3.Slerp (rb.velocity, new Vector3(0, rb.velocity.y, 0), 1);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
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

//	void OnCollisionEnter(){
//		if
//	}
}
