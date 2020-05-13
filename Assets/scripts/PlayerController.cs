using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	Vector2 movement;
	public float speed=1f;
	public int health=100;
	private Rigidbody2D rb;
	public Image[] hearts;
	public Sprite emptyheart,fullheart;
	
	public List<GameObject> weaponList;
	public GameObject currentWeapon;
	public GameObject screenRed;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody2D>();
		weaponList=new List<GameObject>();
		currentWeapon=GameObject.FindGameObjectWithTag("Weapon");
	}
	
	// Update is called once per frame
	void Update () {
		movement=new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if(Mathf.Abs( Input.GetAxisRaw("Horizontal")+ Input.GetAxisRaw("Vertical"))>0f)
			GetComponent<Animator>().SetBool("isRunning",true);
		else
			GetComponent<Animator>().SetBool("isRunning",false);
	}

	void FixedUpdate () {
		rb.MovePosition(rb.position+movement*Time.deltaTime*speed);
		//Debug.Log(weaponList.Capacity);
	}

	public void takeDamage(int damage){
		health-=damage;
		Camera.main.gameObject.GetComponent<Animator>().SetTrigger("shake");
		screenRed.GetComponent<Animator>().SetTrigger("putRed");
		updateHealthUI(health/20);
		if(health<=0)
			Destroy(gameObject);
	}

	public void changeWeapon(GameObject weapon){
		currentWeapon.SetActive(false);
		if(weapon.GetComponent<Weapon>().singleShot){
			weaponList.Add(currentWeapon);
			Debug.Log("Added");
		}
		//Destroy(GameObject.FindGameObjectWithTag("Weapon"));
		
		currentWeapon=Instantiate(weapon,transform.position,transform.rotation,transform);
		currentWeapon.GetComponent<Weapon>().shotPoint=transform;
	}

	public void updateToLastWeapon(){
		currentWeapon=(GameObject)weaponList[weaponList.Count-1];
		currentWeapon.SetActive(true);
		Debug.Log("removing");
		weaponList.RemoveAt(weaponList.Count-1);
	}

	public void updateHealthUI(int health){
		for(int i=0;i<hearts.Length;i++){
			if(i<health){
				hearts[i].sprite=fullheart;
			}else
				hearts[i].sprite=emptyheart;
		}
	}

	public void Heal(int healAmount){
		health=Mathf.Clamp(health+healAmount,0,100);
		updateHealthUI(health/20);
	}

}
