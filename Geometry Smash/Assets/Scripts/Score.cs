using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public Transform player;
    public int score;
    public TextMeshProUGUI scoreText, highsSoreText;
    public int highScore;
    private int offset;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("Score");
        highsSoreText.text = "HighScore: " + highScore.ToString();
    }

    void Update()
    {
        score = Mathf.RoundToInt(player.transform.position.x - transform.position.x) + offset;
        scoreText.text = "Score: " + score.ToString();
    }

    public void End()
    {
        offset = 0;
        if (score > highScore)
        {
            highScore = score;
            highsSoreText.text = "HighScore: " + highScore.ToString();
            PlayerPrefs.SetInt("Score", highScore);
            PlayerPrefs.Save();
        }
    }

    public void Increment()
    {
        offset += 10;
    }
}