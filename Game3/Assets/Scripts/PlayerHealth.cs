﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]private TeamHealth teamHealth;
	private Canvas _canvas;
	private Text _hp;
	private Rigidbody2D user;
	private float playerHp;
	private GameObject canvasObject;
	private RectTransform rectTranny;
	private Transform _healtBarTransform,_teamHealthbar, _team;
    
    private TurnMaker turnMaker;
    private string teamColor;
    //Using awake to set the health number on the player prefabs
    void Awake()
	{
		
		playerHp = 100;
	}

	// Use this for initialization
	void Start () {

        turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
        teamColor = turnMaker.GetColor();
        user = GetComponent<Rigidbody2D>();
		playerHp = 100f;
		
		takeDmg(50, teamColor);
		// setSizeOfHpBar();
		
	}

	void update(){

        teamColor = turnMaker.GetColor();
    }	

    public void takeDmg(float dmg, string teamColor)
    {
		_team = transform.Find("/Main Camera").GetComponent<Transform>();
		Transform camHealthbar = _team.Find("Healthbar"+teamColor).GetComponent<Transform>();
        
		teamHealth = camHealthbar.GetComponent<TeamHealth>();		
        playerHp -= dmg;
        Debug.Log(playerHp);
		teamHealth.setSize(dmg);
		setSizeOfHpBar();
    }

	public float getPlayerHp(){
		return playerHp;
	}

	public void setPlayerHp(float value){
        playerHp = value;
	}

	void setSizeOfHpBar(){
		Transform bar;		
		_healtBarTransform = transform.GetComponentInChildren<Transform>().Find("Healthbar"+teamColor);
		bar = _healtBarTransform.GetComponentInChildren<Transform>().Find("Bar");		
		bar.localScale = new Vector3(playerHp/100, 1f);
	}
	
}
