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

        //입력에 따른 이동 방향 벡터 계산
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

        //조이스틱 입력을 카메라 기준으로 회전
        Vector3 inputDir = new Vector3(h, 0f, v);

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;


        // y축 영향 제거
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * inputDir.z + camRight * inputDir.x;

        //회전 방향 계산
        Quaternion targetRotation = Quaternion.LookRotation(moveDir);

        //회전 적용
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

