using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource audioEnemyCollision;



    void OnTriggerEnter(Collider other)

    {

        if (other.tag == "BarRight")

        {

            audioEnemyCollision.Play();

        }

    }
}
