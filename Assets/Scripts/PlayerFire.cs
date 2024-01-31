using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 목표: 사용자가 발사 버튼을 누르면 총알을 발사하고 싶다.
        // 순서 1. 사용자가 발사 버튼을 누르면
        // - 만약 사용자가 발사 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. 총알 공장에서 총알을 만든다.
            GameObject bullet = Instantiate(bulletFactory);

            // 3 . 총알을 발사한다. (총알을 총구위치로 가져다 놓기)
            bullet.transform.position = firePosition.transform.position;
        }

        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

    }
}
