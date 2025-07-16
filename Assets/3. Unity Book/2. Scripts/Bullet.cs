using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 36f; // 초당 회전

    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0f, -rotationSpeed * Time.deltaTime, 0f);
    }
}
