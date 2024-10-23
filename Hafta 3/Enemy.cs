using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float fall_speed = 3.0f;
    private float spawnPointY = 3.36f;
    private float randomX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * fall_speed * Time.deltaTime);
    }

    private void OnBecameInvisible(){
        randomX =  UnityEngine.Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, spawnPointY, 0);
    }
    private void OnTriggerEnter(Collider collision){
        Destroy(this.gameObject);
    }
}
