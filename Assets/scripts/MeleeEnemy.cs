using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {
	public float stopDistance=8f;
	// Use this for initialization
	public float attackTime=0f; 	
	public float attackSpeed=8f;

	public float timeBetweenAttacks=3f;
	public bool playerOnLeft=false;
	public bool attackFromAnimator=false;
	
	// Update is called once per frame
	void Update () {
		if(player!=null){
			if(Vector2.Distance(transform.position,player.position)>stopDistance){
				if(gameObject.GetComponent<Animator>().GetBool("attack")){
					gameObject.GetComponent<Animator>().SetBool("attack",false);
				}
				transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
			}
			else{
				if(Time.time>=attackTime && !attackFromAnimator){
					player.GetComponent<PlayerController>().takeDamage(damage);
					gameObject.GetComponent<Animator>().SetBool("attack",true);
					attackTime=Time.time+timeBetweenAttacks;
				}else if(attackFromAnimator)
					gameObject.GetComponent<Animator>().SetBool("attack",true);
			}
			if(player.position.x-transform.position.x>0f&&playerOnLeft){
				playerOnLeft=false;
				transform.localScale=new Vector3(initialScale.x,initialScale.y,1f);
			}
			if(player.position.x-transform.position.x<0f&&!playerOnLeft){
				playerOnLeft=true;
				transform.localScale=new Vector3(-initialScale.x,initialScale.y,1f);
			}
		}else
			if(gameObject.GetComponent<Animator>().GetBool("attack")){
				gameObject.GetComponent<Animator>().SetBool("attack", false);
			}
	}
	IEnumerator attackPlayer(){
		player.GetComponent<PlayerController>().takeDamage(damage);
		Vector2 originalPos=transform.position;
		Vector2 targetPos=player.position;
		float percent=0f;
		while(percent<1f){
			percent=Time.deltaTime*attackSpeed;
			float formula = (-Mathf.Pow(percent,2)+percent)*4;
			transform.position=Vector2.Lerp(transform.position,player.position,formula);
			yield return null;
		}
	}
	IEnumerator attackPlayer1(){
		gameObject.GetComponent<Animator>().SetBool("attack",true);
		yield return null;
		player.GetComponent<PlayerController>().takeDamage(damage);
		
		
	}
}
