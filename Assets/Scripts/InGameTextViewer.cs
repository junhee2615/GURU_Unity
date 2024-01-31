using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameTextViewer : MonoBehaviour
{
    public GameController gameController;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textPlayTime;
    public Slider sliderPlayTime;
    public TextMeshProUGUI textCombo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score " + gameController.Score;

        textPlayTime.text = gameController.CurrentTime.ToString("F1");
        sliderPlayTime.value = gameController.CurrentTime / gameController.MaxTime;

        textCombo.text = "Combo " + gameController.Combo;
    }
}
