using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncer : MonoBehaviour {

	public bool contact;

	// Use this for initialization
	void Start () {
		contact = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.CompareTag("Player")){
			contact = true;
		}
	}

	void OnCollisionExit(Collision coll){
		if(coll.gameObject.CompareTag("Player")){
			contact = false;
		}
	}
}
