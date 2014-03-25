﻿using UnityEngine;
using System.Collections;

namespace XRay.Mechanics.Triggering {

	public class Receptacle : TriggeringMechanism {
		void OnCollisionEnter2D(Collision2D theCollision) {
			if(theCollision.gameObject.name == "Support") {
				Trigger(EventNames.ENABLE);
			}
		}
		
		void OnCollisionExit2D(Collision2D theCollision) {
			if(theCollision.gameObject.name == "Support") {
				Trigger(EventNames.DISABLE);
			}
		}
	}
}