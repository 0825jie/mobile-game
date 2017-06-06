using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class floatcontroller : MonoBehaviour {
	Rigidbody2D mybody;
	public float moveforce = 50,bootmultiper=2;
	// Use this for initialization
	void Start () {
		mybody = this.GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 movevec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical"))*moveforce;
		bool isBoosting = CrossPlatformInputManager.GetButton ("Jump");
		Debug.Log (isBoosting ? bootmultiper:1);
		mybody.AddForce (movevec*(isBoosting?bootmultiper:1));
	}
}
