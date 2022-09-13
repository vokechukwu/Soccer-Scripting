using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //this is a special purpose variable created to define lookDirection and cleanup our code
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //this is where we created the equation that allows the enemy to pursue the player based
        //on the player's distance away from the enemy times the enemy's speed normalized.
        enemyRb.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
