using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingCamera : MonoBehaviour
{

    public Transform target;

    public Vector3 offset = new Vector3(0, 1.6f, -4f);

    public float followSpeed = 5f;
    public float rotatedSpeed = 3f;

    private void LateUpdate()
    {
        Vector3 desiredPos = target.position + target.forward * offset.z + Vector3.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.forward),
            rotatedSpeed * Time.deltaTime);
    }

}
