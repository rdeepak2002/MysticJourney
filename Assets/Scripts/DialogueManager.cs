using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public TextMeshProUGUI dText;
	public TextMeshProUGUI hint;
	public AudioSource audioSource;
    public AudioClip voice;
	public float textSpeed = 0.05f;

	public bool dialogueActive;

	// Use this for initialization
	void Start () {
		dText.text = "";
		hint.text = "";

		dialogueActive = false;
		dBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (hint.text != "" && dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
			HideDialogueBox();
		}
	}

	public void HideDialogueBox() {
		audioSource.Stop();
		dBox.SetActive(false);
		dialogueActive = false;
		dText.text = "blank";
		hint.text = "";
	}

	public void ShowDialogueBox(string dialogue) {
		dialogueActive = true;
		dBox.SetActive(true);
		dText.text = "";

		StartCoroutine(writer(dialogue));
    }

	IEnumerator writer(string dialogue)
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
