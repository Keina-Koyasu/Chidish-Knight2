using UnityEngine;
using System.Collections;

public class Tamashibi_AI3 : MonoBehaviour {
	public GameObject ATJ;
	public GameObject Player;
	//public GameObject ATRange;

	private Animator anim;		// 《Animator》コンポーネント用の変数
	public Transform player;    //プレイヤーを代入
	public float speed = 3; //移動速度
	public float knockBack = 0.2f ;
	public float limitDistance = 1000f; 
	public float xp = 30;


	private bool iswalk = true;


	// ■■■■■■
	void Start(){
		anim = GetComponent< Animator >();	// 《Animator》コンポーネントの取得

		// controller.isTrigger = true;
	}
	void Update () {
			//controller = GetComponent<CharacterController>();
			Vector3 playerPos = player.position;    //プレイヤーの位置
			Vector3 direction = playerPos - transform.position; //方向
			direction = direction.normalized;   //単位化（距離要素を取り除く）
		if (iswalk) {	
			transform.position = transform.position + (direction * speed * Time.deltaTime);
			direction.y -= 9.8f * Time.deltaTime;
		}
			Vector3 forward = player.transform.position - transform.position;

		if(forward.x > 0){
			//transform.Translate(Vector3.right * 0.1f);
			transform.localScale = new Vector3(- 1.5f, 1.5f, 1.5f);
		}else{
			//transform.Translate(Vector3.left * 0.1f);
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		}
		return;
	}
	// ■■■■■■
	public void hit(){
		//anim.SetTrigger ("die");
		Invoke ("dead", 0.8f);
	}
	void dead(){
		Destroy(this.gameObject);
		Player.gameObject.SendMessage("EXPin", xp); 
	}


	void ATJA(){
		ATJ.SetActive (true);
	}


	public void Attack() {

			iswalk = false;
			anim.SetBool("attack", true);
			Invoke ("ATJA", 0.3f);
			//ATJ.SetActive (true);
			ATJ.GetComponent<Enemyattack> ();
			StartCoroutine("WaitFotAttack");


	}
	IEnumerator WaitFotAttack()
	{
		yield return new WaitForSeconds(1.0f);
		iswalk = true;
		//isAttack = false;
		anim.SetBool("attack", false);
		ATJ.SetActive (false);
	}




}