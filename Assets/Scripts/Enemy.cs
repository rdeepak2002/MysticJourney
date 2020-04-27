using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int health;
	public string enemyName;
	public string dialogue;
	public int baseAttack;
	public float moveSpeed;
	public float battleRadius;
	public float attackRadius;
	public Transform target;
	public Transform cameraFocus;
	public AudioSource audioSource;
	public AudioClip bossMusic;
	public CameraMovement cameraMovementScript;
	public PlayerMovement playerMovementScript;
	public DialogueManager dialogueManager;
	public HudManager hudManager;
	public AudioClip voice;
	public bool dialogueDisplayed = false;
	protected Animator animator;
	protected bool preparedForBattle = false;

	protected void checkDistance() {
        if (!preparedForBattle && Vector3.Distance(target.position, transform.position) <= battleRadius) {
			prepareForBattle();
		}
	}

	protected void prepareForBattle() {
		playerMovementScript.movieScenePlaying = true;
		audioSource.Pause();
		cameraMovementScript.target = cameraFocus;
		manageDialogue();
    }

	public void manageDialogue() {
		if (!dialogueDisplayed) {
			dialogueManager.ShowDialogueBox(dialogue, voice);
			dialogueDisplayed = true;
		}

		if (!dialogueManager.dialogueActive && !preparedForBattle){
			hudManager.showHud();
			audioSource.clip = bossMusic;
			audioSource.Play();
			playerMovementScript.movieScenePlaying = false;
			animator.SetBool("attacking", true);
			preparedForBattle = true;
		}
	}

	public void facePlayer() {
		if (target.position.x >= transform.position.x) {
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
	}

	protected void moveTowards() {
		transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
	}
}
