using TMPro;
using UnityEngine;

public class PauseResumeSystem : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource countDownSound;
    [SerializeField] private AudioSource fightSound;
    [SerializeField] private TextMeshProUGUI pauseText;
    private void Start()
    {
        pauseText.text = "Application is Paused ";
        pauseText.gameObject.SetActive(false);
    }
    //function that pauses the game
    public void PauseGame()
    {
        gameIsPaused = true;
        buttonSound.Play();
        countDownSound.Pause();
        fightSound.Pause();
        pauseText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    //function that resumes the game
    public void ResumeGame()
    {
        gameIsPaused = false;
        buttonSound.Play();
        countDownSound.UnPause();
        fightSound.UnPause();
        pauseText.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
