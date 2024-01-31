using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallScript : MonoBehaviour
{

    public AudioSource audioBarRightCollision;
    void OnTriggerEnter2(Collider other)

    {

        if (other.tag == "Bar")

        {

            audioBarRightCollision.Play();

        }

    }

    public float ballSpeed;
    public AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play();
    }

    void Init()
    {
        transform.position = new Vector3(0, 0, 0);
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(ballSpeed * sx, ballSpeed * sy, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("left"))
        {
            GameObject.Find("GameManager4").GetComponent<GameManager4>().PlusRight();
            Init();
        }
        if (other.CompareTag("right"))
        {
            GameObject.Find("GameManager4").GetComponent<GameManager4>().PlusLeft();
            Init();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Racket")
        {
            PlaySound();
        }
    }
}