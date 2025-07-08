using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = " Hello World ";

    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    private void Start()
    {
        Debug.Log(str1.Length); // ���ڱ��� 13

        Debug.Log(str1.Trim()); // �յ� ���� ���� : Hello World
        Debug.Log(str1.Trim('*')); // �յ� �ش� ���� ����

        Debug.Log(str1.ToUpper()); // �빮��
        Debug.Log(str1.ToLower()); // �ҹ���

        Debug.Log(str1.Contains('H')); // �ش� ���ڰ� �ִ���
    }
}
