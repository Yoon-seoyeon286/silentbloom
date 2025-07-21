using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingCamera : MonoBehaviour
{
    public Transform target;         // 캐릭터
    public Vector3 offset = new Vector3(0, 2, -6); // 캐릭터 기준 위치 (등 뒤)
    public float followSpeed = 10f;
    public float rotationSpeed = 2f;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        
    }

 
    void LateUpdate()
    {
        // 회전 동기화 (캐릭터의 회전을 따라감)
        Quaternion targetRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);

        // 위치 계산: 회전된 오프셋을 더하여 위치 잡기
        Vector3 desiredPosition = target.position + targetRotation * offset;

        // 위치 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // 카메라는 항상 캐릭터를 바라본다 (뒷통수 보기용)
        transform.LookAt(target.position + Vector3.up * 1.5f); // 살짝 위를 봄 (뒷통수 중심)
    }
}
