using UnityEngine;
//using UnityEngine.UI;   // UIを使います。
using System.Collections;

public class hero2 : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject attackEF; //攻撃エフェクト　トリガーの関係で出したり消したりする 
	public GameObject attackEF2; //攻撃エフェクト　トリガーの関係で出したり消したりする 
	public GameObject DamegeEF; //ダメージ喰らったときのパーティクル
	public GameObject RevivalEF;//復活の際のエフェクト
	//public GameObject rose;

	public float speed = 4f; //歩くスピード
	public float jumpPower = 200; //ジャンプ力
	public LayerMask groundLayer; //Linecastで判定するLayer

	//ダメージ処理用
	public float maxLife = 100;    //最大体力（readonlyは変数の変更ができなくなるらしい）
	public float Life = 100;    //現在体力



	//レベルアップと攻撃カウント
	public int level = 1 ;
	public float EXP =0;
	public int attackCount = 0 ;//攻撃がヒットするとあがる　攻撃１段目と２段目の切り替え用
	public bool SecondAttack =false; //レベル2以降の２段目の攻撃を出したか否か

	private Rigidbody2D rigidbody2D;
	private Animator anim;

	//private Renderer renderer; //ダメージ処理のために仮で作っとく

	//public bool cooltime = true;
	private bool isGrounded; //着地判定
	public bool Attack = true; //攻撃可能
	public bool move = true;

	void Start () {
		//各コンポーネントをキャッシュしておく
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.fixedAngle = true;
		//renderer = GetComponent<Renderer>(); //ダメージ処理のために
		Life = maxLife; //体力を全回復させる
	}




	void attack1(){
		anim.SetBool ("wolk 0", false);
		anim.SetTrigger ("attack");
		attackEF.SetActive (true);
		attackEF.GetComponent<Animator> ().SetTrigger ("attack");
		attackEF.GetComponent<attack_judg2> ();
		Invoke ("ATKEFDL", 0.7f); //0.25f後にアタックエフェクトを消す
		Attack= false;
	}

	void attack2(){
		anim.SetBool ("wolk 0", false);
		anim.SetTrigger ("attack2");
		attackEF2.SetActive (true);
		attackEF2.GetComponent<Animator> ().SetTrigger ("yari");
		attackEF2.GetComponent<attack_judg2> ();
		Invoke ("ATKEFDL2", 0.7f); //0.25f後にアタックエフェクトを消す
		Attack= false;
		SecondAttack = true;
	}

	void ATKEFDL (){ //animation終わり後に消す目的
		attackEF.SetActive (false);
		Attack = true;
		attackCount = 0;
	}
	void ATKEFDL2 (){ //animation終わり後に消す目的
		attackEF2.SetActive (false);
		Attack = true;
		SecondAttack = false;
		attackCount = 0;
	}


	//public void Damage (float damage) {
	//}
	public void hit(float damage){
		Life -= damage; //体力を減らす
		anim.SetTrigger ("damage");
		// プレイヤーの位置を後ろに飛ばす
		float s = 50f * Time.deltaTime;
		transform.Translate(Vector3.up * s);

		// プレイヤーのlocalScaleでどちらを向いているのかを判定
		if(transform.localScale.x >= 0){
			transform.Translate(Vector3.left * s);
		}else{
			transform.Translate(Vector3.right * s);
		}
		if (Life > 0) {
			//StartCoroutine ("Damage");
			DamegeEF.SetActive (true);
			Invoke ("muteki", 2.5f);
			//レイヤーをPlayerDamageに変更
			gameObject.layer = LayerMask.NameToLayer ("PlayerDamage");
		} else {
			if (Life < 0) {
				StartCoroutine ("Dead");
			}
		}
	}
	public void EXPin(float xp){
		EXP += xp;
	}
	IEnumerator Dead(){
		anim.SetTrigger("damage");
		gameObject.layer = LayerMask.NameToLayer ("PlayerDamage");
		yield return new WaitForSeconds(0.01f);
		anim.SetTrigger ("Dead");
		move = false;
		yield return new WaitForSeconds(0.20f);
		RevivalEF.SetActive (true);
		yield return new WaitForSeconds(2.30f);
		RevivalEF.SetActive (false);
		anim.SetTrigger ("Revival");
		yield return new WaitForSeconds(0.8f);
		gameObject.layer = LayerMask.NameToLayer("Character");
		move = true;
		maxLife += 30f;
		Life = maxLife;

	
	}
	/*
	IEnumerator Damage ()
	{
		
		//レイヤーをPlayerDamageに変更
		gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
		//while文を7回ループ
		int count = 7;
		while (count > 0){
			//透明にする
			renderer.material.color = new Color (1,1,1,0);
			//0.05秒待つ
			yield return new WaitForSeconds(0.05f);
			//元に戻す
			renderer.material.color = new Color (1,1,1,1);
			//0.05秒待つ
			yield return new WaitForSeconds(0.05f);
			count--;
		
		}



	}
	*/
	void muteki(){
		//レイヤーをCharacterに戻す
		gameObject.layer = LayerMask.NameToLayer("Character");
		Attack = true;
		DamegeEF.SetActive (false);
		//isGrounded = true;
	}
	void Update ()
	{
		//レベルアップ
		if (EXP > 99) {
			level++;
			EXP = 0;
		}
		//デバッグ用コード
		if(Input.GetKeyDown("p")){
			EXP += 100f;
		}
		if(Input.GetKeyDown("o")){
			StartCoroutine ("Dead");
		}
		//moveがtrueのときに移動とか攻撃とかできる
		if(move){
		if (-1 == Input.GetAxisRaw ("Horizontal") || Input.GetKey ("left")) {
			rigidbody2D.velocity = new Vector2 (-1 * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = -1;
			transform.localScale = temp;
			if (isGrounded)
				anim.SetBool ("wolk 0", true);
		} else if(1 == Input.GetAxisRaw ("Horizontal") || Input.GetKey ("right")){
			rigidbody2D.velocity = new Vector2 (1 * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = 1;
			transform.localScale = temp;
			if (isGrounded)
				anim.SetBool ("wolk 0", true);
		} else {
			anim.SetBool ("wolk 0", false);
		}
		//回避
		if(Input.GetKeyDown("w")&&Attack||Input.GetButtonDown ("Douge")&&Attack){
			//横にスライド
			// プレイヤーのlocalScaleでどちらを向いているのかを判定
			if(transform.localScale.x >= 0){
				Attack = false;
				gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.right * 100);	
				anim.SetTrigger("Dodge");
				gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
				Invoke ("muteki", 1.0f);
			}else{
				Attack = false;
				gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.right * -100);	
				anim.SetTrigger("Dodge");
				gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
				Invoke ("muteki", 1.0f);
			
			}

		}

		//Linecastで主人公の足元に地面があるか判定
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 3.75f,
			groundLayer);
		//スペースキーを押し、
		if (Input.GetKeyDown ("space")||Input.GetButtonDown ("Jump")) {
			//着地していた時、
			if (isGrounded) {
				//Dashアニメーションを止めて、Jumpアニメーションを実行
				anim.SetBool("wolk 0", false);
				anim.SetTrigger("jump");
				//着地判定をfalse
				isGrounded = false;
				//rigidbody2D.gravityScale = 0f;
				//Invoke ("jumping", 0.15f);
				//AddForceにて上方向へ力を加える
				rigidbody2D.AddForce (Vector2.up * jumpPower);
			}
		}
		//攻撃
		if (Input.GetKeyDown ("q")||Input.GetButtonDown ("Attack")) {
			if (isGrounded && Attack&& SecondAttack==false) {
				switch( level ){
				case 1:
					attack1();
					break;
				case 2:
					if( attackCount % 2 == 0 ){
						attack1();
					}
					if( attackCount % 2 == 1 ){
						attack2();
					}
					//attackCount ++ ;
					break;
				case 3:
					if( attackCount % 3 == 0 ){
						attack1();
					}
					if( attackCount % 3 == 1 ){
						attack2();
					}
					if( attackCount % 3 == 3 ){
						attack2();
					}
					//attackCount ++ ;
					break;
				}	
			
			}
		}
		//上下への移動速度を取得
		float velY = rigidbody2D.velocity.y;
		//移動速度が0.1より大きければ上昇
		bool isJumping = velY > 0.1f ? true:false;
		//移動速度が-0.1より小さければ下降
		bool isFalling = velY < -0.1f ? true:false;
		//結果をアニメータービューの変数へ反映する
		anim.SetBool("isjumping",isJumping);
		anim.SetBool("isfalling",isFalling);

	}
	//↑moveの中身
	}
	void FixedUpdate ()
	{}
}