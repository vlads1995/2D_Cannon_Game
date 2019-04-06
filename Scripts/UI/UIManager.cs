using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{    
    public static bool IsNewGame = false;
    public static int Score = 0;

    [SerializeField]
    private GameObject _cannonChooseMenu;
    [SerializeField]
    private GameObject _gameOverMenu;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverScoreText;
    [SerializeField]
    private Text _currentLives;   
     
    private void Update()
    {
        UpdateUIText();
        
        if (Player.IsGameOver == true && IsNewGame == false)
        {
            Time.timeScale = 0;
            _gameOverScoreText.text = "Score: " + Score;
            _gameOverMenu.SetActive(true);
        }
    }
    

    private void UpdateUIText()
    {
        _scoreText.text = "Score: " + Score;
        _currentLives.text = "Health: " + Player.CurrentHealth;
    }

    public void ExitToMainMenu()
    {         
        SceneManager.LoadScene("MainMenu");
        _gameOverMenu.SetActive(false);
    }

    public void CannonChooseMenu()
    {
        _cannonChooseMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        _cannonChooseMenu.SetActive(false);
    }
}
