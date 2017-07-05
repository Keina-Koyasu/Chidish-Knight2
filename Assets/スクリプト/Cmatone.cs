/*
using UnityEngine;
using System.Collections;

public class Cmatone : MonoBehaviour {
	public GameObject player ;
	// Use this for initialization
	void Start () {
	
	}
	hit.transform.gameObject.GetComponent<Animator> ().SetTrigger ("open");
	if (Input.GetKey ("left")) {
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log (GetComponent<Collider> ().gameObject.tag);
		if (collision.gameObject.tag == "PLayer") {
		}
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
	void DelayMethod(){
		
		player.GetComponent<FPScommond> ().enabled = false;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q") || Input.GetButtonDown ("start")) {
		}
	}



	player1.transform.position = new Vector3 (-61.67f, -7.05f, 18.17f);
		Application.LoadLevel (""); //ロード
		Invoke("DelayMethod", 5.0f); // 5.0後に呼び出す


}
*/