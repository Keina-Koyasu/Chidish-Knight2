/*
using UnityEngine;
using System.Collections;

public class FPScommond : MonoBehaviour {

	float damage = 10f;
	float speed = 6.0f;
	float sitting_speed = 3.0f;
	float jumpSpeed = 8.0f;
	float gravity = 20.0f;
	public float PlayerLife = 100f;
	public GameObject camera1;
//	public GameObject window;
	public GameObject[] traps;
	public GameObject torch;
	public GameObject message;
	public GameObject A;
	public GameObject TU;
	public GameObject T_message;
	public GameObject C_message;
	public GameObject D_message;
	public GameObject DP_message;
	public GameObject lastmemo;
	public GameObject player1;
	public GameObject takaranonakami; 
	public GameObject takaranonakami2; 
	public GameObject weapon1;
	public GameObject red_sc;
	public GameObject sousa;

	//private float wait_time = 0.0f;

	bool cooltime = true;
	public bool key1 = false; //シルバーキーの所得状況
	public bool key2 = false; //ゴールドキーの所得状況
	public bool is_torch = false;
	public bool weapon = false;
	private bool show = false; //メッセージウィンドウ出てる？
	// private bool moved = false; //移動している最中？
	private bool is_sitting = false; //座ってる状態？


	//private bool rotated = false;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	//private float lookat = 0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		controller.detectCollisions = true;
		moveDirection = new Vector3( 0.0f, 0.0f, 0.0f );
		GetComponents<AudioSource> ()[4].Play ();
	}
	public void Damage () {
		PlayerLife -= damage; //体力を減らす
		Debug.Log (PlayerLife);
		transform.Translate(Vector3.back * (0.4f * speed));
		red_sc.SetActive (true);
		red_sc.GetComponent<Dialogtimer> ().Show ();
		red_sc.GetComponent<AudioSource> ().Play ();
	}
	public void Show(){
		show = true;
	}
	void rayCast(){
		Ray ray = new Ray (camera1.transform.position, camera1.transform.forward);
		RaycastHit hit;
		Debug.DrawRay (ray.origin, ray.direction, Color.red, 10.0f);
		if (Physics.Raycast (ray, out hit, 10.0f)) {
			switch (hit.transform.gameObject.tag) {

			case "firstdoor": 
				A.SetActive (false);
				break;
			case "key":
				hit.transform.gameObject.SetActive (false);
				key1 = true;
				message.SetActive (true);
				message.GetComponent<Dialogtimer> ().Show ();
				GetComponents<AudioSource> ()[1].Play ();
				break;
			case "key2":
				hit.transform.gameObject.SetActive (false);
				key2 = true;
				message.SetActive (true);
				message.GetComponent<Dialogtimer> ().Show ();
				GetComponents<AudioSource> ()[1].Play ();
				break;
			case "lockdoor":
				message.SetActive (true);
				message.GetComponent<Dialogtimer> ().Show ();
				hit.transform.gameObject.GetComponent<AudioSource> ().Play ();
				break;
			case "takara":
				hit.transform.gameObject.GetComponent<Animator> ().SetTrigger ("open");
				hit.transform.gameObject.GetComponent<AudioSource> ().Play ();
				hit.transform.gameObject.tag = "waste";
				StartCoroutine ("T_messageShow");
				is_torch = true;
				lastmemo.GetComponent<flag> ().get1 ();
				if(torch.activeSelf==true){
					torch.SetActive (false);
				}
				break;
			case "takara2":
				hit.transform.gameObject.GetComponent<Animator> ().SetTrigger ("open");
				hit.transform.gameObject.GetComponent<AudioSource> ().Play ();
				hit.transform.gameObject.tag = "waste";
				StartCoroutine ("T_messageShow2");
				weapon = true;
				lastmemo.GetComponent<flag> ().get2 ();
				if(torch.activeSelf==true){
					torch.SetActive (false);
				}
				break;
				//シルバーキーの扉
			case "Door":
				if (key1) {
					hit.transform.gameObject.GetComponent<Animator> ().SetTrigger ("dooropen");
					hit.transform.gameObject.GetComponents<AudioSource> ()[0].Play ();
					hit.transform.gameObject.tag = "waste";
				} else {
					message.SetActive (true);
					message.GetComponent<Dialogtimer> ().Show ();
					hit.transform.gameObject.GetComponents<AudioSource> ()[1].Play ();
					Debug.Log ("No key!!!!!!!!");
				}
				break;
				//ゴールドキーのトビラ
			case "Door2":
				Debug.Log ("Door2");
				if (key2) {
					hit.transform.gameObject.GetComponent<Animator> ().SetTrigger ("dooropen");
					hit.transform.gameObject.GetComponents<AudioSource> ()[0].Play ();
					hit.transform.gameObject.tag = "waste";
				} else {
					message.SetActive (true);
					message.GetComponent<Dialogtimer> ().Show ();
					hit.transform.gameObject.GetComponents<AudioSource> ()[1].Play ();
					Debug.Log ("No key!!!!!!!!");
				}
				break;
			case"memo1":
				D_message.SetActive (true);
				show = true;
				hit.transform.gameObject.GetComponent<AudioSource> ().Play ();
				hit.transform.gameObject.SetActive (false);
				lastmemo.GetComponent<flag> ().nyuusyu1 ();
				if(torch.activeSelf==true){
					torch.SetActive (false);
				}
				break;
			case"memo2":
				D_message.SetActive (true);
				show = true;
				hit.transform.gameObject.GetComponent<AudioSource> ().Play ();
				hit.transform.gameObject.SetActive (false);
				lastmemo.GetComponent<flag> ().nyuusyu2 ();
				if(torch.activeSelf==true){
					torch.SetActive (false);
				}
				break;
			case"memo3":
				D_message.SetActive (true);
				show = true;
				hit.transform.gameObject.GetComponent<AudioSource> ().Play ();
				hit.transform.gameObject.SetActive (false);
				lastmemo.GetComponent<flag> ().nyuusyu3 ();
				if(torch.activeSelf==true){
					torch.SetActive (false);
				}
				break;
			case"memo4":
				D_message.SetActive (true);
				show = true;
				hit.transform.gameObject.GetComponent<AudioSource> ().Play ();
				hit.transform.gameObject.SetActive (false);
				lastmemo.GetComponent<flag> ().nyuusyu4 ();
				lastmemo.GetComponent<flag> ().kesu ();
				if(torch.activeSelf==true){
					torch.SetActive (false);
				}
				break;
				//lastmemoオブジェクトのmemo4のスクリプトには本の入手のフラグがある
			case"C_endflag":
				hit.transform.gameObject.SetActive (false);
				T_message.SetActive (true);
				T_message.GetComponent<Dialogtimer> ().Show ();
				GetComponents<AudioSource> () [1].Play ();
				lastmemo.GetComponent<flag> ().Cend ();
				lastmemo.GetComponent<flag> ().kesu4 ();
				lastmemo.GetComponent<flag> ().kesu ();
				if(torch.activeSelf==true){
					torch.SetActive (false);
				}
				break;
			default:
				C_message.SetActive(true);
				C_message.GetComponent<Dialogtimer> ().Show ();
				Debug.Log (hit.collider.gameObject.name);
				break;

			}
		}
	}

	void taimatsuCommand(){
		//松明
		if (Input.GetKeyDown ("a") || Input.GetButtonDown("torch")) {
			if (is_sitting == false) {
				if (is_torch) {
					GetComponents<AudioSource> ()[2].Play ();
					torch.SetActive (true);

				} else if (Input.GetKeyUp ("a")||Input.GetButtonUp("torch")) {
					if (is_sitting == false) {
						if (is_torch) {
							torch.SetActive (false);
							GetComponents<AudioSource> ()[2].Stop ();
						} else {
						}
					}
				}
			}
		}

		if (Input.GetKeyUp ("a")||Input.GetButtonUp("torch")) {
			if (is_sitting == false) {
				if (is_torch) {
					torch.SetActive (false);
					GetComponents<AudioSource> ()[2].Stop ();
				} else {
					//武器振らないよ
				}
			}
		}
		}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("u")) {
			Application.LoadLevel ("MDCR1");
		}
		if (Input.GetKeyDown ("i")) {
			Application.LoadLevel ("titl");
		}
		// moveDirection = new Vector3( 0.0f, 0.0f, 0.0f );
		if (controller.isGrounded) {
			//↑地面についているかどうか
			if (show == false) {
				//メッセージウインドウが表示されていない時に以下を実行
				moveDirection = new Vector3 (0.0f, 0.0f, 0.0f);

				//移動方向を取得
				////Horizontal = 水平方向 Virtical = 垂直方向
				//moveDirection = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				// moveDirection = transform.forward;
				//moveDirection = transform.TransformDirection(moveDirection);
				//ゲームコントローラーのボタン設定
				if (Input.GetButtonDown ("syagamu") || Input.GetKeyDown ("s")) {
					if (is_sitting == false) {
						Shagamu ();
					} else {
						Tatsu ();
					}
				}
				if (Input.GetButtonDown ("chack") || Input.GetKeyDown (KeyCode.H)) {
					if (sousa.activeSelf == true) {
						sousa.SetActive (false);
					} else {
						rayCast ();
					}
				}
				//左すてぃっく前後で移動
				//Debug.Log (Input.GetAxisRaw ("Vertical"));
				if (1 == Input.GetAxisRaw ("Vertical1")) {
					//Debug.Log( "Vertical -1" );
					//Debug.Log (Input.GetAxisRaw ("Vertical"));
					moveDirection = transform.forward * (-1.0f * speed);
					/*
					if (wait_time <= 0) {
						Debug.Log("タイマーが0になりました");
						GetComponent<AudioSource> ().Play ();
						wait_time=0.5f;
					}

				}
				if (-1 == Input.GetAxisRaw ("Vertical1")) {
					moveDirection = transform.forward * (1.0f * speed);
				}

				//右スティックでカメラ移動
				if (-1 == Input.GetAxisRaw ("Horizontal") || Input.GetKey ("left")) {
					transform.Rotate (0, -speed * 0.6f, 0);
				}
				if (1 == Input.GetAxisRaw ("Horizontal") || Input.GetKey ("right")) {
					transform.Rotate (0, speed * 0.6f, 0);
				}
				if (-1 == Input.GetAxisRaw ("cameraupdowm") || Input.GetKey ("up")) {
					if (camera1.transform.localEulerAngles.x > 300 || camera1.transform.localEulerAngles.x < 70) {
						camera1.transform.Rotate (-speed * 0.7f, 0, 0);	
					}
				}
				if (1 == Input.GetAxisRaw ("cameraupdowm") || Input.GetKey ("down")) {
					if (camera1.transform.localEulerAngles.x < 60 || camera1.transform.localEulerAngles.x >= 290) {
						camera1.transform.Rotate (speed * 0.7f, 0, 0);
					}
				}

				if (Input.GetKey ("z")) {
					moveDirection = transform.forward * (1.0f * speed);
				} else if (Input.GetKey ("x")) {
					//xを押したら後退
					moveDirection = transform.forward * (-1.0f * speed);
				}

				//ジャンプ(なんか、キーが設定されてるっぽい.スペースでおｋ)
				if (Input.GetButton ("Jump")) {
					moveDirection.y = jumpSpeed;
				}

				//ボタンを押したらワープ
				if (Input.GetKeyDown ("w")) {
					player1.transform.position = new Vector3 (-0.6098f, 2.7f, 76.1325f);
				}
				if (Input.GetKeyDown ("e")) {
					player1.transform.position = new Vector3 (32.95f, 7.62f, 45.01f);
				}
				if (Input.GetKeyDown ("r")) {
					player1.transform.position = new Vector3 (-51.072f, 25.74f, 18.21f);
				}
				if (Input.GetKeyDown ("t")) {
					player1.transform.position = new Vector3 (-61.67f, -7.05f, 18.17f);
				}
			} else {
				if (Input.GetButtonDown ("chack") || Input.GetKeyDown (KeyCode.H)||Input.GetKeyDown ("q") || Input.GetButtonDown ("start")) {
					if (D_message.activeSelf == true) {
						DP_message.SetActive (true);
						DP_message.GetComponent<Dialogtimer> ().Show ();
						D_message.SetActive (false);
						GetComponents<AudioSource> () [1].Play ();
						show = false;
					} else {
						show = false;
					}
				}
			}
		//isground_END
		}
		//操作説明出すよ
		if (show == false) {
			if (Input.GetKeyDown ("q") || Input.GetButtonDown ("start")) {
				if (sousa.activeSelf == true) {
					sousa.SetActive (false);

				} else {
					sousa.SetActive (true);

				}
			}
			if (Input.GetKeyDown ("z")) {
				GetComponent<AudioSource> ().Play ();
			}
			if (Input.GetKeyUp ("z")) {
				GetComponent<AudioSource> ().Stop ();
			}

			if (Input.GetKeyDown ("x")) {
				GetComponent<AudioSource> ().Play ();
			}
			if (Input.GetKeyUp ("x")) {
				GetComponent<AudioSource> ().Stop ();
			}
			if (Input.GetKeyDown ("p")) {
				player1.transform.position = new Vector3 (20.91f, 9.9f, 41.12f);
			}
			if (Input.GetButtonDown ("attack") || Input.GetKeyDown ("d")) {
				if (is_sitting == false) {
					if (weapon) {
						if (cooltime) {
							weapon1.SetActive (true);

							weapon1.GetComponent<Animator> ().SetTrigger ("tsuku");
							weapon1.GetComponent<AudioSource> ().Play ();
							//槍を消す
							Invoke ("yaritaiki", 1.3f);
							cooltime = false;
						}
						}
				}
			}

			taimatsuCommand ();
		}
		if (show == false) {
			//以下は常に行われる計算。物理エンジンに頼らずに物理挙動たぶん
			// 重力を計算
			moveDirection.y -= gravity * Time.deltaTime;
			// 移動
			// Debug.Log( moveDirection );
			controller.Move (moveDirection * Time.deltaTime);
			// gameObject.transform.Translate( moveDirection * Time.deltaTime);
		}
	}

	private IEnumerator T_messageShow() {
		show = true;

		yield return new WaitForSeconds (2);

		T_message.SetActive (true);
		T_message.GetComponent<Dialogtimer> ().Show ();
		takaranonakami.SetActive (false);


		GetComponents<AudioSource> ()[1].Play ();
		show = false;

	}
	private IEnumerator T_messageShow2() {
		show = true;

		yield return new WaitForSeconds (2);

		T_message.SetActive (true);
		T_message.GetComponent<Dialogtimer> ().Show ();
		takaranonakami2.SetActive (false);


		GetComponents<AudioSource> ()[1].Play ();
		show = false;

	}

	void yaritaiki(){
		weapon1.SetActive (false);
		cooltime = true; 
	}

	//オブジェクトにぶつかったら
	void OnCollisionEnter(Collision collision) {

		// Debug.Log (collision.gameObject.name);

		for (int i = 0; i < traps.Length; i++) {
			//trapsにいれたオブジェクトの名前が含まれているのにぶつかったら
			if (collision.gameObject.name.IndexOf (traps[i].name) >= 0) {
				traps [i].SetActive (true);
				//_trapの名前がついたのにぶつかったら
				if (collision.gameObject.name.IndexOf ("_trap") >= 0) {
					collision.gameObject.SetActive (false);
				
				}
			}
		}
		if (collision.gameObject.name == "GreatAxe") {
			Damage ();
		}

		if (collision.gameObject.tag == "Enemy") {
			Debug.Log (collision.gameObject.name);
		}
		//if (collision.gameObject.name == "MYFPS") 

	}


	//以下汎用関数

	void Shagamu(){
		if (torch.activeSelf == false) {
			is_sitting = true;
			Debug.Log ("sit down");
			transform.localScale = new Vector3 (1f, 0.2f, 1f);
			GetComponents<AudioSource> ()[3].Play ();
			speed = sitting_speed;
		}

	}
	void Tatsu(){
		RaycastHit hit;
		Ray ray = new Ray (camera1.transform.position, transform.up);
		if (Physics.Raycast (ray, out hit, 0.9f)) {
			Debug.Log ("ここでは立てない");
			message.SetActive (true);
			message.GetComponent<Dialogtimer> ().Show ();
		} else {
			is_sitting = false;
			Debug.Log ("stund up");
			transform.localScale = new Vector3 (1f, 1.2f, 1f);
			GetComponents<AudioSource> ()[3].Play ();
			speed = 6.0f;
		}
	}

}//クラス終わり
*/