using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float controlPitchFactor = 30f;  // x�� ���� (����)
    [SerializeField] private float controlYawFactor = 40f;    // y�� ȸ�� (�¿�)
    [SerializeField] private float controlRollFactor = 15f;   // z�� ���� (�¿� �����)

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �̵�
        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;

        // ȸ��
        ApplyRotation(h, v);
    }

    private void ApplyRotation(float h, float v)
    {
        // Pitch = ���� �Է����� X�� ȸ�� (���� ����)
        float pitch = controlPitchFactor * v;

        // Yaw = �¿� �Է����� Y�� ȸ�� (�¿� �ٶ󺸱�)
        float yaw = -controlYawFactor * h;

        // Roll = �¿� �Է����� Z�� ����̱� (�� ��鸲)
        float roll = -controlRollFactor * h;

        Quaternion targetRot = Quaternion.Euler(pitch, yaw, roll);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }
}
