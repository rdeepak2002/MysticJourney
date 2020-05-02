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
            StartCoroutine(Fire(3, 60, 0.8f, 10.0f));
        }
    }

	IEnumerator Fire(int n, double angle, float waitTime, float speed) {
		busy = true;

		Vector3 direction = target.position - firehand.transform.position;
		direction.Normalize();

		float xComp = direction.x;
		float yComp = direction.y;

		for (int i = -n/2; i < n/2+1; i++) {
			if (!(n % 2 == 0 && i == 0) || n*angle >= 360) {
				double theta = i * (angle * DegToRad);

				float ca = (float)Math.Cos(theta);
				float sa = (float)Math.Sin(theta);

				Vector3 newDir = new Vector3(ca * xComp - sa * yComp, sa * xComp + ca * yComp, 0);


				fireball.GetComponent<EnemyProjectile>().change = newDir;
				fireball.GetComponent<EnemyProjectile>().speed = speed;
				Instantiate(fireball, firehand.transform.position, Quaternion.identity);
			}
        }

		yield return new WaitForSeconds(waitTime);


		busy = false;
	}
}
