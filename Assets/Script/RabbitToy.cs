using UnityEngine;

public class RabbitToy : MonoBehaviour
{

   
    public AudioClip GetToy;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            PlayerInventory Inventory = other.GetComponent<PlayerInventory>();
            

            if (Inventory != null)
            {
                Inventory.AddToy();

            }
            AudioSource.PlayClipAtPoint(GetToy, transform.position);
          
            Destroy(gameObject);
           
        }
    }
    void Update()
    {
        
        
    }
}
