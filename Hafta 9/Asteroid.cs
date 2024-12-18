using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 300.0f;
    private SpawnManager _spawnManager;
    [SerializeField] private Animator _asteroidAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation *= Quaternion.Euler(0, 0, Time.deltaTime * _rotationSpeed * 10.0f);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Laser")){
            //Patlama animasyonu ve start spawn
            _asteroidAnimator.SetBool("IsAsteroidExplode", true);
            Destroy(collider.gameObject);
            StartCoroutine(AsteroidDestruction());
            Destroy(this.gameObject, 2.5f);
        }
    }
    IEnumerator AsteroidDestruction(){
        yield return new WaitForSeconds(2.0f);
        _spawnManager.changeSpawnCondition();
    }
}
