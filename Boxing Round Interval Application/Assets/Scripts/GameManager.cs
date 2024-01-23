using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private TextMeshProUGUI currentRoundText;
    [SerializeField] private TextMeshProUGUI maxRoundText;

    [Header("GameUI")]
    [SerializeField] private GameObject gameUIContainer;
    [SerializeField] private TextMeshProUGUI startCountDownText;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private TextMeshProUGUI gameRoundLengthTime;
    [SerializeField] private TextMeshProUGUI gameRestLengthTime;
    [SerializeField] private float countdownTime = 5f;
    [SerializeField] private TextMeshProUGUI gamePhaseText;
    [SerializeField] private bool beganRound;
    [SerializeField] private bool beganRest;

    [Header("Game Values")]
    [SerializeField] private int currentRound;
    [SerializeField] private bool pressedBeginPlayButton;
    [SerializeField]  private float initialRoundLength;
    [SerializeField] private float initialRestLength;
    [SerializeField] private float maxRounds;

    [Header("Audio")]
    public AudioSource countDownSound;
    public AudioSource fightSound;
    private void Start()
    {
        startUIContainer.SetActive(true);
        gameUIContainer.SetActive(false);
        rounds = 1;
        currentRound = 1;
        currentRoundText.text = currentRound.ToString();
        roundsNumberText.text = rounds.ToString();
    }
    private void Update()
    {
        if (pressedBeginPlayButton)
        {
            BeginCountDown();
        }
        if (countdownTime == 0)
        {
            pressedBeginPlayButton = false;
            startCountDownText.gameObject.SetActive(false);
            BeginRound();
            beganRound = true;
            Debug.Log("Began Round");
        }
     
        //round length to begin rest
       
        if (roundLength == 0 && beganRound)
        {
            beganRound = false;
           
            if (roundLength == 0 && !beganRound)
            {
                BeginRest();
                Debug.Log("Began Rest");
            }
            //rest length to begin round
            if (restTime == 0 && beganRest)
            {
                beganRest = false;
               
                if (restTime == 0 && !beganRest)
                {
                    currentRound += 1;
                    currentRoundText.text = "Current Round: "+ currentRound.ToString();
                    roundLength = initialRoundLength;
                    BeginRound();
                    Debug.Log("Began Round After rest");
                }
            }
            if (currentRound == maxRounds)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
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
        initialRoundLength = roundLength;
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
        initialRoundLength = roundLength;
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
        initialRestLength = restTime;
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
        initialRestLength = restTime;
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
        maxRounds = rounds;
        TotalTrainingTime();
    }
    //function that decreases 1 round to our rounds
    public void DecreaseRounds()
    {
        rounds -= 1;
        rounds = Mathf.Max(0, rounds);
        roundsNumberText.text = rounds.ToString();
        maxRounds = rounds;
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
        currentRoundText.text ="Current Round: " + currentRound.ToString();
        maxRoundText.text =" / "+ maxRounds.ToString();
        countDownSound.Play();
    }
    //begin countdown function
    private void BeginCountDown()
    {
        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Max(0f, countdownTime);

        float minutes = Mathf.FloorToInt(countdownTime/ 60);
        float seconds = Mathf.FloorToInt(countdownTime % 60);
        startCountDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        gamePhaseText.text = "Get Ready ";
    }
    private void BeginRound()
    {
      
            gameRoundLengthTime.gameObject.SetActive(true);
            gameRestLengthTime.gameObject.SetActive(false);
            roundLength -= Time.deltaTime;
            roundLength = Mathf.Max(0f, roundLength);

            float minutes = Mathf.FloorToInt(roundLength / 60);
            float seconds = Mathf.FloorToInt(roundLength % 60);
            gameRoundLengthTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            gamePhaseText.text = "FIGHT ";

        if (!beganRound)
        {
            fightSound.Play();
            beganRound = true;
        }
        
    }
    private void BeginRest()
    {
        
            gameRoundLengthTime.gameObject.SetActive(false);
            gameRestLengthTime.gameObject.SetActive(true);

            restTime -= Time.deltaTime;
            restTime = Mathf.Max(0f, restTime);

            float minutes = Mathf.FloorToInt(restTime / 60);
            float seconds = Mathf.FloorToInt(restTime % 60);
            gameRestLengthTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            gamePhaseText.text = "REST ";
        beganRest = true;
    }
    #endregion startGame
}
