using UnityEngine;

public class gameManager : MonoBehaviour
{
    public MazeGenerator maze;
    public playerLogic pl;
    public lostGhostLogic lost;
    public cutOffGhost cut;

    private void FixedUpdate()
    {
        if (pl.points == 10320)
        { 
            IncreaseDiff();
        }
    }
    public void IncreaseDiff()
    {
        maze.RespawnBalls();
        lost.IncreaseDiff();
        cut.IncreaseDiff();
    }
}
