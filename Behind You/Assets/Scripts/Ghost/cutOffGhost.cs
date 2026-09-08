using UnityEngine;
using UnityEngine.AI;

public class cutOffGhost : mainGhostLogic
{
    public Vector3 destination;
    private void Start()
    {
        ghostVar = 1;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerPos = player.transform.position;
        agent.SetDestination(playerPos);
        destination = agent.destination;
    }
}