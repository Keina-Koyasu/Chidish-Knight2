/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int level = 1 ;
	int attackCount = 0 ;

	// Use this for initialization
	void Start () {
		
	}

	void attack1(){
	}

	void attack2(){
	}

	void attack3(){
	}
		

	// Update is called once per frame
	void Update () {

		if ( Input.GetKeyDown( KeyCode.A ){
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
				attackCount ++ ;
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
				attackCount ++ ;
				break;
			}
		}
		
	}
}
*/