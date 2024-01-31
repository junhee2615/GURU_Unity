using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameTextViewer4 : MonoBehaviour
{
    public GameManager4 gameManager;
    public TextMeshProUGUI textPlayTime;
    public Slider sliderPlayTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textPlayTime.text = gameManager.CurrentTime.ToString("F1");
        sliderPlayTime.value = gameManager.CurrentTime / gameManager.MaxTime;
    }
}
