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
        // ��ǥ : �ְ����� �ҷ��ͼ� bestscore ������ �Ҵ��ϰ� ȭ�鿡 ǥ��
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "�ְ����� : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
