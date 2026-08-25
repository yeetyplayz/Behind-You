using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class playerLogic : MonoBehaviour
{
    public int points;
    public int highScore;
    private void Update()
    {
        if (points >= highScore) { highScore = points; }
    }
    public void GainScore(string score)
    {
        if (score == "small") { points += 10; }
        if (score == "big") { points += 50;  }
    }
}
