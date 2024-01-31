using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject Puzzle;
    public GameObject StartBtn;
    public GameObject ManualBtn;

    public float time;

    public AudioSource Music, backMusic;

    // Start is called before the first frame update
    void Start()
    {
        Music.Play();
        backMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 3f)
        {
            Destroy(Puzzle);
            StartBtn.SetActive(true);
            ManualBtn.SetActive(true);
        }
    }
}
