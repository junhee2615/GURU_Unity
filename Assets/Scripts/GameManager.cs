using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private float GameTime = 30f;
    public Text GameTimeText;

    public GameObject imageRestart;
    public GameObject gameoverScreen, nextstageScreen;

    public Text currentScoreUI;

    public int currentScore;

    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    public enum GameState
    {
        Ready,
        Run,
        GameOver
    }

    public GameState gState;

    public GameObject gameLabel;

    Text gameText;

    PlayerMove2 player;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;

        gameText = gameLabel.GetComponent<Text>();

        gameText.text = "Ready...";

        gameText.color = new Color32(255, 0, 0, 255);

        StartCoroutine(ReadyToStart());

        player = GameObject.Find("Player").GetComponent<PlayerMove2>();

        imageRestart.SetActive(false);
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(1f);

        gameText.text = "Go!";

        yield return new WaitForSeconds(0.5f);

        gameLabel.SetActive(false);

        gState = GameState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTime <= 0)
        {
            if (currentScore >= 30)
            {
                gameLabel.SetActive(true);

                gameText.text = "Clear!";

                gameText.color = new Color32(255, 0, 0, 255);

                nextstageScreen.SetActive(true);
            }

            else
            {
                gameLabel.SetActive(true);

                gameText.text = "Game Over!";

                gameText.color = new Color32(255, 0, 0, 255);

                gameoverScreen.SetActive(true);
            }
        }

        else
        {
            GameTime -= Time.deltaTime;
            Debug.Log((int)GameTime);
            GameTimeText.text = "Time: " + (int)GameTime;
        }

    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
