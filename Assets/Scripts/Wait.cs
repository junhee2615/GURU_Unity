using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wait : MonoBehaviour
{
    public Sprite chage_img;
    Image thisImg;

    float currentTime;

    public GameObject clickbutton1;
    public GameObject clicktext;

    // Start is called before the first frame update
    void Start()
    {
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > 2f)
        {
            thisImg.sprite = chage_img;

            clickbutton1.SetActive(true);
            clicktext.SetActive(true);
        }
    }
}
