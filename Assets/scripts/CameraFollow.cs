using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject player;
	public float speed=2f;
	public float minX,minY,maxX,maxY;
	float x,y;
	// Use this for initialization
	void Start () {
		transform.position=player.transform.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(player!=null){
			x=Mathf.Clamp(player.transform.position.x,minX,maxX);
			y=Mathf.Clamp(player.transform.position.y,minY,maxY);
			transform.position=Vector2.Lerp(transform.position,new Vector2(x,y), Time.deltaTime*speed);
		}
	}
}
