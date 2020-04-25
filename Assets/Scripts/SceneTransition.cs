using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {
	public GameObject fadeInPanel;

	public void Awake() {
		GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
		Destroy(panel, 5);
    }
}
