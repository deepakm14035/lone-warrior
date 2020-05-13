using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy {

	public GameObject spider;
	public float minX,minY, maxX,maxY;
	public Vector3 targetPos;
	public Animator animator;
	void setTarget(){
		targetPos=new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0f);
	}
	// Use this for initialization
	public  override void Start () {
		base.Start();
		setTarget();
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position,targetPos)<1f){
			animator.SetTrigger("summonSpiders");
		}else{
			transform.position=Vector2.MoveTowards(transform.position,targetPos,speed*Time.deltaTime);
		}
	}
	public void summon(){
		Instantiate(spider,transform.transform.position+new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),0f),transform.rotation);

	}
}
