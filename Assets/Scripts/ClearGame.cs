using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGame : MonoBehaviour
{
    public GameObject Puzzle;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 3f)
        {
            Destroy(Puzzle);
        }
    }
}
