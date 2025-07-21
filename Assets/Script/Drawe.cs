using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

public class Drawe : MonoBehaviour
{

    PlayableDirector playDrawer; //타임라인
    bool played =  false;
    public GameObject KeyMessage;

    float interactionDistance = 1.5f;

    public GameObject Keyobj;
    public Transform player; //플레이어 위치값

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


            Invoke(nameof(GiveKeyToPlayer), 1f); //1초뒤 자동으로 키 습득 인보크는(함수이름.딜레이시간)

        }

    }

    void GiveKeyToPlayer() //플레이어에게 키를 주는 함수
    {
        if (hasKey || Keyobj == null) return; //키가 없거나 키 오브제가 없음 리턴

        if (!Keyobj.CompareTag("Key")) return; //만일 키 오브제 태그가 키가 아니면 리턴

        PlayerInventory inventory = player.GetComponent<PlayerInventory>(); //플레이어 인벤토리 호출
        if(inventory != null) //인벤토리에 무언가 있다면? (위에 두 개에서 리턴 안당해야함)
        {
            inventory.AddKey(keyName);
            KeyMessage.SetActive(true);


            Invoke(nameof(HideKeyMessage), 2f);
        }

        audioSource.PlayOneShot(GetKey);


        Destroy(Keyobj); //키는 없어질 것
        hasKey = true;
    }

 void HideKeyMessage()
    {
        KeyMessage.SetActive(false);
    } 
}
