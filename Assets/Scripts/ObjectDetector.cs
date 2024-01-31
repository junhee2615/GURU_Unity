using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{
    public class RaycastEvent : UnityEvent<Transform> { }   // �̺�Ʈ Ŭ���� ����
                                                            // ��ϵǴ� �̺�Ʈ �޼ҵ�� Transform �Ű����� 1���� ������ �޼ҵ�

    public RaycastEvent raycastEvent = new RaycastEvent();   // �̺�Ʈ Ŭ���� �ν��Ͻ� ���� �� �޸� �Ҵ�

    private Camera mainCamara;   // ������ �����ϱ� ���� Camera
    private Ray ray;   // ������ ���� ���� ������ ���� Ray
    private RaycastHit hit;   // ������ �ε��� ������Ʈ ���� ������ ���� RaycastHit

    private void Awake()
    {
        // "MainCamera" �±׸� ������ �ִ� ������Ʈ Ž�� �� Camera ������Ʈ ���� ����
        // 2020.2 ���� : GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); �� ����
        // 2020.2 �������� ������ Camera ����Ʈ�� ��Ƶα� ������ �� �� ����������.
        // 2020.2 ���������� ĳ���ϴ� ���� �ʼ������� 2020.2���ʹ� ���û��� (ĳ�� or Camera.main �״�� ���)
        mainCamara = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // ī�޶� ��ġ���� ȭ���� ���콺 ��ġ�� �����ϴ� ���� ����
            // ray.origin : ������ ������ġ(=ī�޶� ��ġ)
            // ray.direction : ������ �������
            ray = mainCamara.ScreenPointToRay(Input.mousePosition);

            // 2D ����͸� ���� 3D ������ ������Ʈ�� ���콺�� �����ϴ� ���
            // ������ �ε����� ������Ʈ�� �����ؼ� hit�� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // �ε��� ������Ʈ�� Transform ������ �Ű������� �̺�Ʈ ȣ��
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}
