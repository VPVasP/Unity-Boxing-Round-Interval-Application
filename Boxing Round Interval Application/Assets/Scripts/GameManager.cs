using System;
using TMPro;
using Unity.VisualScripting;
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
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI trainingLengthTimerText;
    [SerializeField] private TextMeshProUGUI roundLengthTimerText;
    [SerializeField] private TextMeshProUGUI restTimeTimerText;
    [SerializeField] private TextMeshProUGUI roundsNumberText;

    //function that handles total training time
    private void TotalTrainingTime()
    {
        float totalTrainingTime = Mathf.Max(0f, roundLength + restTime);
        TimeSpan spanTrainingLength = TimeSpan.FromSeconds(totalTrainingTime);
        string formattedTrainingLength = string.Format("{0:D2}:{1:D2}", spanTrainingLength.Minutes, spanTrainingLength.Seconds);
        trainingLengthTimerText.text = formattedTrainingLength;
    }
    #region RoundLength
    //function that adds 5 seconds to our rounds
    public void IncreaseRoundLength()
    {
        roundLength += 5f;
        roundLength = Mathf.Max(0f, roundLength);
        TimeSpan spanRoundTime = TimeSpan.FromSeconds(roundLength);
        string formattedRoundTime = string.Format("{0:D2}:{1:D2}", spanRoundTime.Minutes, spanRoundTime.Seconds);
        roundLengthTimerText.text = formattedRoundTime;
        TotalTrainingTime();
    }
    //function that decreases 5 seconds to our rounds
    public void DecreaseRoundLength()
    {
        roundLength -= 5f;
        roundLength = Mathf.Max(0f, roundLength);
        TimeSpan roundTimeSpan = TimeSpan.FromSeconds(roundLength);
        string formattedRoundTime = string.Format("{0:D2}:{1:D2}", roundTimeSpan.Minutes, roundTimeSpan.Seconds);
        roundLengthTimerText.text = formattedRoundTime;
        TotalTrainingTime();
    }
    #endregion RoundLength
    #region RestTime
    //function that adds 5 seconds to our rest time
    public void IncreaseRestLength()
    {
        restTime += 5f;
        restTime = Mathf.Max(0f, restTime);
        TimeSpan spanRestTime = TimeSpan.FromSeconds(restTime);
        string formattedRestTime = string.Format("{0:D2}:{1:D2}", spanRestTime.Minutes, spanRestTime.Seconds);
        restTimeTimerText.text = formattedRestTime;
        TotalTrainingTime();
    }
    //function that decreases 5 seconds to our rest time
    public void DecreaseRestLength()
    {
        restTime -= 5f;
        restTime = Mathf.Max(0f, restTime);
        TimeSpan spanRestTime = TimeSpan.FromSeconds(restTime);
        string formattedRestTime = string.Format("{0:D2}:{1:D2}", spanRestTime.Minutes, spanRestTime.Seconds);
        restTimeTimerText.text = formattedRestTime;
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
    }
    //function that decreases 1 round to our rounds
    public void DecreaseRounds()
    {
        rounds -= 1;
        rounds = Mathf.Max(0, rounds);
        roundsNumberText.text = rounds.ToString();
    }
    #endregion rounds
    #region startGame
    public void StartGame()
    {

    }
    #endregion startGame
}
