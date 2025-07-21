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
    public Transform cam;
    float rotateSpeed = 4f;


    public GameObject effectPrefab;

    public VariableJoystick joy;
    public FixedJoystick fixJoy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
 

}


    void FixedUpdate()
    {
        float h = joy.Horizontal;
        float v = joy.Vertical;

        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");*/

        //�Է¿� ���� �̵� ���� ���� ���
        Vector3 move = (transform.forward * v) + (transform.right * h);
        Vector3 velocity = move.normalized * speed;

        rb.MovePosition(rb.position + velocity * Time.deltaTime);

        rotate();

    }

   void rotate()
    {
        float h = fixJoy.Horizontal;
        float v = fixJoy.Vertical;


        if (h == 0 && v == 0) return;

        //���̽�ƽ �Է��� ī�޶� �������� ȸ��
        Vector3 inputDir = new Vector3(h, 0f, v);

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;


        // y�� ���� ����
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * inputDir.z + camRight * inputDir.x;

        //ȸ�� ���� ���
        Quaternion targetRotation = Quaternion.LookRotation(moveDir);

        //ȸ�� ����
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
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

