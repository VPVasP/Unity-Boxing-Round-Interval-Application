using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseResumeSystem : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource countDownSound;
    [SerializeField] private AudioSource fightSound;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] Sprite pauseIcon;
    [SerializeField] Sprite resumeIcon;
    [SerializeField] private Button pauseResumeButton;
    [SerializeField] private Image buttonImage;
    private void Start()
    {
        pauseText.text = "Application is Paused ";
        pauseText.gameObject.SetActive(false);
        buttonImage = pauseResumeButton.GetComponent<Image>();
        buttonImage.sprite = pauseIcon;
    }
    //function that pauses the game
    public void PauseGame()
    {
        buttonSound.Play();

        if (gameIsPaused)
        {
            //resume the game
            countDownSound.UnPause();
            fightSound.UnPause();
            pauseText.gameObject.SetActive(false);
            Time.timeScale = 1f;
            buttonImage.sprite = pauseIcon;
        }
        else
        {
            //pause the game
            countDownSound.Pause();
            fightSound.Pause();
            pauseText.gameObject.SetActive(true);
            Time.timeScale = 0f;
            buttonImage.sprite = resumeIcon;
        }
        //toggle between pausing and unPausing
        gameIsPaused = !gameIsPaused;
    }

}
