﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]private TeamHealth teamHealth;
	private Canvas _canvas;
	private Text _hp;
	private Rigidbody2D user;
	private float playerHp;
	private GameObject canvasObject;
	private RectTransform rectTranny;
	private Transform _healtBarTransform,_teamHealthbar, _team, camHealthbar;    
  
    private string teamColor;
    //Using awake to set the health number on the player prefabs
    void Awake()
	{		
		playerHp = 100;
	}

	// Use this for initialization
	void Start () {

        
        user = GetComponent<Rigidbody2D>();
		playerHp = 100f;
		checkTeam();
		takeDmg(30);
		// setSizeOfHpBar();
		
	}

	void update(){

        //check to see if the player is out of bounds
		
    }	

    public void takeDmg(float dmg)
    {
		_team = transform.Find("/Main Camera").GetComponent<Transform>();
		if(checkTeam()){
			 camHealthbar = _team.Find("HealthbarGreen").GetComponent<Transform>();
		}
		else{

		 camHealthbar = _team.Find("HealthbarBlue").GetComponent<Transform>();
		}        
		teamHealth = camHealthbar.GetComponent<TeamHealth>();
		if(playerHp - dmg < 0){
			playerHp = 0f;
		}else{

        playerHp -= dmg;
		}

        Debug.Log(playerHp);
		teamHealth.setSize(dmg);
		setSizeOfHpBar();
		isDead();
    }

	public float getPlayerHp(){
		return playerHp;
	}

	public void setPlayerHp(float value){
        playerHp = value;
	}

	void setSizeOfHpBar(){
				Transform bar;
		// print(this.name + "hey there");
		// if(checkTeam()){
		// }		
		_healtBarTransform = transform.GetComponentInChildren<Transform>().Find("HealthbarPlayer");
		// _healtBarTransform = GameObject.FindGameObjectWithTag("HealthbarPlayer").transform;
		bar = _healtBarTransform.GetComponentInChildren<Transform>().Find("Bar");
		// bar = GameObject.FindGameObjectWithTag("Bar").transform;
		print(bar.name);		
		bar.localScale = new Vector3(playerHp/100, 1f);
	
	}

	public bool checkTeam(){
		 int team;
		string playerName = this.name;
		string resultString = Regex.Match(playerName, @"\d+").Value;
		int.TryParse(resultString,out team);
		
		if(team % 2 == 1){
			return true;
		}

		
		return false;
	}

	// //health pickup
	// void OnCollisionEnter(Collision collision)
    // {
	// 	GameObject hpKit;
	// 	if(collision.collider.name == "HP"){
	// 		takeDmg(-25);
	// 		print("inside col");
	// 		hpKit = collision.gameObject.GetComponent<GameObject>();
	// 		print("inside col" + hpKit.name);
	// 	}
	// }
	//only checks if hp is 0 or under, should also check for out of bounds
	bool isDead(){
		if(playerHp <= 0){
			this.gameObject.SetActive(false);
			return true;
		}

		return false;
	}

	// bool OnTheMap(Transform playerTrans){

	// 	if(playerTrans.position < 123 || playerTrans.position > -123){
	// 		return true;
	// 	}
	// 	return false;
	// }
}
