using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    public VariableJoystick joy;

    void Start()
    {

        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");*/

        float h = joy.Horizontal;
        float v = joy.Vertical;

        bool isWalking = (h != 0 || v != 0);

       

        // �ִϸ����Ϳ� bool �� ����
        animator.SetBool("IsWalking", isWalking);

    }
}
