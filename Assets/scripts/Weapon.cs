using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	Vector2 direction;
	float angle;

	public GameObject weaponProjectile;
	public Transform shotPoint;
	public float timeBetweenShots=2f, shotTime;
	public float angleOffset=-90f;
	public bool singleShot=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		direction=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
		angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle+angleOffset,transform.forward);
		transform.rotation=rotation;;
		if(Input.GetMouseButton(0)){
			if(Time.time>=shotTime){
				Instantiate(weaponProjectile,shotPoint.position,transform.rotation);
				if(singleShot){
					GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().updateToLastWeapon();
					Destroy(gameObject);
				}

				shotTime=Time.time+timeBetweenShots;
			}
		}
	}
}
