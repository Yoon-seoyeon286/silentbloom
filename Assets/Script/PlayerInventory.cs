using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int KeyCount = 0;
    public int ToyCount = 0;
 
    public List<string> keys = new List<string>();//���ڿ� list

    public void AddKey(string KeyName) //����Ʈ�� Ű�� ����
    {
        if (!keys.Contains(KeyName))
        {
            keys.Add(KeyName);
            Debug.Log("{KeyName}ȹ��");
            KeyCount++;
        }
    }

    public bool WhatKey(string KeyName) //���� �� �� �ش� Ű�� �ִ��� Ȯ��
    {
        return keys.Contains(KeyName);
    }


    public void AddToy()
    {
        ToyCount++;
       
    }

  
}
