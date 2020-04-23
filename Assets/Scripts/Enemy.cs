using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public string enemyName;
	public int baseAttack;
	public float moveSpeed;
	public float battleRadius;
	public float attackRadius;
	public Transform target;
	public AudioSource audioSource;
	public AudioClip bossMusic;
	public CameraMovement cameraMovementScript;
	public bool preparedForBattle = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	protected void checkDistance() {
        if (!preparedForBattle && Vector3.Distance(target.position, transform.position) <= battleRadius) {
			prepareForBattle();
        }
	}

	protected void prepareForBattle() {
		audioSource.clip = bossMusic;
		audioSource.Play();
		preparedForBattle = true;
		cameraMovementScript.target = transform;
    }

	protected void moveTowards() {
		transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
	}
}
