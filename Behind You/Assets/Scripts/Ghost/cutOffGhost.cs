using UnityEngine;
using UnityEngine.AI;

public class cutOffGhost : mainGhostLogic
{
    private void Start()
    {
        ghostVar = 1;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(playerPos);
    }
}