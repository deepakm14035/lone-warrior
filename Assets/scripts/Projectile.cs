using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed=1f;
	public int damage=25;
	public float lifeTime=5f;
	public GameObject particleSystem, soundOnDestroyObj, soundOnThrowObj;
	// Use this for initialization
	void Start () {
		Invoke("DestroyProjectile", lifeTime);
		if(soundOnThrowObj!=null)
		Instantiate(soundOnThrowObj,transform.position,transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up*speed*Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D c){
		// Debug.Log(c.gameObject.name);
		if(c.tag.Equals("enemy")){
			c.GetComponent<Enemy>().takeDamage(damage);
			DestroyProjectile();
			Instantiate(soundOnDestroyObj,transform.position,transform.rotation);
		}
		if(c.tag.Equals("boss")){
			c.GetComponent<Boss>().takeDamage(damage);
			DestroyProjectile();
			
			Instantiate(soundOnDestroyObj,transform.position,transform.rotation);
		}
	}
	public void DestroyProjectile(){
		Instantiate(particleSystem,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}
}
