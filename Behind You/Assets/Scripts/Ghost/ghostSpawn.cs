using UnityEngine;

public class ghostSpawn : MonoBehaviour
{
    private Vector3 spawnLocation;
    private float spawnTime = 15f;
    public GameObject ghostVar1;// N   ?
    public GameObject ghostVar2;// A   ?
    public GameObject ghostVar3;// M   ?
    public GameObject ghostVar4;// E   ?

    private void Start()
    {
        spawnLocation = transform.position;
    }
    
    public void RespawnGhost(int ghost)
    {
        while (spawnTime > 0) { spawnTime--; }
        if (ghost == 1) { Instantiate(ghostVar1, spawnLocation, Quaternion.identity, transform); }
        if (ghost == 2) { Instantiate(ghostVar2, spawnLocation, Quaternion.identity, transform); }
        if (ghost == 3) { Instantiate(ghostVar3, spawnLocation, Quaternion.identity, transform); }
        if (ghost == 4) { Instantiate(ghostVar4, spawnLocation, Quaternion.identity, transform); }
        if (ghost >= 5 || ghost <= 0) { Debug.Log("Invalid Ghost Variant ERROR"); } 
    }
}
