using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score;
    private int combo;
    private float currentTime;
    public CountDown countDown;
    public MoleSpawner moleSpawner;

    public GameObject gameoverScreen, nextstageScreen;

    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }

    public int Combo
    {
        //set => combo = Mathf.Max(0, value);
        set
        {
            combo = Mathf.Max(0, value);
            // 70 �̻��� �� MaxSpawnMole�� 5�� �����Ǳ� ������ 70������ üũ
            if (combo <= 70)
            {
                // �޺��� ���� �����Ǵ� �ִ� �δ��� ����
                moleSpawner.MaxSpawnMole = 1 + (combo + 10) / 20;
            }

            // �ִ� �޺� ����
            if (combo > MaxCombo)
            {
                MaxCombo = combo;
            }
        }
        get => combo;
    }

    public int MaxCombo { private set; get; }

    public int NormalMoleHitCount { set; get; }
    public int RedMoleHitCount { set; get; }
    public int BlueMoleHitCount { set; get; }

    [field:SerializeField]
    public float MaxTime { private set; get; }
    // public float CurrentTime { private set; get; }
    public float CurrentTime
    {
        set => currentTime = Mathf.Clamp(value, 0, MaxTime);
        get => currentTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        countDown.StartCountDown(GameStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStart()
    {
        moleSpawner.Setup();

        StartCoroutine("OnTimeCount");
    }

    private IEnumerator OnTimeCount()
    {
        CurrentTime = MaxTime;

        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;

            yield return null;
        }

        // CurrentTime�� 0�� �Ǹ� GameOver() �޼ҵ带 ȣ���� ���ӿ��� ó��
        GameOver();
    }

    private void GameOver()
    {
        if (score > 1800)
        {
            nextstageScreen.SetActive(true);
        }
        else
        {
            gameoverScreen.SetActive(true);
        }
    }
}
