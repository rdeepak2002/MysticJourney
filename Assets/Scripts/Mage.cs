using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mage : Enemy {
	public GameObject fireball;
	public GameObject firehand;

	private bool busy = false;

	private const double DegToRad = Math.PI / 180;

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
		if (!busy) {
            StartCoroutine(Fire(3, 45));
        }
    }

	IEnumerator Fire(int n, double angle) {
		busy = true;

		Vector3 direction = target.position - firehand.transform.position;
		direction.Normalize();

		float xComp = direction.x;
		float yComp = direction.y;

		for (int i = -1; i < 2; i++) {

            double theta = i*(angle * DegToRad);

			float ca = (float)Math.Cos(theta);
			float sa = (float)Math.Sin(theta);

			Vector3 newDir = new Vector3(ca * xComp - sa * yComp, sa * xComp + ca * yComp, 0);


			fireball.GetComponent<EnemyProjectile>().change = newDir;
			Instantiate(fireball, firehand.transform.position, Quaternion.identity);
        }

		yield return new WaitForSeconds(0.2f);


		busy = false;
	}
}
