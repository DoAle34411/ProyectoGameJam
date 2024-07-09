using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartPauseController : MonoBehaviour
{
    public TextMeshProUGUI levelStartText;
    public Image levelStartImage;
    public float pauseDuration = 2.0f; // Duration to display the text and pause the game

    void Start()
    {
        // Start the coroutine to display the text and pause the game
        StartCoroutine(DisplayTextAndPause());
    }

    IEnumerator DisplayTextAndPause()
    {
        // Enable the text
        levelStartText.gameObject.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;

        // Wait for the specified duration in real-time
        yield return new WaitForSecondsRealtime(pauseDuration);

        // Disable the text
        levelStartText.gameObject.SetActive(false);
        levelStartImage.gameObject.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;
    }
}
