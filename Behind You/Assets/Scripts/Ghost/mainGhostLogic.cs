using UnityEngine;
using UnityEngine.AI;

public class mainGhostLogic : MonoBehaviour
{
    public ghostSpawn ghostSpawn;
    public Vector3 playerPos;
    public GameObject player;
    public playerLogic playerLogic;
    public int ghostVar;
    public NavMeshAgent agent;

    private void Start()
    {
        playerLogic = player.GetComponent<playerLogic>();
        ghostSpawn = GetComponentInParent<ghostSpawn>();
    }
    private void FixedUpdate()
    {
        playerPos = player.transform.position;
    }

    public void Die()
    {
        ghostSpawn.RespawnGhost(ghostVar);
    }
}
