using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingCamera : MonoBehaviour
{

    public GameObject target;
 
    public float rotateSpeed = 3f;
    public Vector3 offset = new Vector3(0, 5, -5);

    private void LateUpdate()
    {
        Quaternion targetRotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        Vector3 desiredPosition = target.transform.position + targetRotation * offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, rotateSpeed * Time.deltaTime);

        transform.LookAt(target.transform.position + Vector3.up * 1.5f);
    }

}
