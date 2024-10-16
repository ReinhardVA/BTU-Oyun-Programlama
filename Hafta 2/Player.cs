using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class example : MonoBehaviour
{
    private float speed = 10.0f;
    private float minX = -8.38f;
    private float minY = -2.4f;
    private float maxX = 8.38f;
    private float maxY = 0.00f;

    public GameObject laserPrefab;
    public float fireRate = 0.5f;
    public float nextFireTime = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        LimitMovement();
        Shoot();
    }

    private void LimitMovement()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), 0
                );
    }

    void PlayerMovement(){
        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationY = Input.GetAxis("Vertical") * speed;
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;
        transform.Translate(translationX, translationY, 0);
    }
    
    void Shoot(){
        if(Input.GetKeyUp(KeyCode.Space) && Time.time >= nextFireTime){
            Instantiate(laserPrefab, transform.position, UnityEngine.Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        } 
    }
}
