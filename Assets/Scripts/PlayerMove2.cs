using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove2 : MonoBehaviour
{
    public float speed = 5;
    public int currentScore;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print("h : " + h + ", v :" + v);

        Vector3 dir = Vector3.right * h + Vector3.up * v;
        //Vector3 dir = new Vector3(h, v, 0);

        //transform.Translate(Vector3.right * speed * Time.deltaTime);

        //transform.Translate(dir * speed * Time.deltaTime);
        transform.position += dir * speed * Time.deltaTime;

        if(GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
    }
}
