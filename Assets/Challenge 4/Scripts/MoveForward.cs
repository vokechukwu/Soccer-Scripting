using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public ParticleSystem _speedBoostFX;
    private float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!_speedBoostFX.isPlaying)
                _speedBoostFX.Play();
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
