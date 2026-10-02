using UnityEngine;

public class pressButton : MonoBehaviour
{
    public uiManager u;
    void Update()
    {
        if (Input.anyKey == true) { u.EnableUi(1); gameObject.SetActive(false); }   
    }
}
