using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Transform player;
    public TextMeshProUGUI timerText;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer on the UI
        timerText.text = gameController.getTimeInt().ToString();
    }
}
