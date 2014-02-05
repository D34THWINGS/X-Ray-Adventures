﻿using UnityEngine;
using System.Collections;

public class Door : TriggerListener {
	
	public GameObject DoorBody;
	public Transform Target;
	public float Speed = 2f;
	public bool IsOpened = false;

	[HideInInspector]
	public GameObject Origin;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		Origin = new GameObject();
		Origin.transform.position = DoorBody.transform.position;
		Origin.transform.rotation = DoorBody.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (!IsOpened) {
			DoorBody.transform.position = Vector2.Lerp(DoorBody.transform.position, Origin.transform.position, Time.deltaTime * Speed);
			DoorBody.transform.rotation = Quaternion.Lerp(DoorBody.transform.rotation, Origin.transform.rotation, Time.deltaTime * Speed);
		} else {			
			DoorBody.transform.position = Vector2.Lerp(DoorBody.transform.position, Target.position, Time.deltaTime * Speed);
			DoorBody.transform.rotation = Quaternion.Lerp(DoorBody.transform.rotation, Target.rotation, Time.deltaTime * Speed);
		}
	}

	protected override void TriggerAction (TriggeringMechanism.EventNames eventName)
	{
		print("triggered");
		switch(eventName) {
		case TriggeringMechanism.EventNames.ENABLE:
			IsOpened = true;
			break;
		case TriggeringMechanism.EventNames.DISABLE:
			IsOpened = false;
			break;
		default:
			break;
		}
	}
}