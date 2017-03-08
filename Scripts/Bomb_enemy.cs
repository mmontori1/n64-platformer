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
	void Update(){
		if(platform.contact && (Mathf.Abs(this.transform.position.y - player.transform.position.y) < .5)){
			agent.SetDestination(new Vector3(player.transform.position.x, 
				this.transform.position.y, player.transform.position.z));
		}
		else{
			agent.SetDestination(origin);
		}
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.CompareTag("Player")){
			Destroy (this.gameObject);
		}
	}
}
