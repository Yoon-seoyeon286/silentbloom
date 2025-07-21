using System.Collections.Generic;
using UnityEngine;

public class OpenDoorKey : MonoBehaviour
{
  

    public Transform player;
    public float doordistance = 0.1f;
    public GameObject lockedMessageUI;

    Animator animator;
    bool isopen = false;

    public string RequireKey = "Key";

    PlayerInventory inventory;

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
        
    }

    void ShowLockedMessage()
    {
        if (lockedMessageUI != null)
        {
            lockedMessageUI.SetActive(true);
            Invoke(nameof(HideLockedMessage), 2f); // 2초 후 자동 사라짐
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

        if (isopen && distance > doordistance + 4.5f)
        {
            animator.SetTrigger("Close");
            isopen = false;
        }
    }

    void HideLockedMessage()
    {
        lockedMessageUI.SetActive(false);
    }
}

    



