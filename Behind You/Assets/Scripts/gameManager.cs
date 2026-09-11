using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject iMaze;
    public GameObject maze;
    public playerLogic pl;
    public lostGhostLogic lost;
    public cutOffGhost cut;

    public void StartGame()
    {
            
    }
    public void IncreaseDiff()
    {
        Vector3 s;
        s = transform.position;
        Instantiate(iMaze, s, Quaternion.identity);
    }
}
