using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public Rigidbody rigid;

	// Use this for initialization
	void Start () {

		rigid = rigid.GetComponent<Rigidbody>();
		rigid.useGravity = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
