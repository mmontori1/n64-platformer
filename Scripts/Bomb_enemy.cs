using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb_enemy : MonoBehaviour {

	public NavMeshAgent agent;
	public GameObject player;
	public Rigidbody rb;
	private Vector3 origin;
	public bouncer platform;

	// Use this for initialization
	void Start(){
		agent = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody>();
		origin = this.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate(){
		if(platform.contact){
			print (player.transform.position);
			agent.SetDestination(player.transform.position);
		}
		else{
			agent.SetDestination(origin);
		}
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.CompareTag("Player")){
		}
	}
}
