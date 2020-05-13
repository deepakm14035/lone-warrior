using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRandom : StateMachineBehaviour {
	public GameObject[] patrolPoints;
	public int currentIndex;
	public float speed;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		patrolPoints=GameObject.FindGameObjectsWithTag("BossPositions");
		currentIndex=Random.Range(0,patrolPoints.Length);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.transform.position=Vector3.MoveTowards(animator.gameObject.transform.position,patrolPoints[currentIndex].transform.position,speed*Time.deltaTime);
		Debug.Log(Vector3.Distance(animator.gameObject.transform.position,patrolPoints[currentIndex].transform.position));
		if(Vector3.Distance(animator.gameObject.transform.position,patrolPoints[currentIndex].transform.position)<0.3f){
			currentIndex=Random.Range(0,patrolPoints.Length);
			animator.SetTrigger("Attack");
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

}
