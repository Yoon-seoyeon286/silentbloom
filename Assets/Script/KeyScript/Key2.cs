using UnityEngine;

public class Key2 : MonoBehaviour
{
    public string KeyName = "Key2";
    public GameObject KeyMessage;


    public AudioClip GetKey;
    AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if(inventory != null)
        {
            inventory.AddKey("Key2");
            KeyMessage.SetActive(true);
            Invoke(nameof(HideKeyMessage), 2f);
        }
        AudioSource.PlayClipAtPoint(GetKey, transform.position);
        gameObject.SetActive(false);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();


    }
    void HideKeyMessage()
    {
        KeyMessage.SetActive(false);
    }


    void Update()
    {
        
    }
}
