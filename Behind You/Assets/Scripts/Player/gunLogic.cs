using UnityEngine;

public class gunLogic : MonoBehaviour
{
    private int ammo = 99; //test purposes

    public void GainAmmo(int count) { ammo += count; }

    private void Fire()
    {
        if (ammo <= 0) { Debug.LogWarning("Empty Magazine"); }
        else if (ammo >= 1) { }
    }
}
