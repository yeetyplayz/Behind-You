using UnityEngine;

public class cheeseBallLogic : MonoBehaviour
{
    private playerLogic pL;
    private gunLogic gL;
    private bool uOrD = true; // true is up, false is down.
    public AudioClip pickupSound;
    public AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        float jitter = 1f;
        Vector3 pos = transform.position;
        if (pos.y <= 0.8f || uOrD) 
        { 
            transform.Translate(Vector3.up * jitter * Time.deltaTime); uOrD = true; 
            if (pos.y >= 1.5f ) { uOrD = false; }
        }
        else if (pos.y >= 1.5f || uOrD == false) 
        { 
            transform.Translate(Vector3.down * jitter * Time.deltaTime); uOrD = false;
            if (pos.y <= 0.8f) { uOrD = true; }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        pL = other.GetComponent<playerLogic>();
        gL = other.GetComponentInChildren<gunLogic>();
        if (gameObject.CompareTag("Small")) { pL.GainScore("small"); }
        if (gameObject.CompareTag("Big")) 
        { 
            pL.GainScore("big");
            gL.GainAmmo(1);
            AudioSource.clip = pickupSound;
                    AudioSource.Play();

        }
        
        Destroy(gameObject);
    }
}
