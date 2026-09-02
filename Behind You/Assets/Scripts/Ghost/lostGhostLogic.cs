using UnityEngine;
using UnityEngine.AI;

public class lostGhostLogic : mainGhostLogic
{
    public int section;
    private void Start()
    {
        ghostVar = 1;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        while (section != playerLogic.section)
        {
            agent.SetDestination(playerPos);
        }
        while (section == playerLogic.section);
        {
            //agent.
        }
    }
}
