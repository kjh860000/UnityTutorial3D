using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)   // instance�� ��������� �ڽ��� �Ҵ�
        {
            Instance = this;
        }
        else    // �̹� singletonEx2�� �����ϸ� this ��ũ��Ʈ ���� >> �ߺ� ���� ����
        {
            Destroy(gameObject);
        }
    }
}