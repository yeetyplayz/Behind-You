using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class lostGhostLogic : mainGhostLogic
{
    public sections sections;
    public GameObject section;
    public int sectionNumber;
    private void Start()
    {
        sections = section.GetComponent<sections>();
        sectionNumber = 1;
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        playerPos = player.transform.position;
        if (sectionNumber != playerLogic.section) { if (!agent.hasPath) { agent.SetDestination(playerPos); } }
        if (sectionNumber == playerLogic.section)
        {
            if (!agent.hasPath || agent.remainingDistance < 0.5f)
            {
                int r = Random.Range(0, sections.sectLoc.Length);
                agent.SetDestination(sections.sectLoc[r]);
            }
        }
    }
    public void GetSection(GameObject gameSection)
    {
        section = gameSection;
        sections = section.GetComponent<sections>();
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
    public void IncreaseDiff()
    {
        agent.speed = agent.speed * 1.15f;
    }
}
