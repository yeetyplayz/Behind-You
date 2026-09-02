using UnityEngine;

public class sections : MonoBehaviour
{
    private playerLogic playerLogic;
    private lostGhostLogic lostGhostLogic;
    public int section;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerLogic = GetComponent<playerLogic>();
            playerLogic.section = section;
        }
        if (other.gameObject.tag == "Lost")
        {
            lostGhostLogic = GetComponent<lostGhostLogic>();
            lostGhostLogic.section = section;
        }
        else return;
    }
}
