using UnityEngine;

public class Key3 : MonoBehaviour
{
    public string KeyName = "Key3";
    public GameObject KeyMessage;

    public AudioClip GetKey;
    AudioSource audioSource;


    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddKey("Key3");
                KeyMessage.SetActive(true);
                Invoke(nameof(HideKeyMessage), 2f);
            }

            AudioSource.PlayClipAtPoint(GetKey, transform.position);

            gameObject.SetActive(false);

        }
    }
    void HideKeyMessage()
    {
        KeyMessage.SetActive(false);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
