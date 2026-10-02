using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class playerLogic : MonoBehaviour
{
    private TMP_Text score;
    public gameManager g;
    public int points;
    public int highScore;
    public int section = 0;

    private void Update()
    {
        score.text = "Score: " + points;
        if (points >= highScore) { highScore = points; }
    }
    public void GainScore(string score)
    {
        if (score == "small") { points += 10; }
        if (score == "big") { points += 50;  }
    }
    public void Die()
    {
        //g.
    }
}
