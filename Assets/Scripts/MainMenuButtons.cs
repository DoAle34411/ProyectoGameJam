using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeSceneCurrent() 
    {
        int current = HighestCurrentLevel.GetCurrentLevel();
        if (current == 1) {
            SceneManager.LoadScene("Level1");
        }
        if (current == 2)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}