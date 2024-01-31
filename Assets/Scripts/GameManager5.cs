using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager5 : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager5 instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentCombo;
    public int ComboTracker;
    public int[] ComboThresholds;

    public Text scoreText;
    public Text ComboText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen, gameoverScreen, nextstageScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentCombo = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if (!theMusic.isPlaying)
            {
                resultsScreen.SetActive(true);                

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if (percentHit > 40)
                {
                    rankVal = "D";

                    if (percentHit > 55)
                    {
                        rankVal = "C";
                        if (percentHit > 70)
                        {
                            rankVal = "B";
                            if (percentHit > 85)
                            {
                                rankVal = "A";
                                if (percentHit > 95)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if(percentHit > 70)
                    {
                        nextstageScreen.SetActive(true);
                    }
                    else
                    {
                        gameoverScreen.SetActive(true);
                    }
                }
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentCombo - 1 < ComboThresholds.Length)
        {
            ComboTracker++;

            if (ComboThresholds[currentCombo - 1] <= ComboTracker)
            {
                ComboTracker = 0;
                currentCombo++;
            }
        }

        ComboText.text = "Combo: x" + currentCombo;

        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentCombo;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentCombo;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentCombo;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentCombo = 1;
        ComboTracker = 0;

        ComboText.text = "Combo: x" + currentCombo;

        missedHits++;
    }
}
