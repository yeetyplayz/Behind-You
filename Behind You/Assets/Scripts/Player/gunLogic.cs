using UnityEngine;

public class gunLogic : MonoBehaviour
{
    private int ammo = 99;
    private int range = 100;
    private RaycastHit hit;
    public GameObject cam;
    private lostGhostLogic l;
    private cutOffGhost c;

    public void GainAmmo(int count) { ammo += count; }

    private void Fire()
    {
        if (ammo <= 0) { Debug.LogWarning("Empty Magazine"); return; }
        ammo--;
        Debug.DrawRay(cam.transform.position, cam.transform.forward * range, Color.red);
        if (ammo >= 1) 
        { 
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.collider.gameObject.tag == "Lost")
                {
                    l = hit.collider.gameObject.GetComponent<lostGhostLogic>();
                    l.Die();
                    Debug.Log(hit.collider.gameObject.name);
                }
                else if (hit.collider.gameObject.tag == "cut")
                {
                    c = hit.collider.gameObject.GetComponent<cutOffGhost>();
                    c.Die();
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }
}
