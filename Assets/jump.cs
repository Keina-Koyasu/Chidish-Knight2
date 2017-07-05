using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {
	public float power;
	private bool isGrounded; //着地判定
	public LayerMask groundLayer; //Linecastで判定するLayer

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 2.75f,
			groundLayer);
		if(Input.GetKeyDown(KeyCode.Space)){
			gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.up * power);
		}
		if(Input.GetKeyDown("w")){
			gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.right * power);	
		}
	}
}
