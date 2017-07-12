using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class whiteout : MonoBehaviour {
	float alfa;
	public float speed = 0.9f;
	float red, green, blue;
	public bool fedein = false;



	void Start () {
		red = GetComponent<Image>().color.r;
		green = GetComponent<Image>().color.g;
		blue = GetComponent<Image>().color.b;
	}
	public void fede1(){
		fedein = true;
	}
		
	void Update () {
		if (fedein) {
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += speed;
			//DelayMethodを3.5秒後に呼び出す
			//Invoke("DelayMethod", 5.0f);
		}
	

	}
}