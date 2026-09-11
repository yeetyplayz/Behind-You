using UnityEngine;
using UnityEngine.AI;

public class lostGhostLogic : mainGhostLogic
{
    public sections sections;
    public GameObject section;
    public int sectionNumber;
    private void Start()
    {
        sections = section.GetComponent<sections>();
        ghostVar = 1;
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
    public void IncreaseDiff()
    {
        agent.speed = agent.speed * 1.15f;
    }
}
