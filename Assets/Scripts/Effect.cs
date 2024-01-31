using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    public GameObject clickbutton2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartClick());
    }

    IEnumerator StartClick()
    {
        for (int i = 0; i <= 10; i++)
        {
            clickbutton2.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            clickbutton2.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}