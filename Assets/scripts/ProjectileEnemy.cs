using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour {

	public float speed=1f;
	public int damage=25;
	public float lifeTime=5f;
	public GameObject particleSystem,soundOnThrowObj;
	public bool scaleWithDistance=false;
	// Use this for initialization
	void Start () {
		Invoke("DestroyProjectile", lifeTime);
		if(soundOnThrowObj!=null)
			Instantiate(soundOnThrowObj,transform.position,transform.rotation);
		if(scaleWithDistance)
			StartCoroutine(scaleWeapon());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up*speed*Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D c){
		Debug.Log(c.gameObject.name);
		if(c.tag.Equals("Player")){
			c.GetComponent<PlayerController>().takeDamage(damage);
			DestroyProjectile();
		}
	}
	public void DestroyProjectile(){
		if(particleSystem!=null)
			Instantiate(particleSystem,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	IEnumerator scaleWeapon(){
		while(true){
			gameObject.transform.localScale*=1.02f;
			yield return null;
		}
	}
}
