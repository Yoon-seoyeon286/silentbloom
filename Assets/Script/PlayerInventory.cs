using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int KeyCount = 0;
    public int ToyCount = 0;
 
    public List<string> keys = new List<string>();//문자열 list

    public void AddKey(string KeyName) //리스트에 키를 저장
    {
        if (!keys.Contains(KeyName))
        {
            keys.Add(KeyName);
            Debug.Log("{KeyName}획득");
            KeyCount++;
        }
    }

    public bool WhatKey(string KeyName) //문을 열 때 해당 키가 있는지 확인
    {
        return keys.Contains(KeyName);
    }


    public void AddToy()
    {
        ToyCount++;
       
    }

  
}
