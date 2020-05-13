using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject,5f);
		Debug.Log("adasdas");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
