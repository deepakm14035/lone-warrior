using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health=100;
	// [HideInInspector]
	public Transform player;
	public float speed=1f;
	public int damage=20;
	public Vector3 initialScale;

	public GameObject[] pickups;
	public int pickupChance=20;
	public GameObject deadBody, deathParticleSystem;
	public void takeDamage(int damage){
		health-=damage;
		if(health<=0){
			Debug.Log(deadBody!=null);
			if(deadBody!=null)
				Instantiate(deadBody,transform.position,transform.rotation);
			
			if(pickups.Length>0 && Random.Range(0f,100f)<pickupChance){
				int pickupNo=Random.Range(0,pickups.Length);
				Instantiate(pickups[pickupNo],transform.position,transform.rotation);
			}
			Instantiate(deathParticleSystem,transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	 public virtual void Start () {
		Debug.Log("fsdf");
		player=GameObject.FindGameObjectWithTag("Player").transform;
		initialScale=transform.localScale;
	}
	
	// Update is called once per frame
	// void Update () {
		
	// }
}
