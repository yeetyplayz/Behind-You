using TMPro;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public playerLogic playerLogic;
    private int score;
    public void FixedUpdate()
    {
        score = playerLogic.points;
        scoreText.text = "Score: " + score;
    }
}
