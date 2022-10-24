using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Mole> moles;
    
    [Header("UI objects")]
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject timeOutText;
    [SerializeField] private GameObject lostText;
    [SerializeField] private GameObject backToMenuButton;
    [SerializeField] private GameObject playAgainButton;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;
    [SerializeField] private TMPro.TextMeshProUGUI triesText;
    [SerializeField] private GameObject hammer;
    [SerializeField] private HammerController hammerController;
    [SerializeField] private GameObject allMoles;

    [Header("Game settings")]
    private float startingTime = 45f;
    private float timeLeft;
    private int score = 0;
    private int highScore = 0;
    private bool playing = false;
    private int errors = 3;

    private void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (playing)
        {
            timeLeft -= Time.deltaTime;
            if (errors == 0)
            {
                playing = false;
                GameUI.SetActive(false);
                lostText.SetActive(true);
                allMoles.SetActive(false);
                backToMenuButton.SetActive(true);
                playAgainButton.SetActive(true);
                hammer.SetActive(false);
                GameOver();
            }
            if (timeLeft <= 0)
            {
                playing = false;
                timeLeft = 0;
                allMoles.SetActive(false);
                backToMenuButton.SetActive(true);
                playAgainButton.SetActive(true);
                timeOutText.SetActive(true);
                hammer.SetActive(false);
                if (score > highScore)
                {
                    highScore = score;
                    highScoreText.text = highScore.ToString();
                }
                GameOver();
            }
            timeText.text = $"{(int)timeLeft / 60}:{(int)timeLeft % 60:D2}";
        }
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void addError()
    {
        errors--;
    }

    public void updateErrors()
    {
        triesText.text = errors.ToString();
    }

    public void GameOver()
    {
        playing = false;
        for (int i = 0; i < moles.Count; i++)
        {
            moles[i].Stop();
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public void Missed(bool isMole)
    {
        if (isMole)
        {
            timeLeft -= 1;
        }
    }

    public void StartGame()
    {
        GameOver();
        GameUI.SetActive(true);
        timeOutText.SetActive(false);
        lostText.SetActive(false);
        backToMenuButton.SetActive(false);
        playAgainButton.SetActive(false);
        hammerController.resetHammer();
        hammer.SetActive(true);
        allMoles.SetActive(true);
        timeLeft = startingTime;
        errors = 3;
        score = 0;
        scoreText.text = "0";
        triesText.text = "3";
        for (int i = 0; i < moles.Count; i++)
        {
            moles[i].Activate();
        }
        playing = true;
    }

    public void hammerHit(int moleIndex)
    {
        moles[moleIndex].Hit();
    }
}
