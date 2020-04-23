using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public Text hint;

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

	public void ShowDialogueBox(string dialogue) {
		dialogueActive = true;
		dBox.SetActive(true);
		dText.text = "";

		StartCoroutine(writer(dialogue));
    }

	IEnumerator writer(string dialogue)
	{
		foreach (var letter in dialogue.ToCharArray())
		{
			dText.text += letter;
			yield return new WaitForSeconds(.07f);
		}

		hint.text = "Press Space to Continue";
	}
}
