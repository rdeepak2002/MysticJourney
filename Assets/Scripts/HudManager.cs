using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour {
	public GameObject bars;

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
			bars.SetActive(true);
        }
	}

	public void showHud() {
		hudActive = true;
	}
}
