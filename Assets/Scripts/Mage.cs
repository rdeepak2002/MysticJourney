using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy {
	public GameObject fireball;
	public GameObject firehand;

	private bool busy = false;

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
            StartCoroutine(Fire3());
        }
    }

	IEnumerator Fire3() {
		busy = true;

		Vector3 direction = (target.position - firehand.transform.position);
		direction.Normalize();
		fireball.GetComponent<EnemyProjectile>().change = direction;
		Instantiate(fireball, firehand.transform.position, Quaternion.identity);

		yield return new WaitForSeconds(0.1f);
		busy = false;
	}
}
