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
            // 70 이상일 땐 MaxSpawnMole이 5로 고정되기 때문에 70까지만 체크
            if (combo <= 70)
            {
                // 콤보에 따라 생성되는 최대 두더지 숫자
                moleSpawner.MaxSpawnMole = 1 + (combo + 10) / 20;
            }

            // 최대 콤보 저장
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

        // CurrentTime이 0이 되면 GameOver() 메소드를 호출해 게임오버 처리
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
