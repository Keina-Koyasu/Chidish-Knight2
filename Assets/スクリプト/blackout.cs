using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class blackout : MonoBehaviour {
	public GameObject sousa;
	public GameObject tutorial;
	public GameObject hero;
	public GameObject text;

	float alfa;
	public float speed = 0.9f;
	float red, green, blue;
	public bool fedein = false;
	//public GameObject  E_message;
	//public GameObject player;


	void Start () {
		red = GetComponent<Image>().color.r;
		green = GetComponent<Image>().color.g;
		blue = GetComponent<Image>().color.b;
	}
	public void fede1(){
		fedein = true;
	}
	void DelayMethod(){
		StartCoroutine ("tuto");
		Invoke("DelayMethod2", 2.0f);


	}
	void DelayMethod2(){
		Application.LoadLevel ("scene1");

	}

	IEnumerator tuto(){
		tutorial.SetActive (true);
		//while文を7回ループ
		int count = 100;
		while (count > 0){
			//0.05秒待つ
			yield return new WaitForSeconds(1.00f);
			hero.GetComponent<Animator> ().SetBool ("attack",true);
			text.GetComponent <Text>().text = "RTボタンで攻撃ができる";
			yield return new WaitForSeconds(1.00f);
			hero.GetComponent<Animator> ().SetBool ("attack",false);
			text.GetComponent <Text>().text = "RTボタンで攻撃ができる";
			yield return null;
			count--;

		}
	}
	void Update () {
		if (fedein) {
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += speed;
			//DelayMethodを3.5秒後に呼び出す
			Invoke("DelayMethod", 2.0f);
		}

	}
}