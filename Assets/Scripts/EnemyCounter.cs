using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText;
    public string sceneName;
    public int currentLevel;
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;

        if (enemyCountText != null)
        {
            enemyCountText.text = enemyCount+ " x";
        }
        if (enemyCount == 0) {
            HighestCurrentLevel.SaveCurrentLevel(currentLevel);
            HighestCurrentLevel.SaveHighestLevel(currentLevel+2);
            SceneManager.LoadScene(sceneName);
        }
    }
}

