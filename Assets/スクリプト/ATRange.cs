using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATRange : MonoBehaviour {

	public GameObject Tamashibi;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) { 
		//Debug.Log (collider.gameObject.tag);
		if (collider.gameObject.tag == "Player") {
			//collider.gameObject.GetComponent<Enemy> ().hit ();
			Tamashibi.GetComponent<Tamashibi_AI3>().Attack();
			//GetComponent<Dialogtimer> ().Show ();

		}
	}
}
