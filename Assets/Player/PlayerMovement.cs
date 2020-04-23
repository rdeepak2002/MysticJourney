﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float walkingSpeed;
	public float runningSpeed;
	public bool isRunning;
	public bool movieScenePlaying;
	
	private Rigidbody2D myRigidBody;
	private Vector3 change;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		change = Vector3.zero;
		if (!movieScenePlaying) {
			change.x = Input.GetAxisRaw("Horizontal");
			change.y = Input.GetAxisRaw("Vertical");
		}
		UpdateAnimationAndMove();
	}

	void UpdateAnimationAndMove() {
		animator.SetBool("running", isRunning);

		if (Input.GetKeyDown("right shift")) {
			isRunning = !isRunning;
		}

		if(change != Vector3.zero) {
			MoveCharacter();
			animator.SetFloat("moveX", change.x);
			animator.SetFloat("moveY", change.y);
			animator.SetBool("moving", true);
		}
		else {
			animator.SetBool("moving", false);
		}
	}

	void MoveCharacter() {
		float speed = walkingSpeed;

		if(isRunning) {
			speed = runningSpeed;
		}

		myRigidBody.MovePosition(
			transform.position + change * speed * Time.deltaTime
		);
	}
}
