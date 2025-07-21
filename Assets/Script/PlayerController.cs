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

        Vector3 direction = new Vector3(h, 0f, v);
        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);


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

