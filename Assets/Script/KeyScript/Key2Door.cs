using UnityEngine;

public class Key2Door : MonoBehaviour
{

    Animator animator;
    public Transform player;
    PlayerInventory inventory;
    public GameObject lockedMessageUI;

    public float doordistance = 1.5f;

    public string RequireKey = "Key2";

    bool isopen = false;


    public AudioClip opendoor;
    public AudioClip Lockdoor;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
       inventory = player.GetComponent<PlayerInventory>();
        lockedMessageUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (isopen)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance > doordistance + 4.5f)
            {
                animator.SetTrigger("Close");
                isopen = false;
            }
        }
    }

    public void openclick()
    {

        float distance = Vector3.Distance(transform.position, player.position);

        if (!isopen && distance <= doordistance)
        {
            if (inventory != null && inventory.WhatKey(RequireKey))
            {
                animator.SetTrigger("Open");
                isopen = true;

                audioSource.PlayOneShot(opendoor);

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
