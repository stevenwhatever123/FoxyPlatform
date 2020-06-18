using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* This script is only used to test the maximum height that the player can jump
*/
public class TestingForCharacterMaximumHeight : MonoBehaviour
{

    private float initialPositionY;
    private float maximum;

    // Start is called before the first frame update
    void Start()
    {
        initialPositionY = transform.position.y;
        maximum = initialPositionY;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > maximum){
            maximum = transform.position.y;
        }
        print("Maximum Jump Height: " + (maximum - initialPositionY));
    }
}
