using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogueActive;

	// Use this for initialization
	void Start () {
		if (!dialogueActive) {
		    dBox.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
			dBox.SetActive(false);
			dialogueActive = false;
			dText.text = "blank";
		}
	}

	public void ShowDialogueBox(string dialogue) {
		dialogueActive = true;
		dBox.SetActive(true);
		dText.text = dialogue;
    }
}
