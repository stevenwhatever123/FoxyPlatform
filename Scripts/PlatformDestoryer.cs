using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* This script helps to destory the platform after a short while for better game performance
*/
public class PlatformDestoryer : MonoBehaviour
{
    // Platform life duration
    public float lifeDuraton = 7f;
    // Counter
    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuraton;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <=- 0f){
            Destroy(this.gameObject);
        }
    }
}
