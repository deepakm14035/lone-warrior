using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour {
	Vector2 direction;
	float angle;

	public GameObject weaponProjectile;
	public Transform shotPoint;
	public float timeBetweenShots=2f, shotTime=3f;
	float angleOffset=0f;
	public Transform mainPlayer;
	public GameObject user;
	// Use this for initialization
	void Start () {
		mainPlayer=GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		direction=mainPlayer.position-transform.position;
		angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle+angleOffset,transform.forward);
		Quaternion rotationMovement = Quaternion.AngleAxis(angle+angleOffset-90f,transform.forward);
		transform.rotation=rotation;
		if(Time.time>=shotTime){
			Debug.Log("hitting");
			user.GetComponent<RangedEnemy>().animateThrowLog(rotationMovement,weaponProjectile,shotPoint.position);
			shotTime=Time.time+timeBetweenShots;
		}
	}

}
