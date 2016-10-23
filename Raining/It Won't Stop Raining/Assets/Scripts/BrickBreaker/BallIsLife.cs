﻿using UnityEngine;
using System.Collections;

public class BallIsLife : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (0, -1 * speed);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity *= 0.9f;
		}
	}

	void OnCollisionEnter2D(Collider2D other){

	}
}
