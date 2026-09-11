using UnityEngine;

public class gunLogic : MonoBehaviour
{
    private int ammo = 99; //test purposes
    private int range = 25;
    private RaycastHit hit;

    public void GainAmmo(int count) { ammo += count; }

    private void Fire()
    {
        if (ammo <= 0) { Debug.LogWarning("Empty Magazine"); }
        else if (ammo >= 1) 
        { 
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, range))
            {
                if (hit.collider.gameObject.tag == "Lost" || hit.collider.gameObject.tag == "cut")
                {
                    lostGhostLogic l = hit.collider.gameObject.GetComponent<lostGhostLogic>();
                    l.Die();
                    cutOffGhost c = hit.collider.gameObject.GetComponent<cutOffGhost>();
                    c.Die();
                    ammo--;
                }
                else { ammo--; }
            }
        }
    }
}
