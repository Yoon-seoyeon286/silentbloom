using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingCamera : MonoBehaviour
{

    public Transform target;

    public Vector3 offset = new Vector3(0, 5, -5);

    public float followSpeed = 5f;
    public float rotatedSpeed = 3f;

    private void LateUpdate()
    {
        Quaternion targetRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);
        Vector3 rotatedOffset = targetRotation * offset;

        Vector3 desiredPos = target.position + rotatedOffset;

        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotatedSpeed * Time.deltaTime);
        
    }

}
