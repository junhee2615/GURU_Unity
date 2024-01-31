using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
    //    {
    //        other.gameObject.SetActive(false);

    //        if (other.gameObject.name.Contains("Bullet"))
    //        {
    //            PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
    //            PlayerFire player = playerFire;
    //            player.bulletObjectPool.Add(other.gameObject);
    //        }
    //        else if (other.gameObject.name.Contains("Enemy"))
    //        {
    //            GameObject emObject =
    //                GameObject.Find("EnemyManager");
    //            EnemyManager manager = emObject.GetComponent<EnemyManager>();
    //            manager.enemyObjectPool.Add(other.gameObject);
    //        }
    //    }

    //}
}
