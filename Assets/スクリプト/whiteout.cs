/*
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class whiteout : MonoBehaviour {
	float alfa;
	public float speed = 0.9f;
	float red, green, blue;
	public bool fedein = false;
	public GameObject  E_message;
	public GameObject player;


	void Start () {
		red = GetComponent<Image>().color.r;
		green = GetComponent<Image>().color.g;
		blue = GetComponent<Image>().color.b;
	}
	public void fede1(){
		fedein = true;
	}
	void DelayMethod(){
		E_message.SetActive (true);
		player.GetComponent<FPScommond> ().enabled = false;
	}
		
	void Update () {
		if (fedein) {
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += speed;
			//DelayMethodを3.5秒後に呼び出す
			Invoke("DelayMethod", 5.0f);
		}
		if(E_message.activeSelf == true){
			if(Input.GetButtonDown ("chack") || Input.GetKeyDown (KeyCode.H)||Input.GetKeyDown ("q") || Input.GetButtonDown ("start")){
				Application.LoadLevel ("titl");
			}
			
		}
	}
}
*/