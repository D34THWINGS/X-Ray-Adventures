﻿using UnityEngine;
using System.Collections;

public class Reshape : MonoBehaviour {
	public int OriginShape = 0;
	public Vector3 OriginSize;
	public bool isHeavy;
	public int CurrentShape {
		get {
			return _currentShape;
		}
		set {
			if (value == _currentShape) return;

			var glass = collider2D.sharedMaterial;
			print (glass);
			if (value == 0) {
				if (_currentShape == 1) {
					Destroy(GetComponent<CircleCollider2D>());
				} else if (_currentShape == 2) {

				}
				var box = gameObject.AddComponent<BoxCollider2D>();
				box.sharedMaterial = glass;
				//box.size = new Vector2(1.0f, 1.0f);
			} else if (value == 1) {
				if (_currentShape == 0) {
					Destroy(GetComponent<BoxCollider2D>());
				} else if (_currentShape == 2) {
					
				}
				var box = gameObject.AddComponent<CircleCollider2D>();
				box.sharedMaterial = glass;
				//box.size = new Vector2(1.0f, 1.0f);
			} else {
				return;
			}
			PreviousShape = _currentShape;
			_currentShape = value;
		}
	}
	public int PreviousShape { get; private set;}

	private int _currentShape = 0;
	private Animator animator;
	
	void Start () {
		CurrentShape = OriginShape;
		OriginSize = transform.localScale;
		animator = GetComponent<Animator>();
	}

	void Update () {		
		animator.SetInteger("Shape", CurrentShape);
		animator.SetInteger("PreviousShape", PreviousShape);	
	}
}
