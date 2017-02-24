using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {

	public GameObject player;
	public Vector3 offset = new Vector3(0, -1, 5);
	private Camera mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera>();
		mainCamera.transform.position = player.transform.position - offset;
		mainCamera.transform.LookAt(player.transform);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		mainCamera.transform.position = player.transform.position - offset;
//		mainCamera.transform.LookAt(player.transform);
//		Debug.Log (player.transform.position - offset);
	}
}
