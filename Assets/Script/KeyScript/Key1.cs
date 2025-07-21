using UnityEngine;

public class Key1 : MonoBehaviour
{

    public string KeyName = "Key1";
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
                inventory.AddKey("Key1");
            }
            KeyMessage.SetActive(true);
            Invoke(nameof(HideKeyMessage), 2f);
            AudioSource.PlayClipAtPoint(GetKey, transform.position);

            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void HideKeyMessage()
    {
        KeyMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
