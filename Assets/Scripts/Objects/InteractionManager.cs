﻿using UnityEngine;
using System.Collections;

namespace XRay.Objects {

	public class InteractionManager : MonoBehaviour {
		
		private GameObject _player;
		
		void Start(){
			var player = GameObject.Find("Player");
			if(player != null){
				_player = player;
			}
		}
		
		void OnTriggerEnter2D(Collider2D collision){
			if (collision.gameObject.name == "Player") return;
			InteractibleObject IO =  collision.GetComponent<InteractibleObject>();
			if(IO != null){
				IO.Interact(_player);
			}
		}
		
		void OnTriggerExit2D(Collider2D collision){
			if (collision.gameObject.name == "Player") return;
			InteractibleObject IO =  collision.GetComponent<InteractibleObject>();
			if(IO != null){
				IO.Unteract();
			}
		}	
	}
}
