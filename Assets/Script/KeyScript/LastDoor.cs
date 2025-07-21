using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class LastDoor : MonoBehaviour
{
    Animator animator;
    PlayerInventory inventory;
    public GameObject lockedMessageUI;

    public string RequirKey = "LastKey";
    public Transform player;

    public float doordistance = 1.5f;
    bool isopen = false;


    public AudioClip opendoor;
    public AudioClip Lockdoor;
    AudioSource audioSource;

    GameManager Manager;




    void Start()
    {
        animator = GetComponent<Animator>();
        inventory = player.GetComponent<PlayerInventory>();
        lockedMessageUI.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        Manager = player.GetComponent<GameManager>();

    }

    void Update()
    {
 
        

    }

    public void openclick()
    {

        float distance = Vector3.Distance(transform.position, player.position);
        if (!isopen && distance <= doordistance)
        {
            if (inventory != null && inventory.KeyCount>=6 && inventory.ToyCount >= 12)
            {
                animator.SetTrigger("Open");
                isopen = true;
                audioSource.PlayOneShot(opendoor);

                Manager.ClearGame();
            }

            else
            {
                ShowLockedMessage();
                audioSource.PlayOneShot(Lockdoor);
            }


        }

    }

void ShowLockedMessage()
    {
        if (lockedMessageUI != null)
        {
            lockedMessageUI.SetActive(true);
            Invoke(nameof(HideLockedMessage), 2f); // 2초 후 자동 사라짐
        }
    }

    void HideLockedMessage()
    {
        lockedMessageUI.SetActive(false);
    }

}
