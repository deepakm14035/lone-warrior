using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

	AudioSource soundObj;
	public AudioClip[] clips;
	// Use this for initialization
	void Start () {
		soundObj=GetComponent<AudioSource>();
		soundObj.clip=clips[Random.Range(0,clips.Length)];
		soundObj.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
