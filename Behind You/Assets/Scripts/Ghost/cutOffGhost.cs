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
        MeshRenderer mr = GetComponent<MeshRenderer>();
        MeshRenderer mrc = GetComponentInChildren<MeshRenderer>();
        mr.enabled = false;
        mrc.enabled = false;
        agent.ResetPath();
        agent.SetDestination(transform.parent.position);
        while (agent.hasPath && agent.remainingDistance > agent.stoppingDistance) { yield return null; }
        yield return new WaitForSeconds(10f);
        mr.enabled = true;
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