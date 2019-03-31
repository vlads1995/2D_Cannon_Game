using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isNewGame = false;
    public static int Score = 0;

    [SerializeField]
    private GameObject cannonChooseMenu;
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text gameOverScoreText;
    [SerializeField]
    private Text currentLives;   
     
    private void Update()
    {
        UpdateUIText();
        
        if (Player.isGameOver == true && isNewGame == false)
        {
            Time.timeScale = 0;
            gameOverScoreText.text = "Score: " + Score;
            gameOverMenu.SetActive(true);

        }
    }

    private void UpdateUIText()
    {
        scoreText.text = "Score: " + Score;
        currentLives.text = "Health: " + Player.currentHealth;
    }

    public void ExitToMainMenu()
    {         
        SceneManager.LoadScene("MainMenu");
        gameOverMenu.SetActive(false);
    }

    public void CannonChooseMenu()
    {
        cannonChooseMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        cannonChooseMenu.SetActive(false);
    }
}
