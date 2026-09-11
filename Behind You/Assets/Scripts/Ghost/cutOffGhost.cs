using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class cutOffGhost : mainGhostLogic
{
    public Vector3 destination;
    private void Start()
    {
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
    public void Die() { StartCoroutine(DieRoutine()); }
    IEnumerator DieRoutine()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
        agent.SetDestination(transform.parent.position);
        while (agent.hasPath && agent.remainingDistance > agent.stoppingDistance) { yield return null; }
        yield return new WaitForSeconds(10f);
        mr.enabled = true;
    }
}