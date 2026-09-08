using UnityEngine;
using UnityEngine.AI;

public class lostGhostLogic : mainGhostLogic
{
    private bool go = true;
    private float time = 5f;
    private sections sections;
    private GameObject section;
    public int sectionNumber;
    private void Start()
    {
        ghostVar = 1;
        sectionNumber = 1;
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        while (time > 0 ) { time -= Time.deltaTime; Debug.Log(time); }
        if (sectionNumber != playerLogic.section) { agent.SetDestination(playerPos); Debug.Log(sectionNumber); Debug.Log(sectionNumber); Debug.Log(sectionNumber); }
        if (sectionNumber == playerLogic.section)
        {
            int r = Random.Range(1,5);
            switch (r)
            {
                case 1:
                    {
                        agent.SetDestination(sections.sectLoc[0]);
                        break;
                    }
                case 2:
                    {
                        agent.SetDestination(sections.sectLoc[1]);
                        break;
                    }
                case 3:
                    {
                        agent.SetDestination(sections.sectLoc[2]);
                        break;
                    }
                case 4:
                    {
                        agent.SetDestination(sections.sectLoc[3]);
                        break;
                    }
            }
        }
    }
    public void GetSection(GameObject gameSection)
    {
        section = gameSection;
        sections = section.GetComponent<sections>();
    }
}
