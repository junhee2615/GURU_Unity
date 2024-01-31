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
        // ��ǥ: ����ڰ� �߻� ��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
        // ���� 1. ����ڰ� �߻� ��ư�� ������
        // - ���� ����ڰ� �߻� ��ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. �Ѿ� ���忡�� �Ѿ��� �����.
            GameObject bullet = Instantiate(bulletFactory);

            // 3 . �Ѿ��� �߻��Ѵ�. (�Ѿ��� �ѱ���ġ�� ������ ����)
            bullet.transform.position = firePosition.transform.position;
        }

        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

    }
}
