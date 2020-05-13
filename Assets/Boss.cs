using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
	public int health,damage;
	public int halfHealth;
	public float speed;
	public GameObject[] strikes;

	public float stopDistance=8f;
	// Use this for initialization
	public float attackTime=0f; 	
	public float attackSpeed=8f;

	public float timeBetweenAttacks=3f;
	bool playerOnLeft=true;
	Transform player;
	Vector3 initialScale;

	Slider healthSlider;

	public Sprite[] slashes;
	public GameObject projectile;
	public GameObject spawnPoint,shieldObj;
	Animator animator;
	float angle;
	Vector3 direction;
	void Start(){
		player=GameObject.FindGameObjectWithTag("Player").transform;
		initialScale=gameObject.transform.localScale;
		halfHealth=health/2;
		animator=gameObject.GetComponent<Animator>();
		healthSlider=FindObjectOfType<Slider>();
		healthSlider.maxValue=health;
		healthSlider.value=health;
		if(player.transform.position.x>gameObject.transform.position.x)
			playerOnLeft=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(player!=null)
			updateDirection();
		if(player!=null&&health<=halfHealth){
			if(Vector2.Distance(transform.position,player.position)>stopDistance){
				if(animator.GetBool("swingSword")){
					animator.SetBool("swingSword",false);
				}
				transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
			}else{
				// if(Time.time>=attackTime){
				// 	player.GetComponent<PlayerController>().takeDamage(damage);
					animator.SetBool("swingSword",true);
				// 	attackTime=Time.time+timeBetweenAttacks;
				// }
			}
		}else
			if(animator.GetBool("swingSword")){
				animator.SetBool("swingSword", false);
			}
	}

	public void updateDirection(){
		if(player.position.x-transform.position.x>0f&&playerOnLeft){
				playerOnLeft=false;
				transform.localScale=new Vector3(-initialScale.x,initialScale.y,1f);
			}
			if(player.position.x-transform.position.x<0f&&!playerOnLeft){
				playerOnLeft=true;
				transform.localScale=new Vector3(initialScale.x,initialScale.y,1f);
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
	public void attackPlayer1(){
		animator.SetBool("attack",true);
		player.GetComponent<PlayerController>().takeDamage(damage);
		
		
	}

	public void takeDamage(int damage){
		health-=damage;
		healthSlider.value=health;
		if(health<=0){
			healthSlider.gameObject.SetActive(false);
			Destroy(gameObject);
		}
		if(health<=halfHealth){
			if(!animator.GetBool("run"))
				animator.SetBool("run",true);
			if(player.transform.position.x>gameObject.transform.position.x)
				playerOnLeft=false;
				GameObject.Destroy(shieldObj);
		}
	}

	public void throwSlash(){
		direction=player.position-transform.position;
		angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
		Quaternion rotationMovement = Quaternion.AngleAxis(angle-90f,transform.forward);
		GameObject slash=Instantiate(projectile,spawnPoint.transform.position,rotationMovement);
		slash.GetComponent<SpriteRenderer>().sprite=slashes[Random.Range(0,slashes.Length)];
	}
}
