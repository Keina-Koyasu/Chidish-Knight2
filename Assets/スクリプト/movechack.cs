using UnityEngine;
using System.Collections;

public class movechack : MonoBehaviour {

	public GameObject sikaku;
	public Vector2 SPEED = new Vector2(0.05f, 0.05f); //移動スピード　xy
	public bool key1 = false; //鍵のフラグ 


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// 移動処理
		Move();
		if (Input.GetKeyDown ("q")) {
			if (sikaku.activeSelf == true) {
				sikaku.SetActive (false);
				key1 = true;
			} else {
				sikaku.SetActive (true);
				key1 = false;
			}
		
		}
	}

	// 移動関数
	void Move(){
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if(Input.GetKey("left")){
			// 代入したPositionに対して加算減算を行う
			Position.x -= SPEED.x;
		} else if(Input.GetKey("right")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.x += SPEED.x;
		} else if(Input.GetKey("up")){ // 上キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y += SPEED.y;
		} else if(Input.GetKey("down")){ // 下キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.y -= SPEED.y;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}


}