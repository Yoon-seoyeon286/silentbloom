using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

public class Drawe : MonoBehaviour
{

    PlayableDirector playDrawer; //Ÿ�Ӷ���
    bool played =  false;
    public GameObject KeyMessage;

    float interactionDistance = 1.5f;

    public GameObject Keyobj;
    public Transform player; //�÷��̾� ��ġ��

    bool hasKey = false;

    public string keyName = "Key";

    public AudioClip GetKey;
    AudioSource audioSource;


    void Start()
    {
        playDrawer = GetComponent<PlayableDirector>();
        audioSource = GetComponent<AudioSource>();

    }

   
    void Update()
    {

    }


    public void buttomclicked()
    {


        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > interactionDistance) return;

        if (!played)
        {

            playDrawer.Stop();
            playDrawer.time = 0;
            playDrawer.Play();


            Invoke(nameof(GiveKeyToPlayer), 1f); //1�ʵ� �ڵ����� Ű ���� �κ�ũ��(�Լ��̸�.�����̽ð�)

        }

    }

    void GiveKeyToPlayer() //�÷��̾�� Ű�� �ִ� �Լ�
    {
        if (hasKey || Keyobj == null) return; //Ű�� ���ų� Ű �������� ���� ����

        if (!Keyobj.CompareTag("Key")) return; //���� Ű ������ �±װ� Ű�� �ƴϸ� ����

        PlayerInventory inventory = player.GetComponent<PlayerInventory>(); //�÷��̾� �κ��丮 ȣ��
        if(inventory != null) //�κ��丮�� ���� �ִٸ�? (���� �� ������ ���� �ȴ��ؾ���)
        {
            inventory.AddKey(keyName);
            KeyMessage.SetActive(true);


            Invoke(nameof(HideKeyMessage), 2f);
        }

        audioSource.PlayOneShot(GetKey);


        Destroy(Keyobj); //Ű�� ������ ��
        hasKey = true;
    }

 void HideKeyMessage()
    {
        KeyMessage.SetActive(false);
    } 
}
