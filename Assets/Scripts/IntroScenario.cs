using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScenario : MonoBehaviour
{
    public Movement3D[] movementMoles;   // �δ������� ���� �̵���Ű�� ���� Movement3D
    public GameObject[] textMoles;   // �δ��� ���� ���� ȹ�� ������ ȿ�� ��� Text
    public GameObject textPressAnyKey;   // "Press Any Key" ��� Text
    public float maxY = 1.5f;   // �δ����� �ö�� �� �ִ� �ִ� ����
    private int currentIndex = 0;  // �δ����� ������� �����ϵ��� ������ ����

    private void Awake()
    {
        StartCoroutine("Scenario");
    }

    private IEnumerator Scenario()
    {
        // �δ����� Normal -> Red -> Blue ������� ����
        while (currentIndex < movementMoles.Length)
        {
            yield return StartCoroutine("MoveMole");
        }


        // "Press Any Key"  �ؽ�Ʈ ��� 
        textPressAnyKey.SetActive(true);

        // ���콺 ���� ��ư�� ������ "Game" ������ �̵�
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
            // �δ����� ��ǥ������ �����ϸ� while() �ݺ��� ����
            if (movementMoles[currentIndex].transform.position.y >= maxY)
            {
                movementMoles[currentIndex].MoveTo(Vector3.zero);
                break;
            }

            yield return null;
        }

        // �δ����� ȹ������ �� ȿ�� �ؽ�Ʈ ���
        textMoles[currentIndex].SetActive(true);
        // ���� �δ����� �����ϵ��� �ε��� ����
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
