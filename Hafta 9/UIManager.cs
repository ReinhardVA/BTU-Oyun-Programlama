using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private int _score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    [SerializeField] private Image[] _lifeSprites;
    private float _flickerSpeed = 0.5f;
    private Coroutine flickerCoroutine;
    private bool gameOver = false;
    void Start(){
        gameOverText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + _score;
        if(gameOver && Input.GetKeyDown(KeyCode.R)){
            RestartGame();
        }
    }
    public void IncreaseScore(){
        _score += 10;
    }

   public void UpdateLivesUI(int currentLives)
    {
        for (int i = 0; i < _lifeSprites.Length; i++)
        {
            _lifeSprites[i].enabled = i == currentLives;
        }
        if(currentLives == 0){
            ShowGameOverText();
            gameOver = true;
        }
    }

    private void ShowGameOverText()
    {
        if(flickerCoroutine != null){
            StopCoroutine(flickerCoroutine);
        }
        gameOverText.gameObject.SetActive(true);
        flickerCoroutine = StartCoroutine(FlickerText());
    }

    private IEnumerator FlickerText(){
        while(true){
            gameOverText.gameObject.SetActive(!gameOverText.gameObject.activeSelf);
            yield return new WaitForSeconds(_flickerSpeed);
        }
    }

    private void StopFlicker(){
        if(flickerCoroutine != null){
            StopCoroutine(flickerCoroutine);
            gameOverText.gameObject.SetActive(false);
        }
    }

    private void RestartGame(){
        StopFlicker();

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }
}
