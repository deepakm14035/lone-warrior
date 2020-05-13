using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {
	PlayerController player;
	public int healAmount=20;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	public void OnTriggerEnter2D(Collider2D col){
		// Debug.Log("heeree");
		if(col.tag.Equals("Player")){
			player.Heal(healAmount);
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
