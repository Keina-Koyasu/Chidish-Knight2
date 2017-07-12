using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kakashi : MonoBehaviour {
	public GameObject message;
	public GameObject hero;

	public float maxLife = 30;    //最大体力（readonlyは変数の変更ができなくなるらしい）
	public float Life = 30;    //現在体力

	public float xp = 0;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	public void hit(float damage){
		Life -= damage; //体力を減らす
		if (Life > 0) {
			gameObject.layer = LayerMask.NameToLayer ("PlayerDamage");
			Invoke ("muteki", 2.5f);
		} else {
			if (Life < 0) {
				anim.SetTrigger ("die");
				Invoke ("dead", 0.8f);
			}
		}
	}
	void muteki(){
		//レイヤーをCharacterに戻す
		gameObject.layer = LayerMask.NameToLayer("Enemy");
		//isGrounded = true;
	}
		
	void dead(){
		Destroy(this.gameObject);
		hero.gameObject.SendMessage("EXPin", xp); 

	}
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			//StartCoroutine ("messagein");

		}
	}
	//IEnumerator messagein(){
		
	//}
	// Update is called once per frame
	void Update () {
		
	}
}

