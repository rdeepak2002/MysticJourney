using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
	public GameObject player;
	public int damage = 1;
	public float speed = 1f;
	public Vector3 change;

	private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		move();
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	private void move()
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player")
		{
			collision.GetComponent<PlayerMovement>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}

}
