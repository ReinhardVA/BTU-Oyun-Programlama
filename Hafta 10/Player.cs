using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float minX = -8.38f;
    private float minY = -2.4f;
    private float maxX = 8.38f;
    private float maxY = 0.00f;
    private int _playerLives = 3;
    private float _speed = 10.0f;
    private float _speedMultiplier = 2;
    private bool _isTripleShotActive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldPowerUpActive = false;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    [SerializeField] private GameObject _shieldVisualizer;
    [SerializeField] private GameObject _rightEngineHurt;
    [SerializeField] private GameObject _leftEngineHurt;
    public AudioSource laserSound;
    public GameObject laserPrefab;
    public GameObject tripleShotPrefab;
    public float fireRate = 0.5f;
    public float nextFireTime = 0f;
    
    
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if(_spawnManager == null){
            Debug.Log("null");
        }
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _rightEngineHurt.SetActive(false);
        _leftEngineHurt.SetActive(false);
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
        transform.position = new Vector2(
                            Mathf.Clamp(transform.position.x, minX, maxX), 
                            Mathf.Clamp(transform.position.y, minY, maxY)
                            );
    }

    void PlayerMovement(){
        float translationX = Input.GetAxis("Horizontal") * _speed;
        float translationY = Input.GetAxis("Vertical") * _speed;
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;
        transform.Translate(translationX, translationY, 0);
    }
    
    void Shoot(){
        if(Input.GetKeyUp(KeyCode.Space) && Time.time >= nextFireTime){
            if(_isTripleShotActive == true){
                Instantiate(tripleShotPrefab, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
                laserSound.Play();

            }
            else{
                Instantiate(laserPrefab, transform.position, Quaternion.identity);
                laserSound.Play();
            }
            nextFireTime = Time.time + fireRate;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            if(_isShieldPowerUpActive == true){
                _isShieldPowerUpActive = false;
                _shieldVisualizer.SetActive(false);
                return;
            }
            else if(_isShieldPowerUpActive == false){
                DecreasePlayerLives();
            }
        }
        DestroyPlayer();
    }

    void DecreasePlayerLives(){
        _playerLives -= 1;
        if(_playerLives == 2){
            _rightEngineHurt.SetActive(true);
        }
        else if(_playerLives == 1){
            _leftEngineHurt.SetActive(true);
        }
        _uiManager.UpdateLivesUI(_playerLives);
    }
    void DestroyPlayer(){
        if(_playerLives < 1){
            _spawnManager.gameOver();
            Destroy(this.gameObject);
        }
    }
    public void ActiveShieldPowerUp(){
        _isShieldPowerUpActive = true;
        _shieldVisualizer.SetActive(true);
    }
    public void ActiveTripleShot(){
        _isTripleShotActive = true;
        //CoRoutine ile 5 saniye boyunca buff'ı player üzerinde tutacak ve ardından buff gidecek
        StartCoroutine(TripleShotBonusDisableRoutine());
    }

    IEnumerator TripleShotBonusDisableRoutine(){
        yield return new WaitForSeconds(5.0f);

        _isTripleShotActive = false;
    }

    public void ActiveSpeedBoost(){
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
    }
}
