using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public NavMeshAgent agent;
	public GameObject player;
	public Rigidbody rb;

	// Use this for initialization
	void Start(){
		agent = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if(Mathf.Abs(this.transform.position.y - player.transform.position.y) < 1){
			agent.SetDestination(player.transform.position);
		}
		else{
			agent.SetDestination (Vector3.zero);
		}
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.CompareTag("bouncer")){
			print ("WOW");
			agent.Stop();
			rb.AddRelativeForce(0, 30f, 0, ForceMode.Impulse);
			agent.Resume();
		}
	}
}
