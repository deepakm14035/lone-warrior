using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy {
	public Animator animator;
	private GameObject projectile;
	private Vector2 wPosition;
	private Quaternion weaponDirection;
	private bool playerOnLeft=true;
	// Use this for initialization
	public override void Start () {
		base.Start();
		animator=GetComponent<Animator>();
		if(playerOnLeft)
			gameObject.transform.localScale=new Vector3(Mathf.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y,gameObject.transform.localScale.z);
		else
			gameObject.transform.localScale=new Vector3(-Mathf.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y,gameObject.transform.localScale.z);
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void animateThrowLog(Quaternion wDir, GameObject weapon, Vector2 position){
		weaponDirection=wDir;
		projectile=weapon;
		wPosition=position;
		animator.SetTrigger("ThrowLog");
	}

	public void throwLog(){
		Instantiate(projectile,wPosition,weaponDirection);
	}
}
