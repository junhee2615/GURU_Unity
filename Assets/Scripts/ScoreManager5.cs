using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager5 : MonoBehaviour
{
    public Text currentScoreUI;

    public int currentScore;

    public Text bestScoreUI;

    public int bestScore;


    // Start is called before the first frame update
    void Start()
    {
        // 목표 : 최고점수 불러와서 bestscore 변수에 할당하고 화면에 표시
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
