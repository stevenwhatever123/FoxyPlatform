using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Component Reference
    // This script can hold up to 5 different types of platform
    private GameObject[] platforms = new GameObject[5];
    public GameObject platform0;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;

    // Point for generation
    public Transform generationPoint;
    // Distance between two platform
    public float distanceBetweenWidth;
    // The height of the platform
    public float distanceBetweenHeight = 0;
    // A temp to store platform width
    private float platformWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Adding existing platform to our array of platform
        platforms[0] = platform0;
        platforms[1] = platform1;
        platforms[2] = platform2;
        platforms[3] = platform3;
        platforms[4] = platform4;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x){
            int index = Random.Range(0, platforms.Length);
            // Keep looping if the index of the array is empty
            while(platforms[index] == null){
                index = Random.Range(0, platforms.Length);
            }
            platformWidth = platforms[index].GetComponent<BoxCollider2D>().size.x;
            // Create a new y-axis position for the platform
            float newPlatformHeight = Random.Range(-distanceBetweenHeight, distanceBetweenHeight - 0.3f);
            if(newPlatformHeight < 0){
                // Larger the height by 10%
                newPlatformHeight *= 1.1f;
            }
            // Position for the new spawn platform
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenWidth, transform.position.y + newPlatformHeight, transform.position.z);
            Instantiate(platforms[index], transform.position, transform.rotation);
        }
    }
}
