using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ͽ� ���, ���� ���, ����->���� �̵�, ����->���� �̵�
public enum MoleState { UnderGround = 0, OnGround, MoveUp, MoveDown }
// �δ��� ����(�⺻, ���� -, �ð� +)
public enum MoleType { Normal = 0, Red, Blue }

public class MoleFSM : MonoBehaviour
{
    [SerializeField]
    public GameController gameController;   // �޺� �ʱ�ȭ�� ���� GameController

    public float waitTimeOnGround;   // ���鿡 �ö�ͼ� ����������� ��ٸ��� �ð� 

    public float limitMinY;   // ������ �� �ִ� �ּ� y ��ġ

    public float limitMaxY;   // �ö�� �� �ִ� �ִ� y ��ġ

    private Movement3D movement3D;   // ��/�Ʒ� �̵��� ���� Movement3D

    private MeshRenderer meshRenderer;   // �δ����� ���� ������ ���� MeshRenderer

    private MoleType moleType;   // �δ����� ����
    private Color defaultColor;   // �⺻ �δ����� ����(173, 135, 24)

    // �δ����� ���� ���� (set�� MoleFSM Ŭ���� ���ο�����)
    public MoleState MoleState { private set; get; }
    // �δ����� ���� (MoleType�� ���� �δ��� ���� ����)
    public MoleType MoleType
    {
        set
        {
            moleType = value;

            switch (moleType)
            {
                case MoleType.Normal:
                    meshRenderer.material.color = defaultColor;
                    break;
                case MoleType.Red:
                    meshRenderer.material.color = Color.red;
                    break;
                case MoleType.Blue:
                    meshRenderer.material.color = Color.blue;
                    break;
            }
        }
        get => moleType;
    }

    // �δ����� ��ġ�Ǿ� �ִ� ���� (���� ��ܺ��� 0)
    [field:SerializeField]
    public int MoleIndex { private set; get; }

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        meshRenderer = GetComponent<MeshRenderer>();

        defaultColor = meshRenderer.material.color;   // �δ����� ���� ���� ����

        ChangeState(MoleState.UnderGround);
    }

    public void ChangeState(MoleState newState)
    {
        // ������ ������ ToString() �޼ҵ带 �̿��� ���ڿ��� ��ȯ�ϸ�
        // "UnderGround"�� ���� ������ ��� �̸� ��ȯ

        // ������ ������̴� ���� ����
        StopCoroutine(MoleState.ToString());
        // ���� ����
        MoleState = newState;
        // ���ο� ���� ���
        StartCoroutine(MoleState.ToString());
    }

    /// <summary>
    /// �δ����� �ٴڿ��� ����ϴ� ���·� ������ �ٴ� ��ġ�� �δ��� ��ġ ����
    /// </summary>
    private IEnumerator UnderGround()
    {
        // �̵������� : (0, 0, 0) [����]
        movement3D.MoveTo(Vector3.zero);
        // �δ����� y ��ġ�� Ȧ�� �����ִ� limitMinY ��ġ�� ����
        transform.position = new Vector3(transform.position.x, limitMinY, transform.position.z);

        yield return null;
    }

    /// <summary>
    /// �δ����� Ȧ ������ �����ִ� ���·� waitTimeOnGround���� ���
    /// </summary>
    private IEnumerator OnGround()
    {
        // �̵������� : (0, 0, 0) [����]
        movement3D.MoveTo(Vector3.zero);
        // �δ����� y ��ġ�� Ȧ ������ �����ִ� limitMaxY ��ġ�� ����
        transform.position = new Vector3(transform.position.x, limitMaxY, transform.position.z);

        // waitTimeOnGround �ð� ���� ���
        yield return new WaitForSeconds(waitTimeOnGround);

        // �δ����� ���¸� MoveDown���� ����
        ChangeState(MoleState.MoveDown);
    }

    /// <summary>
    /// �δ����� Ȧ ������ �����ִ� ���� (maxYPosOnGround ��ġ���� ���� �̵�)
    /// </summary>
    private IEnumerator MoveUp()
    {
        // �̵����� : (0, 1, 0) [��]
        movement3D.MoveTo(Vector3.up);

        while (true)
        {
            // �δ����� y ��ġ�� limitMaxY�� �����ϸ� ���� ����
            if (transform.position.y >= limitMaxY)
            {
                // OnGround ���·� ����
                ChangeState(MoleState.OnGround);
            }

            yield return null;
        }
    }

    /// <summary>
    /// �δ����� Ȧ�� ���� ���� (minYPosUnderGround ��ġ���� �Ʒ��� �̵�)
    /// </summary>
    private IEnumerator MoveDown()
    {
        // �̵����� : (0, -1, 0) [�Ʒ�]
        movement3D.MoveTo(Vector3.down);

        while (true)
        {
            // �δ����� y ��ġ�� limitMinY�� �����ϸ� �ݺ��� ����
            if (transform.position.y <= limitMinY)
            {
                // UnderGround ���·� ����
                //ChangeState(MoleState.UnderGround);
                break;   // while() �Ʒ��� ������ ���� �̵� �Ϸ�� break;
            }

            yield return null;
        }

        // ��ġ�� Ÿ�� ������ �ʰ� �ڿ������� �������� �� �� ȣ��
        // MoveDown -> UnderGround

        // ��ġ�� ������ ���ϰ� �������� �� �δ����� �Ӽ��� Normal�̸� �޺� �ʱ�ȭ
        if (moleType == MoleType.Normal)
        {
            gameController.Combo = 0;
        }

        // UnderGround ���·� ����
        ChangeState(MoleState.UnderGround);
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
