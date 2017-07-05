using UnityEngine;
using System.Collections;

public class GameMasterScript : MonoBehaviour {
	//ゲーム内に登場する敵キャラクターのリストのpublicインスタンスメンバ
	public GameObject[] enemyList;
	//敵キャラきたー出現
	float energy = 0;
		//エネルギーがこれを超えると出現　出現頻度高めたければ少なめ　減らしたければ多め
	float LIMIT = 16;

	//最後にチェックしたときのｘ座標を記録するインスタンスメンバ
	float lastX = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		EnemyAppend ();
	}
	void EnemyAppend(){
		//メインカメラ取得
		Camera camera = Camera.main;
		//カメラのｘ座標を取得
		float nowX = camera.transform.position.x;
		//前フレームでチェックしたｘ座標と現在のx座標の差をpowerに代入
		float power = nowX - lastX;
		float power2 = lastX - nowX;
		//energyにpowerを加算
		energy += power;

		//チェック用のｘ座標更新
		lastX = nowX;
		//エネルギーがLIMITを超えてるか
		if(LIMIT<energy){
			//エネルギーを０
			energy = 0;
			//０〜敵キャラクターリストの長さ−１乱数を求め、出現させるキャラを決める
			int idx = (int)(Random.value * 99999) % enemyList.Length;
			//乱数をもとに決めた敵キャラクターのゲームオブジェクトをリストから取得
			GameObject obj = enemyList [idx];		
			//敵キャラクターの出現位置を決めるために新しいvecert3を作る
			Vector3 pos = new Vector3 (0, 0, 0);
			//x座標はカメラの撮影範囲から少しだけ右にする
			pos.x = (Camera.main.ViewportToWorldPoint (new Vector2 (1.4f, 0)).x);
			//y座標はカメラと同じ
			pos.y = camera.transform.position.y;
			//敵キャラクターのゲームオブジェクトを作成
			Instantiate (obj, pos, Quaternion.identity);
		
		}



	}
}
