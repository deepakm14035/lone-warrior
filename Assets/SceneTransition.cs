using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour {
	Animator animator;
	public void openScene(string sceneName){
	StartCoroutine(showScene(sceneName));
	}
	IEnumerator showScene(string scene){
		animator.SetTrigger("finish");
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(scene);
	}

	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
