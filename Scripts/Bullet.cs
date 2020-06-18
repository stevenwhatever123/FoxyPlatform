using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Bullet Script from the enemy
*/
public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeDuration = 5f;
    public float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // Bullet movement
        transform.position -= transform.right * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime;

        if(lifeTimer <=- 0f){
            Destroy(this.gameObject);
        }
    }

    // Check if the bullet have collision with the player
    // If true, the game ends
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.name == "Player"){
            FindObjectOfType<GameController>().GameOver();
        }
    }
}
