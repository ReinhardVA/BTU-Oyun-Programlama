using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fall_speed = 3.0f;
    private float _spawnPointY = 3.36f;
    private float _randomX;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
      _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
        _uiManager.IncreaseScore();
        Destroy(this.gameObject);
    }
}
