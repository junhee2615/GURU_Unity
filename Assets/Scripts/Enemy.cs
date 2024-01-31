using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // 필요속성 : 이동속도
    public float speed = 5;
    GameObject player;
    Vector3 dir;

    float time;

    public GameObject explosionFactory;

    //Start is called before the first frame update
    void Start()
    {
        // 0부터 9까지 값중에 하나를 랜덤으로 가져와서
        int randValue = UnityEngine.Random.Range(0, 10);

        // 만약 3보다 작으면 플레이어 방향
        if (randValue < 4)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
        }

        //그렇지 않으면 아래방향으로 정하고싶다
        else
        {
            //dir = Vector3.down;
            transform.position += speed * Time.deltaTime * dir;
        }
            dir.Normalize();
    }

    //void Start()
    //{
    //    //방향(d)
    //    GameObject target = GameObject.Find("Player");
    //    dir = target.transform.position - transform.position;
    //    dir.Normalize();
    //    //속도(s)
    //    speed = 3.0f;
    //    //시간(t)
    //    time = Time.deltaTime;
    //}



    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구한다
        // Vector3 dir = Vector3.down;

        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    // 충돌시작
    private void OnCollisionEnter(Collision other)
    {
        GameObject smObject = GameObject.Find("GameManager");
        GameManager sm = smObject.GetComponent<GameManager>();
        sm.currentScore++;

        sm.currentScoreUI.text = "현재점수 : " + sm.currentScore;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // 너죽고
        Destroy(other.gameObject);
        // 나죽자
        Destroy(gameObject);
    }
}