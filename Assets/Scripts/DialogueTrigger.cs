using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;
    public AudioSource Music;

    public void Trigger()
    {
        Music.Play();

        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);
    }
}
