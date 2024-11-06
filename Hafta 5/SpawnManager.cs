using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemyContainer;
    
    private bool _isSpawning = false;
    IEnumerator SpawnRoutine(){
        while(_isSpawning == false){
            Vector2 _spanwPoint = new Vector2(Random.Range(-8f, 8f), 7);
            GameObject newEnemy = Instantiate(_enemy, _spanwPoint, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver(){
        _isSpawning = true;
    }
}
