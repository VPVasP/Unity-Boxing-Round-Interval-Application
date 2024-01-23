using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Values 
    [Header("Values")]
    [SerializeField] private float totalTrainingLength;
    [SerializeField] private float roundLength;
    [SerializeField] private float restTime;
    [SerializeField] private int rounds;
    //User Interface Texts
    [Header("StartUI")]
    [SerializeField] private GameObject startUIContainer;
    [SerializeField] private TextMeshProUGUI trainingLengthTimerText;
    [SerializeField] private TextMeshProUGUI roundLengthTimerText;
    [SerializeField] private TextMeshProUGUI restTimeTimerText;
    [SerializeField] private TextMeshProUGUI roundsNumberText;


    [Header("GameUI")]
    [SerializeField] private GameObject gameUIContainer;
    [SerializeField] private TextMeshProUGUI startCountDownText;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private TextMeshProUGUI gameRoundLengthTime;
    [SerializeField] private TextMeshProUGUI gameRestLengthTime;
    private bool pressedBeginPlayButton;
    [SerializeField] private float countdownTime = 5f;
    private void Start()
    {
        startUIContainer.SetActive(true);
        gameUIContainer.SetActive(false);
        rounds = 1;
        roundsNumberText.text = rounds.ToString();
    }
    private void Update()
    {
        if (pressedBeginPlayButton)
        {
            BeginCountDown();
        }
        if (countdownTime <= 0)
        {
            pressedBeginPlayButton = false;
            startCountDownText.gameObject.SetActive(false);
        }
    }
    //function that handles total training time
    private void TotalTrainingTime()
    {
        float totalTrainingTime = rounds * Mathf.Max(0f, roundLength + restTime);
        float minutes = Mathf.FloorToInt(totalTrainingTime / 60);
        float seconds = Mathf.FloorToInt(totalTrainingTime % 60);
        trainingLengthTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    #region RoundLength
    //function that adds 5 seconds to our rounds
    public void IncreaseRoundLength()
    {
        roundLength += 5f;
        roundLength = Mathf.Max(0f, roundLength);
        float minutes = Mathf.FloorToInt(roundLength / 60);
        float seconds = Mathf.FloorToInt(roundLength % 60);
        roundLengthTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        TotalTrainingTime();
    }
    //function that decreases 5 seconds to our rounds
    public void DecreaseRoundLength()
    {
        roundLength -= 5f;
        roundLength = Mathf.Max(0f, roundLength);
        float minutes = Mathf.FloorToInt(roundLength / 60);
        float seconds = Mathf.FloorToInt(roundLength % 60);
        roundLengthTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        TotalTrainingTime();
    }
    #endregion RoundLength
    #region RestTime
    //function that adds 5 seconds to our rest time
    public void IncreaseRestLength()
    {
        restTime += 5f;
        restTime = Mathf.Max(0f, restTime);
        float minutes = Mathf.FloorToInt(restTime / 60);
        float seconds = Mathf.FloorToInt(restTime % 60);
        restTimeTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        TotalTrainingTime();
    }
    //function that decreases 5 seconds to our rest time
    public void DecreaseRestLength()
    {
        restTime -= 5f;
        restTime = Mathf.Max(0f, restTime);
        float minutes = Mathf.FloorToInt(restTime / 60);
        float seconds = Mathf.FloorToInt(restTime % 60);
        restTimeTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        TotalTrainingTime();
    }
    #endregion RestTime
    #region rounds
    //function that adds 1 round to our rounds
    public void IncreaseRounds()
    {
        rounds += 1;
        rounds = Mathf.Max(0, rounds);
        roundsNumberText.text = rounds.ToString();
        TotalTrainingTime();
    }
    //function that decreases 1 round to our rounds
    public void DecreaseRounds()
    {
        rounds -= 1;
        rounds = Mathf.Max(0, rounds);
        roundsNumberText.text = rounds.ToString();
        TotalTrainingTime();
    }
    #endregion rounds
    #region startGame
    //begins game and hides/enables the correct UI
    public void StartGame()
    {
        startUIContainer.SetActive(false);
        gameUIContainer.SetActive(true);
        pressedBeginPlayButton = true;
    }
    //begin countdown function
    private void BeginCountDown()
    {
        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Max(0f, countdownTime);

        float minutes = Mathf.FloorToInt(countdownTime/ 60);
        float seconds = Mathf.FloorToInt(countdownTime % 60);
        startCountDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    #endregion startGame
}
