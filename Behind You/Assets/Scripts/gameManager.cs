using UnityEngine;

public class gameManager : MonoBehaviour
{
    public uiManager uiManager;
    public MazeGenerator maze;
    private playerLogic pl;
    private lostGhostLogic lost;
    private cutOffGhost cut;

    private void Start()
    {
        maze.ClearMaze();
    }
    private void FixedUpdate()
    {
        if (pl.points == 10320 && pl != null)
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
    public void StartGame()
    {
        uiManager.EnableUi(5);
        maze.GenerateMaze();
        pl = maze.GetComponentInChildren<playerLogic>();
        lost = maze.GetComponentInChildren<lostGhostLogic>();
        cut = maze.GetComponentInChildren<cutOffGhost>();
    }
    public void ExitGame() { Application.Quit(); }
    public void GameOver()
    {
        maze.ClearMaze();

    }

}
