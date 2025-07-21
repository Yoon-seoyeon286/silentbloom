using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    public int hitCount = 0;
    public int maxhit = 4;
    public bool isDead = false;
    Animator animator;
    public GameObject overImage;


    public GameObject effectPrefab;

    public VariableJoystick joy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
 

}


    void Update()
    {
        float h = joy.Horizontal;
        float v = joy.Vertical;

        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");*/

        Vector3 inputDir = new Vector3(h, 0, v).normalized; //대각선 이동 속도 제어

        Vector3 moveDir = transform.TransformDirection(inputDir); //월드 좌표계를 캐릭터 좌표계로 변형

        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.01f);

       
        }

        Vector3 newPosition = rb.position + moveDir * speed * Time.deltaTime;
        rb.MovePosition(newPosition);

    }

    public void Damage()
    {

        if (isDead) return;

        hitCount++;

        Instantiate(effectPrefab, transform.position, Quaternion.identity);

        if(hitCount== maxhit)
        {
            animator.SetTrigger("Dead");
            Die();

        }

    }

    void Die()
    {
        isDead = true;
        Debug.Log("You Dead");
        Invoke(nameof(ShowGameOverImage), 3f);
    }

    void ShowGameOverImage()
    {
        overImage.SetActive(true);
    }


}

