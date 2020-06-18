using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameController gameController;
    public string text = "Score: ";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score on the UI
        string temp = text + gameController.getScore().ToString();
        scoreText.text = temp;
    }
}
