using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CountDown : MonoBehaviour
{
    private class CountDownEvent : UnityEvent { }
    private CountDownEvent endOffCountDown;   // ī��Ʈ �ٿ� ���� �� �ܺ� �޼ҵ� ������ ���� �̺�Ʈ Ŭ���� ���

    private TextMeshProUGUI textCountDown;   // ī��Ʈ �ٿ� �ؽ�Ʈ�� ����ϴ� Text UI
    private AudioSource audioSource;   // ī��Ʈ �ٿ� ���� ���
     
    public int maxFontSize;   // ��Ʈ�� �ִ� ũ��
    public int minFontSize;   // ��Ʈ�� �ּ� ũ��

    private void Awake()
    {
        endOffCountDown = new CountDownEvent();
        textCountDown = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartCountDown(UnityAction action, int start = 3, int end = 1)
    {
        StartCoroutine(OnCountDown(action, start, end));
    }

    private IEnumerator OnCountDown(UnityAction action, int start, int end)
    {
        // action �޼ҵ带 �̺�Ʈ�� ���
        endOffCountDown.AddListener(action);

        while ( start > end-1 )
        {
            // ī��Ʈ �ٿ� ���� ���
            audioSource.Play();

            // ī��Ʈ �ٿ� �ؽ�Ʈ ����
            textCountDown.text = start.ToString();

            // ��Ʈ ũ�⸦ �����ϴ� �ִϸ��̼�(��� �Ϸ� �� �Ʒ� �ڵ� ����)
            yield return StartCoroutine("OnFontAnimation");

            // ī��Ʈ �ٿ� ���� 1 ����
            start--;
        }

        // action �޼ҵ带 ����
        endOffCountDown.Invoke();

        // action �޼ҵ带 �̺�Ʈ���� ����
        endOffCountDown.RemoveListener(action);

        // ī��Ʈ �ٿ� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    private IEnumerator OnFontAnimation()
    {
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime;

            // ��Ʈ ũ�⸦ 200���� 100���� percent �ð����� ����
            textCountDown.fontSize = Mathf.Lerp(maxFontSize, minFontSize, percent);

            yield return null;
        }
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
