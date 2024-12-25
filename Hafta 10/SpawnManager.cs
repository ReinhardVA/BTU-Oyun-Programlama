using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject[] _powerUpPrefabs;
    
    private bool _isSpawning = true;
    IEnumerator SpawnRoutine(){
        while(_isSpawning == false){
            Vector2 _spanwPoint = new Vector2(Random.Range(-8f, 8f), 7);
            GameObject newEnemy = Instantiate(_enemy, _spanwPoint, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }
    
    IEnumerator SpawnPowerUpRoutine(){
        while(_isSpawning == false){
            Vector3 position = new Vector2(Random.Range(-8f, 8f), 7);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerUpPrefabs[randomPowerUp], position, Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartSpawning(){
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }
    public void gameOver(){
        changeSpawnCondition();
    }
    public void changeSpawnCondition(){
        _isSpawning = !_isSpawning;
        StartSpawning();
    }
}
