using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public Text hint;
	public AudioSource audioSource;
	public float textSpeed = 0.05f;

	public bool dialogueActive;

	// Use this for initialization
	void Start () {
		hint.text = "";

		if (!dialogueActive) {
		    dBox.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hint.text != "" && dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
			dBox.SetActive(false);
			dialogueActive = false;
			dText.text = "blank";
			hint.text = "";
		}
	}

	public void ShowDialogueBox(string dialogue, AudioClip voice) {
		dialogueActive = true;
		dBox.SetActive(true);
		dText.text = "";

		StartCoroutine(writer(dialogue, voice));
    }

	IEnumerator writer(string dialogue, AudioClip voice)
	{
		audioSource.clip = voice;

		audioSource.Play();
		audioSource.loop = true;

		foreach (var letter in dialogue.ToCharArray())
		{
			dText.text += letter;
			yield return new WaitForSeconds(textSpeed);
		}
		audioSource.Pause();

		hint.text = "Press Space to Continue";
	}
}
