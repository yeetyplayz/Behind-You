using UnityEngine;
using UnityEngine.AI;

public class mainGhostLogic : MonoBehaviour
{
    public Vector3 playerPos;
    public GameObject player;
    public playerLogic playerLogic;
    public NavMeshAgent agent;

    private void Start()
    {
        playerLogic = player.GetComponent<playerLogic>();
    }
}
