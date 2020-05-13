using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {
	Vector3 offset;
	// Use this for initialization
	void Start () {
		Cursor.visible=false;
		offset=new Vector3(2f,-20f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=Input.mousePosition+offset;
	}
}
