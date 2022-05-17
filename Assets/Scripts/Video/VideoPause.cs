using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPause : MonoBehaviour, IInteractive
{
    [SerializeField] VideoPlayer video;

    bool interacted = false;
    public bool Interacted { get => interacted; set => interacted = value; }

    bool paused = false;

    public void Interact()
    {
        if (!paused)
        {
            paused = true;
            video.Pause();
        }
        else
        {
            video.Play();
            paused = false;
        }

        interacted = false;
    }

}
