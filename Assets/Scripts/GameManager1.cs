using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public Dongle lastDongle;
    public GameObject donglepPrefab;
    public Transform dongleGroup;
    public GameObject effectPrefab;
    public Transform effectGroup;
    public List<Dongle> donglePool;

    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx
    {
        LevelUp,
        Next,
        Attach,
        Button,
        Over
    };

    int sfxCursor;

    public int score;
    public int maxLevel;
    public bool isOver;

    [Range(1, 30)]
    public int poolSize;
    public int poolCursor;

    public GameObject startGroup;
    public Text scoreText;
    public GameObject endGroup;
    public Text subScoreText;

    public GameObject gameoverScreen, nextstageScreen;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SfxPlay(Sfx.Button);
        Invoke("NextDongle", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (score > 300)
            {
                nextstageScreen.SetActive(true);
                Debug.Log("다음 스테이지");
            }
            else
            {
                gameoverScreen.SetActive(true);
                Debug.Log("재시도");
            }
            Debug.Log("!!!");
        }
    }

    Dongle GetDongle()
    {
        // 이펙트 생성
        GameObject instantEffectObj = Instantiate(effectPrefab, effectGroup);
        ParticleSystem instantEffect = instantEffectObj.GetComponent<ParticleSystem>();

        // 동글 생성
        GameObject instant = Instantiate(donglepPrefab, dongleGroup);
        Dongle instantDongle = instant.GetComponent<Dongle>();
        instantDongle.effect = instantEffect;
        return instantDongle;
    }

    void NextDongle()
    {
        if(isOver)
        {
            return;
        }

        Dongle newDongle = GetDongle();
        lastDongle = newDongle;
        lastDongle.manager = this;
        lastDongle.level = Random.Range(0, maxLevel);
        lastDongle.gameObject.SetActive(true);

        SfxPlay(Sfx.Next);
        StartCoroutine("WaitNext");
    }

    IEnumerator WaitNext()
    {
        while(lastDongle != null)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2.5f);

        NextDongle();
    }

    public void TouchDown()
    {
        if(lastDongle == null)
        {
            return;
        }
        lastDongle.Drag();
    }

    public void TouchUp()
    {
        if (lastDongle == null)
        {
            return;
        }

        lastDongle.Drop();
        lastDongle = null;
    }

    public void GameOver()
    {
        if(isOver)
        {
            return;
        }

        StartCoroutine("GameOverRoutine");
    
    }

    IEnumerator GameOverRoutine()
    {
        isOver = true;

        // 장면 안에 활성화 되어있는 모든 동글 가져오기
        Dongle[] dongles = GameObject.FindObjectsOfType<Dongle>();

        // 지우기 전에 모든 동글의 물리효과 비활성화
        for(int index = 0; index < dongles.Length; index++)
        {
            dongles[index].rigid.simulated = false;
        }

        // 목록을 하나씩 접근해서 지우기
        for (int index = 0; index < dongles.Length; index++)
        {
            dongles[index].Hide(Vector3.up * 100);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        subScoreText.text = "점수 : " + scoreText.text;
        endGroup.SetActive(true);

        bgmPlayer.Stop();
        SfxPlay(Sfx.Over);
    }

    public void Reset()
    {
        SfxPlay(Sfx.Button);
        StartCoroutine("ResetCoroutine");
    }

    IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");

    }

    public void SfxPlay(Sfx type)
    {
        switch(type)
        {
            case Sfx.LevelUp:
                sfxPlayer[sfxCursor].clip = sfxClip[Random.Range(0, 3)];
                break;
            case Sfx.Next:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                break;
            case Sfx.Attach:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                break;
            case Sfx.Button:
                sfxPlayer[sfxCursor].clip = sfxClip[5];
                break;
            case Sfx.Over:
                sfxPlayer[sfxCursor].clip = sfxClip[6];
                break;
        }

        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }

    void LateUpdate()
    {
        scoreText.text = score.ToString();
    }
}
