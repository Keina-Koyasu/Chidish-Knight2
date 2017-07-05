/*
using UnityEngine;
using System.Collections;

public class weaponyaru : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider collider) { 
		Debug.Log (collider.gameObject.name);
		if (collider.gameObject.tag == "Enemy") {
			collider.gameObject.GetComponent<Enemy> ().hit ();
			//collider.gameObject.SetActive (false);
		}

		if (collider.gameObject.tag == "father") {
			collider.gameObject.GetComponent<father> ().hit ();
			//collider.gameObject.SetActive (false);
		}
		if (collider.gameObject.tag == "C_boss") {
			collider.gameObject.GetComponent<C_boss> ().hit ();

		}
	}
	// Update is called once per frame
	void Update () {
	}
}
*/