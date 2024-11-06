using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float fall_speed = 3.0f;
    private float _spawnPointY = 3.36f;
    private float _randomX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(fall_speed * Time.deltaTime * Vector2.down);
    }

    private void OnBecameInvisible(){
        _randomX =  UnityEngine.Random.Range(-8f, 8f);
        transform.position = new Vector2(_randomX, _spawnPointY);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        Destroy(this.gameObject);
    }
}
