using UnityEngine;
using System.Collections;

public class Enemyattack : MonoBehaviour {
	public float attack = 10f;  //攻撃力
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
			collider.gameObject.SendMessage("hit", attack);   //相手の"Damage"関数を呼び出す
			//hit.gameObject.SendMessage("Damage", attack);   //相手の"Damage"関数を呼び出す
		}
		}
	}





