using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject StartScreen;

    public Text scoreText;
    public GameObject endGroup;
    public Text subScoreText;

    public GameObject line;
    public GameObject bottom;
    public GameObject wall;
    public GameObject wall1;

    public AudioSource bgmPlayer;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 1.5f)
        {
            Destroy(StartScreen);

            line.SetActive(true);
            bottom.SetActive(true);
            wall.SetActive(true);
            wall1.SetActive(true);
            scoreText.gameObject.SetActive(true);

            bgmPlayer.Play();

            time = 0;
        }
    }
}
