﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamHealth : MonoBehaviour {

	
	[SerializeField]private PlayerHealth playerHealth;
	private Transform bar;
	private float _totalHpFirst,_totalHp;
	public Text healthbarText;

    private TurnMaker turnMaker;
    private string teamColor;
	
	void Awake(){
		//these variables are just to simulate round 2
		_totalHpFirst = 0;
		_totalHp = 0;
        turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
        
		
    }
	// Use this for initialization
	void Start ()
    {
        
        setTotalHp();
    }

    void Update()
    {
        // teamColor = turnMaker.GetColor();
    }
	//Sets the size of the bar gameobject which is representing the healthbar of the teams
	//method should perhaps be called setHealth
	public void setSize(float dmg)
	{		
		bar = this.transform.Find("Bar");
		Canvas hpCanvas = this.transform.Find("TeamBarCanvas").GetComponent<Canvas>();
		healthbarText = hpCanvas.GetComponentInChildren<Text>();
		float relation = 0;
		
		if(_totalHp > _totalHpFirst){
			_totalHpFirst = _totalHp;
		}
		else {

		_totalHp -= dmg;
		}
		print(_totalHp + "total");
		print(_totalHpFirst + "first");
		relation = _totalHp/_totalHpFirst;
		print(relation);
		bar.localScale = new Vector3((relation), 1f);			
		healthbarText.text = (relation * 100) + "%";
		
	}	
	
	public void setTotalHp(){
       //Check here if there any active players and go to win scene
				// print(transform.name);				
				Transform teamTrans;
				string team = "";
				string teamColor = transform.name;
				  team =lookForTeam(teamColor.Substring(9));
				  print(team );
				 
					  teamTrans = GameObject.Find(team).GetComponent<Transform>();
					  foreach(Transform playertrans in teamTrans){
						  if(playertrans.CompareTag("Player")){

					print(playertrans.name + "player tranny");
				playerHealth = playertrans.GetComponent<PlayerHealth>();				
					
				_totalHp += playerHealth.getPlayerHp();	

				}
				
			
					  }		
			
			_totalHpFirst = _totalHp;

	}
	
	public string lookForTeam(string input){
		
		if(input == "Blue"){
			return "TeamBlue";
		}else {
			return "TeamGreen";
		}


	}
	
}
