using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public Button restartButton;
	public Button pauseButton;
	public GameObject titleScreen;
    public GameObject pauseMenu;
	
	public bool isGameActive;
	private int score = 0;
	
	private spawnManager spawnManagerCs;
	
	// Start is called before the first frame update
    void Start()
    {
        titleScreen.SetActive(true);
		gameOverText.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        restartButton.gameObject.SetActive(false);
		isGameActive = false;
		score = 0;
		IncreaseScore(0);
		
		spawnManagerCs = GameObject.Find("Spawn Manager").GetComponent<spawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void StartGame()
    {
        titleScreen.SetActive(false); // Hide title screen when game starts
        isGameActive = true;
		spawnManagerCs.StartSpawning();
    }
	
	public void IncreaseScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
		
		// Increase speed when score reaches 50
        if (score >= 50)
        {
            FindObjectOfType<playerController>().IncreaseSpeed();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
		isGameActive = false;
		spawnManagerCs.StopSpawning();
		restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	
	public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
