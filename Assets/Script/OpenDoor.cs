using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    Animator animator;
    public Transform Player;
    public float DoorDistance = 2.0f;
    bool isopen = false;

     AudioSource audioSource;
    public AudioClip doorOpenClip;




    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
  
    void Update()
    {

    

        
    }


    public void openclick()
    {


        float distance = Vector3.Distance(Player.position, transform.position);


        if (distance <= DoorDistance && !isopen)
        {
            animator.SetTrigger("Open");
            isopen = true;

            audioSource.PlayOneShot(doorOpenClip);

        }


        else if (distance > DoorDistance + 4.0f && isopen)
        {
            animator.SetTrigger("Close");
            isopen = false;

        }
    }
}
