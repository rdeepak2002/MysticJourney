﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour {
	public string gameSceneName;

	public GameObject fadeInPanel;
	public GameObject fadeOutPanel;

    public AudioSource music;
	public AudioSource sfx;
	public AudioClip startSFX;

	public void Awake()
	{
		GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
		Destroy(panel, 4);
	}

	public void changeScene(string sceneName) {
        music.mute = true;
		sfx.loop = false;
		sfx.clip = startSFX;
		sfx.Play();
        GameObject panel = Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity) as GameObject;
		Invoke("MyLoadingFunction", 5f);
		Destroy(panel, 10);
	}

	void MyLoadingFunction()
	{
		SceneManager.LoadScene(gameSceneName);
	}
}