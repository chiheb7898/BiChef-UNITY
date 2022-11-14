using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    static GameSystem _system;
    public GameObject GameScoreCanvas;

    public GameObject EndGameCanvas;
    public Text EndScoreText;
    public static GameSystem System
    {
        get
        {
            if(_system == null)
            {
                _system = GameObject.FindObjectOfType<GameSystem>();
                if(_system == null)
                {
                    GameObject container = new GameObject("GameSystem");
                    _system = container.AddComponent<GameSystem>();
                }
            }

            return _system;
        }
    }

    public void OnRestart()
    {
        EndGameCanvas.SetActive(false);
        GameScoreCanvas.SetActive(true);

        SceneManager.LoadScene(0);
    }
    public void OnKnifeKill()
    {
        EndScoreText.text = LEVEL.Score.ToString();
        EndGameCanvas.SetActive(true);
        GameScoreCanvas.SetActive(false);
    }
    public Level LEVEL;
}

[System.Serializable]
public class Level
{
    public float CurrentSpeed = 0.2f;
    public int Score = 0;
    public Text ScoreText;

    public void InceaseScore()
    {
        Score ++;
        ScoreText.text = Score.ToString();
        float speed = CurrentSpeed;

        if(Score >= 200)
        {
            SceneManager.LoadScene("Kitchen");
            speed = 900;
        }
        if (Score >= 400)
        {
            speed = 1200;
        }

        UpdateLevelSpeed(speed);
    }

    private void UpdateLevelSpeed(float speed)
    {
        ObjectSpawner spawner = GameObject.FindObjectOfType<ObjectSpawner>();
        Animator knifeAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        if (CurrentSpeed != 1200)
        {
            if (speed == 900)
            {
                spawner.IntervalBetweenSpawn = 0.4f;
                knifeAnimator.SetFloat("speed", 2.0f);
            }

            if (speed == 1200)
            {
                spawner.IntervalBetweenSpawn = 0.25f;
                knifeAnimator.SetFloat("speed", 2.5f);
            }
            CurrentSpeed = speed;
        }
    }

    public void OnVegetableCut()
    {
        InceaseScore();
    }
}
