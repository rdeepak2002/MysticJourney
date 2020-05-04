using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TimelineManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        //director.Pause();
        //Debug.Log(dialogueManager.dialogueActive);
        if (dialogueManager.dialogueActive)
        {
            director.Pause();
        }
        else
        {
            director.Play();
        }
    }
}
