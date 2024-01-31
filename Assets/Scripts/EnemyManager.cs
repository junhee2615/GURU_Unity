using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 현재시간
    float currentTime;

    // 일정시간
    public float createTime = 1;

    // 적 공장
    public GameObject enemyFactory;

    float minTime = 1;
    float maxTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;

        // 2. 만약 현재시간이 일정시간이 되면
        if(currentTime > createTime)
        {
            // 3. 적 공장에서 적을 생성해서 
            GameObject enemy = Instantiate(enemyFactory);
            // 내 위치에 갖다 놓고 싶다
            enemy.transform.position = transform.position;

            // 적을 생성한 후 적 생성시간을 다시 설정하고 싶다
            createTime = UnityEngine.Random.Range(minTime, maxTime);

            // 현재시간을 0으로 초기화
            currentTime = 0;

            
        }
    }
}
