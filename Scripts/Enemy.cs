using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Enemy class which follows the player and shoots bullets every 3 seconds
*/
public class Enemy : MonoBehaviour
{
    // The bullet game object itself
    public GameObject bulletPrefab;

    // Fire cool down time
    public float fireCoolDown;

    // Boolean to hold if the enemy is firing
    public bool firing = false;

    // Update is called once per frame
    void Update()
    {
        fire();
    }

    void fire(){
        if(!firing){
            Instantiate (bulletPrefab, transform.position, transform.rotation);
            firing = true;
            StartCoroutine(coolDown(fireCoolDown));
        }
    }

    IEnumerator coolDown(float fireCoolDown){      
        yield return new WaitForSeconds(fireCoolDown);
        firing = false;
    }
}
