using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	private Animator anim;
	private const string isBlowValName = "isBlowing";
	private const int blowTimer = 1;


	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		Destroy (gameObject, 1000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ifCollision(){
		anim.SetBool (isBlowValName, true);
		Destroy (gameObject, blowTimer);
	}
}
