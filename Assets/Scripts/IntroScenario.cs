using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScenario : MonoBehaviour
{
    public Movement3D[] movementMoles;   // 두더지들을 위로 이동시키기 위한 Movement3D
    public GameObject[] textMoles;   // 두더지 색상에 따라 획득 가능한 효과 출력 Text
    public GameObject textPressAnyKey;   // "Press Any Key" 출력 Text
    public float maxY = 1.5f;   // 두더지가 올라올 수 있는 최대 높이
    private int currentIndex = 0;  // 두더지가 순서대로 등장하도록 순번을 관리

    private void Awake()
    {
        StartCoroutine("Scenario");
    }

    private IEnumerator Scenario()
    {
        // 두더지가 Normal -> Red -> Blue 순서대로 등장
        while (currentIndex < movementMoles.Length)
        {
            yield return StartCoroutine("MoveMole");
        }


        // "Press Any Key"  텍스트 출력 
        textPressAnyKey.SetActive(true);

        // 마우스 왼쪽 버튼을 누르면 "Game" 씬으로 이동
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Stage3");
            }

            yield return null;
        }
    }

    private IEnumerator MoveMole()
    {
        movementMoles[currentIndex].MoveTo(Vector3.up);

        while (true)
        {
            // 두더지가 목표지점에 도착하면 while() 반복문 종료
            if (movementMoles[currentIndex].transform.position.y >= maxY)
            {
                movementMoles[currentIndex].MoveTo(Vector3.zero);
                break;
            }

            yield return null;
        }

        // 두더지를 획득했을 때 효과 텍스트 출력
        textMoles[currentIndex].SetActive(true);
        // 다음 두더지를 설정하도록 인덱스 증가
        currentIndex++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
