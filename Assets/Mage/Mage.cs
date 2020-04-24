using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy {

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		facePlayer();
		checkDistance();
		if (preparedForBattle) {
			battleLoop();
		}
	}

	void battleLoop() {

    }
}
