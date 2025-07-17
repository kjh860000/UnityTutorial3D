using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float controlPitchFactor = 30f;  // x축 기울기 (상하)
    [SerializeField] private float controlYawFactor = 40f;    // y축 회전 (좌우)
    [SerializeField] private float controlRollFactor = 15f;   // z축 기울기 (좌우 기울임)

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동
        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;

        // 회전
        ApplyRotation(h, v);
    }

    private void ApplyRotation(float h, float v)
    {
        // Pitch = 상하 입력으로 X축 회전 (비행 느낌)
        float pitch = controlPitchFactor * v;

        // Yaw = 좌우 입력으로 Y축 회전 (좌우 바라보기)
        float yaw = -controlYawFactor * h;

        // Roll = 좌우 입력으로 Z축 기울이기 (몸 흔들림)
        float roll = -controlRollFactor * h;

        Quaternion targetRot = Quaternion.Euler(pitch, yaw, roll);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }
}
