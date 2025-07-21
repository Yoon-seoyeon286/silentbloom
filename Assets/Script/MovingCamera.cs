using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingCamera : MonoBehaviour
{
    public Transform target;         // ĳ����
    public Vector3 offset = new Vector3(0, 2, -6); // ĳ���� ���� ��ġ (�� ��)
    public float followSpeed = 10f;
    public float rotationSpeed = 2f;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        
    }

 
    void LateUpdate()
    {
        // ȸ�� ����ȭ (ĳ������ ȸ���� ����)
        Quaternion targetRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);

        // ��ġ ���: ȸ���� �������� ���Ͽ� ��ġ ���
        Vector3 desiredPosition = target.position + targetRotation * offset;

        // ��ġ �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // ī�޶�� �׻� ĳ���͸� �ٶ󺻴� (����� �����)
        transform.LookAt(target.position + Vector3.up * 1.5f); // ��¦ ���� �� (����� �߽�)
    }
}
