using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    GameObject player;
    Vector3 dir;

    float time;

    public GameObject explosionFactory;

    //Start is called before the first frame update
    void Start()
    {
        // 0���� 9���� ���߿� �ϳ��� �������� �����ͼ�
        int randValue = UnityEngine.Random.Range(0, 10);

        // ���� 3���� ������ �÷��̾� ����
        if (randValue < 4)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
        }

        //�׷��� ������ �Ʒ��������� ���ϰ�ʹ�
        else
        {
            //dir = Vector3.down;
            transform.position += speed * Time.deltaTime * dir;
        }
            dir.Normalize();
    }

    //void Start()
    //{
    //    //����(d)
    //    GameObject target = GameObject.Find("Player");
    //    dir = target.transform.position - transform.position;
    //    dir.Normalize();
    //    //�ӵ�(s)
    //    speed = 3.0f;
    //    //�ð�(t)
    //    time = Time.deltaTime;
    //}



    // Update is called once per frame
    void Update()
    {
        // 1. ������ ���Ѵ�
        // Vector3 dir = Vector3.down;

        // 2. �̵��ϰ� �ʹ�. ���� P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    // �浹����
    private void OnCollisionEnter(Collision other)
    {
        GameObject smObject = GameObject.Find("GameManager");
        GameManager sm = smObject.GetComponent<GameManager>();
        sm.currentScore++;

        sm.currentScoreUI.text = "�������� : " + sm.currentScore;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // ���װ�
        Destroy(other.gameObject);
        // ������
        Destroy(gameObject);
    }
}