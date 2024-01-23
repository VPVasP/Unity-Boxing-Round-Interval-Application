using UnityEngine;

public class PauseResumeSystem : MonoBehaviour
{
    public static bool gameIsPaused;
    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
}
