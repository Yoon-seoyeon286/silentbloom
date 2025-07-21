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

        Vector3 inputDir = new Vector3(h, 0, v).normalized; //�밢�� �̵� �ӵ� ����

        Vector3 moveDir = transform.TransformDirection(inputDir); //���� ��ǥ�踦 ĳ���� ��ǥ��� ����

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

