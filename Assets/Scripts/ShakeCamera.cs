using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    // �̱��� ó���� ���� instance ���� ����
    private static ShakeCamera instance;
    // �ܺο����� Get ���ٸ� �����ϵ��� Instance ������Ƽ ����
    public static ShakeCamera Instance => instance;

    public float shakeTime;
    private float shakeIntensity;

    /// <summary>
    /// Main Camera ������Ʈ�� ������Ʈ�� �����ϸ�
    /// ������ ������ �� �޸� �Ҵ� / ������ �޼ҵ� ����
    /// �� �� �ڱ� �ڽ��� ������ instance ������ ����
    /// </summary>
    public ShakeCamera()
    {
        // �ڱ� �ڽſ� ���� ������ static ������ instance ������ �����ؼ�
        // �ܺο��� ���� ������ �� �ֵ��� ��
        instance = this;
    }

    /// <summary>
    /// �ܺο��� ī�޶� ��鸲�� ������ �� ȣ���ϴ� �޼ҵ�
    /// ex) OnShakeCamera(1);   => 1�ʰ� 0.1�� ����� ��鸲
    /// ex) OnShakeCamera(0.5f, 1);   => 0.5�ʰ� 1�� ����� ��鸲
    /// </summary>
    /// <param name = "shakeTime"> ī�޶� ��鸲 ���� �ð� (�������� ������ default 1.0f)
    /// <param name = "shakeIntensity"> ī�޶� ��鸲 ���� (���� Ŭ���� ���� ��鸰��)(�������� ������ default 0.1f)
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    /// <summary>
    /// ī�޶� shakeTime���� shakeIntensity�� ����� ���� �ڷ�ƾ �Լ�
    /// </summary>
    private IEnumerator ShakeByPosition()
    {
        // ��鸮�� ������ ���� ��ġ (��鸲 ���� �� ���ƿ� ��ġ)
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
            // Ư�� �ุ �����ϱ� ���ϸ� �Ʒ� �ڵ� �̿� (�̵����� ���� ���� 0 �� ���)
            // float x = Random.Range(-1f, 1f);
            // float y = Random.Range(-1f, 1f);
            // float z = Random.Range(-1f, 1f);
            // transform.position = startPosition + new Vector3(x, y, z) * shakeIntensity;

            // �ʱ� ��ġ�κ��� �� ����(Size 1 * shakeIntensity�� ���� �ȿ��� ī�޶� ��ġ ����
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            // �ð� ����
            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
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
