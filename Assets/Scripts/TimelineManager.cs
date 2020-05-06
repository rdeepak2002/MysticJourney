using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TimelineManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private PlayableDirector director;
    private bool canPlayDirector = true;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (director.playableGraph.IsValid()) {
            if (dialogueManager.dialogueActive)
            {
                director.playableGraph.GetRootPlayable(0).SetSpeed(0);
                canPlayDirector = true;
            }
            else if (canPlayDirector)
            {
                director.playableGraph.GetRootPlayable(0).SetSpeed(1);
                canPlayDirector = false;
            }
        }
    }
}
