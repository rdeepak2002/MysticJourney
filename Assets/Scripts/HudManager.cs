using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HudManager : MonoBehaviour {
	public GameObject player;
	public GameObject bars;
	public Image[] hearts;
	public Image[] manas;
	public Image[] specials;
	public bool hudActive;

    // Use this for initialization
    void Start () {
		if (!hudActive)
		{
			bars.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hudActive) {
			int health = player.GetComponent<PlayerMovement>().health;
			int mana = player.GetComponent<PlayerMovement>().mana;
			int special = player.GetComponent<PlayerMovement>().special;

			for (int i = hearts.Length-1; i >= 0; i--) {
				if (i < health)
				{
					hearts[i].gameObject.SetActive(true);
				}
				else {
					hearts[i].gameObject.SetActive(false);
				}
			}

			for (int i = manas.Length - 1; i >= 0; i--)
			{
				if (i < mana)
				{
					Debug.Log(i);
					manas[i].gameObject.SetActive(true);
				}
				else
				{
					manas[i].gameObject.SetActive(false);
				}
			}

			for (int i = specials.Length - 1; i >= 0; i--)
			{
				if (i < special)
				{
					Debug.Log(i);
					specials[i].gameObject.SetActive(true);
				}
				else
				{
					specials[i].gameObject.SetActive(false);
				}
			}


			bars.SetActive(true);
        }
	}

	public void showHud() {
		hudActive = true;
	}
}
