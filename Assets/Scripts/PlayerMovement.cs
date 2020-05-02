using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public int health = 9;
	public int mana = 9;
	public int special = 0;
	public float walkingSpeed;
	public float runningSpeed;
	public bool isRunning;
	public bool movieScenePlaying;
	public bool isInvincible = false;
	public GameObject kyubue;

	private Vector3 change;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D myRigidBody;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
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

	public void TakeDamage(int damage) {
		if (!isInvincible) {
			health -= damage;
		}

		StartCoroutine(makeInvincible());
    }

	IEnumerator makeInvincible() {
		if (!isInvincible) {
			isInvincible = true;
			spriteRenderer.color = new Color(255, 0, 0);
			yield return new WaitForSeconds(0.5f);
			isInvincible = false;
			spriteRenderer.color = new Color(255, 255, 255);
		}
	}
}
