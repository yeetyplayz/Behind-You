using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class lostGhostLogic : mainGhostLogic
{
    public sections sections;
    public GameObject section;
    public int sectionNumber;
    private bool dead;
    public Vector3 destination;
    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        section = transform.parent.parent.parent.gameObject;
        sections = section.GetComponentInChildren<sections>();
        sectionNumber = 1;
        player = FindAnyObjectByType<playerLogic>().gameObject;
        playerLogic = player.GetComponent<playerLogic>();
    }
    private void FixedUpdate()
    {
        playerPos = player.transform.position;
        if (sectionNumber != playerLogic.section && dead == false) { if (!agent.hasPath) { agent.SetDestination(playerPos); } }
        if (sectionNumber == playerLogic.section && dead == false)
        {
            if (!agent.hasPath || agent.remainingDistance < 0.5f)
            {
                int r = Random.Range(0, sections.sectLoc.Length);
                agent.SetDestination(sections.sectLoc[r]);
            }
        }
        destination = agent.destination;
    }
    public void GetSection(GameObject gameSection)
    {
        section = gameSection;
        sections = section.GetComponent<sections>();
    }
    public void Die() { StartCoroutine(DieRoutine()); }
    IEnumerator DieRoutine()
    {
        dead = true;
        gameObject.SetActive(false);
        agent.SetDestination(transform.parent.position);
        while (agent.hasPath && agent.remainingDistance > agent.stoppingDistance) { agent.path = null; }
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(true);
        dead = false;
    }
    public void IncreaseDiff()
    {
        agent.speed = agent.speed * 1.15f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerLogic.Die();
        }
    }
}
