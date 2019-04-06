using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public void NewGame()
    {
        UIManager.IsNewGame = true;
        SceneManager.LoadScene("Game");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
