using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //created the variable below to get a reference to our player's rigidbody
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerUpStrength = 15.0f;

    //created a speed variable and initialized it at 5.0f so that the player can have momentum
    public float speed = 5.0f;
    public bool hasPowerup;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        //use this start method to get the reference of that component that is already on the body of the player
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()

    {   //get the player's input to enable him move up or down using the arrow keys
        float forwardInput = Input.GetAxis("Vertical");
        //Add a force to our player's rigid body
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //this is our mathematical equation to caluculate the player's distance from the enemy
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;


            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            //this is where we interact with an ememy when they collide
            Debug.Log("Collied with:" + collision.gameObject.name + "with powerup set to" + hasPowerup);
        }
    }


}
