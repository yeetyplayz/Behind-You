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
    private void FixedUpdate()
    {
        playerPos = player.transform.position;
        agent.SetDestination(playerPos);
        destination = agent.destination;
    }
    public void IncreaseDiff()
    {
        agent.speed = agent.speed * 1.1f;
    }
}