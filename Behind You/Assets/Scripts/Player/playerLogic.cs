using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class playerLogic : MonoBehaviour
{
    public int points;
    public int highScore;
    public int section = 0;

    private void Update()
    {
        if (points >= highScore) { highScore = points; }
    }
    public void GainScore(string score)
    {
        if (score == "small") { points += 10; }
        if (score == "big") { points += 50;  }
    }
    public void Die()
    {
        Debug.Log("death");
        Application.Quit();
    }
}
