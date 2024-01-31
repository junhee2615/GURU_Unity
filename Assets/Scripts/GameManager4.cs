using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager4 : MonoBehaviour
{
    public PrefabManager prefabManager;
    public ItemManager itemManager;
    public GameObject CoverImage;
    public Text rightText;
    public Text leftText;
    public int rightSide;
    public int leftSide;
    private float currentTime;

    [field: SerializeField]
    public float MaxTime { private set; get; }
    // public float CurrentTime { private set; get; }
    public float CurrentTime
    {
        set => currentTime = Mathf.Clamp(value, 0, MaxTime);
        get => currentTime;
    }

    public GameObject gameoverScreen, nextstageScreen;

    // Start is called before the first frame update
    void Start()
    {
        rightText.text = "0";
        leftText.text = "0";

        StartCoroutine("OnTimeCount");
    }

    public void PlusRight()
    {
        rightSide = rightSide + 1;
    }

    public void PlusLeft()
    {
        leftSide = leftSide + 1;
    }

    public void OnClickStartButton()
    {
        CoverImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rightText.text = " " + rightSide;
        leftText.text = " " + leftSide;
    }

    private IEnumerator OnTimeCount()
    {
        CurrentTime = MaxTime;

        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;

            yield return null;
        }

        // CurrentTime이 0이 됐을 때 오른쪽 점수가 25점 이상이면 클리어, 반대는 실패
        if (rightSide >= 20)
        {
            GameClear();
        }
        else
        {
            GameOver();
        }
    }

    private void GameClear()
    {
        nextstageScreen.SetActive(true);
    }

    private void GameOver()
    {
        gameoverScreen.SetActive(true);
    }

}
