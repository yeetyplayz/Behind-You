using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class cutOffGhost : mainGhostLogic
{
    public Vector3 destination;
    private bool dead;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        playerPos = player.transform.position;
        if (dead == false) { agent.SetDestination(playerPos); }
        destination = agent.destination;
    }
    public void IncreaseDiff()
    {
        agent.speed = agent.speed * 1.1f;
    }
    public void Die() { StartCoroutine(DieRoutine()); }
    IEnumerator DieRoutine()
    {
        Debug.Log("cut died");
        dead = true;
        gameObject.SetActive(false);
        agent.ResetPath();
        agent.SetDestination(transform.parent.position);
        while (agent.hasPath && agent.remainingDistance > agent.stoppingDistance) { yield return null; }
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(true);
        dead = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerLogic.Die();
        }
    }
}