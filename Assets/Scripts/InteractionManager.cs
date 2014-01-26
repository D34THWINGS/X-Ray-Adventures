﻿using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour {
	
	private GameObject _player;
	
	void Start(){
		var player = GameObject.Find("Player");
		if(player != null){
			_player = player;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		InteractibleObject IO =  collision.GetComponent<InteractibleObject>();
		if(IO != null){
			IO.Interact(_player);
		}
	}
	
	void OnTriggerExit2D(Collider2D collision){
		InteractibleObject IO =  collision.GetComponent<InteractibleObject>();
		Debug.Log(collision);
		if(IO != null){
			IO.Unteract(_player);
		}
	}	
}
