using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class BarScript : MonoBehaviour
{
    public float barSpeed = 5f;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {
            transform.Translate(0, Input.GetAxisRaw("Vertical") * barSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(0, Input.GetAxisRaw("Vertical2") * barSpeed * Time.deltaTime, 0);
        }
    }
}
