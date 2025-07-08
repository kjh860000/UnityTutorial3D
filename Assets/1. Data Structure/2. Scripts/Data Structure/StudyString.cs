using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = " Hello World ";

    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    private void Start()
    {
        Debug.Log(str1.Length); // 문자길이 13

        Debug.Log(str1.Trim()); // 앞뒤 공백 제거 : Hello World
        Debug.Log(str1.Trim('*')); // 앞뒤 해당 문자 제거

        Debug.Log(str1.ToUpper()); // 대문자
        Debug.Log(str1.ToLower()); // 소문자

        Debug.Log(str1.Contains('H')); // 해당 문자가 있는지
    }
}
