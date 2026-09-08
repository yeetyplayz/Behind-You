using UnityEngine;

public class sections : MonoBehaviour
{
    public GameObject[] section;
    public Vector3[] sectLoc;
    private playerLogic playerLogic;
    private lostGhostLogic lostGhostLogic;
    public int sectionNumber;

    private void Start()
    {
        sectLoc[0] = section[0].transform.position;
        sectLoc[1] = section[1].transform.position;
        sectLoc[2] = section[2].transform.position;
        sectLoc[3] = section[3].transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lost")
        {
            lostGhostLogic = GetComponent<lostGhostLogic>();
            lostGhostLogic.sectionNumber = sectionNumber;
            lostGhostLogic.GetSection(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Maze")) return;
        if (other.gameObject.tag == "Player")
        {
            playerLogic = GetComponent<playerLogic>();
            playerLogic.section = sectionNumber;
        }
        else if (other.gameObject.tag == "Lost")
        {
            lostGhostLogic = GetComponent<lostGhostLogic>();
            lostGhostLogic.sectionNumber = sectionNumber;
            lostGhostLogic.GetSection(gameObject);
        }
        else return;
    }
}
