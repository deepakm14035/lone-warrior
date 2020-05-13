using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	public GameObject weapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.tag.Equals("Player")){
			col.GetComponent<PlayerController>().changeWeapon(weapon);
			Destroy(gameObject);
		}
	}
}
