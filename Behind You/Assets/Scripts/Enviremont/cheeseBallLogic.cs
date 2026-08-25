using UnityEngine;

public class cheeseBallLogic : MonoBehaviour
{
    private playerLogic pL;
    private gunLogic gL;
    private void OnTriggerEnter(Collider other)
    {
        pL = other.GetComponent<playerLogic>();
        gL = other.GetComponentInChildren<gunLogic>();
        if (gameObject.CompareTag("Small")) { pL.GainScore("small"); }
        if (gameObject.CompareTag("Big")) 
        { 
            pL.GainScore("big");
            gL.GainAmmo(1);
        }
        Destroy(gameObject);
    }
}
