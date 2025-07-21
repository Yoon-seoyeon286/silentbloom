using UnityEngine;

public class Key1Door : MonoBehaviour
{

    public Transform player;
    public float doordistance = 1.5f;
    public GameObject lockedMessageUI;

    Animator animator;
    bool isopen = false;

    public string RequireKey = "Key1";
    PlayerInventory inventory;

    public AudioClip opensound;
    public AudioClip Locksound;
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

                audioSource.PlayOneShot(opensound);

            }
            else
            {
                ShowLockedMessage();
                audioSource.PlayOneShot(Locksound);
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
