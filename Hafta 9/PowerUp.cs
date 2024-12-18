using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    
    [SerializeField] private int powerUpID;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))
        {
            player = collider.transform.GetComponent<Player>();
            if(player != null){
                switch (powerUpID)
                {
                    case 0:
                        player.ActiveTripleShot();
                        break;
                    case 1:
                        player.ActiveSpeedBoost();
                        break;
                    case 2:
                        player.ActiveShieldPowerUp();
                        break;                    
                }
            }
            Destroy(this.gameObject);
        }
    }
    private void OnBecameInvisible(){
        Destroy(gameObject);
    } 
}
