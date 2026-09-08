using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class playerLogic : MonoBehaviour
{
    public int points;
    public int highScore;
    public mainGhostLogic[] ghosts;
    public int section = 0;

    private void Update()
    {
        if (points >= highScore) { highScore = points; }
        ghosts[0].playerPos = transform.position;
        ghosts[1].playerPos = transform.position;
    }
    public void GainScore(string score)
    {
        if (score == "small") { points += 10; }
        if (score == "big") { points += 50;  }
    }
}
