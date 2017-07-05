/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamashibi_AI2 : MonoBehaviour {
	Vector2 A, C, AB, AC;
	Vector2 move = new Vector2(1, 0); // 進む方向
	float speed = 5f; // 動くスピード
	float arot = 0; // 自分の角度

	float Maxkaku = 0.05f; // 曲がる最大角度
	public float rotation; // 曲がる角度

	public GameObject target; // 離れる対象

	void Start () 
	{
		target = GameObject.Find("Player"); // 離れる対象のオブジェクトの名前
	}

	void Update () 
	{
		A = new Vector2(transform.position.x, transform.position.y); // 自分のポジション
		C = new Vector2(target.transform.position.x, target.transform.position.y); // ターゲットポジション

		AB = new Vector2(move.x, move.y); // 移動方向

		AC = C - A; // ターゲットのベクトルを調べる

		//なす角ｒを求める
		float dot = AB.x * AC.x + AB.y * AC.y; // 内積

		float r = Acosf(dot / ((float)length(AB) * (float)length(AC))); // アークコサインを使って内積とベクトルの長さから角度を求める

		// 曲がる方向を決める
		if (AB.x * AC.y - AB.y * AC.x < 0)
		{
			r = -r;
		}

		r = r * 180 / Mathf.PI; // ラジアンから角度に

		// 回転角度制御
		if (r > Maxkaku)
		{
			r = Maxkaku;
		}
		if (r < -Maxkaku)
		{
			r = -Maxkaku;
		}


		rotation = r; // 曲がる角度を入れる


		Move();


	}

	//-------------------------------------------------
	// オブジェクトの移動処理
	//-------------------------------------------------
	void Move()
	{
		float rot = rotation; // 曲がる角度

		float tx = move.x, ty = move.y;

		move.x = tx * Mathf.Cos(rot) - ty * Mathf.Sin(rot);
		move.y = tx * Mathf.Sin(rot) + ty * Mathf.Cos(rot);

		arot = Mathf.Atan2(move.x, move.y); // 移動量から角度を求める
		float kaku = arot * 180.0f / Mathf.PI * -1 + 90; // ラジアンから角度に

		rigidbody2D.velocity = new Vector2(move.x, move.y) * speed * 1; // 移動(最後のー1をかけている所を消すとプレイヤーを追いかけます)
		transform.rotation = Quaternion.Euler(0, 0,kaku); // 回転

	}

	/// <summary>
	/// 長さが+-1を越えたとき1に戻す処理
	/// </summary>
	/// <param name="a">内積 / ベクトルの長さの答</param>
	/// <returns></returns>
	public float Acosf(float a)
	{
		if (a < -1) a = -1;
		if (a > 1) a = 1;

		return (float)Mathf.Acos(a);
	}

	/// <summary>
	/// ベクトルの長さを求める
	/// </summary>
	/// <param name="vec">2点間のベクトル</param>
	/// <returns>ベクトルの長さを返す</returns>
	public float length(Vector2 vec) 
	{
		return Mathf.Sqrt( vec.x * vec.x + vec.y * vec.y );
	}
}
*/