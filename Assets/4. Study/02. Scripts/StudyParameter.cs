using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    public int number = 1;
    public int number2;

    void Start()
    {
        // NomalParameter(number);
        // ReferenceParameter(ref number);

        OutParameter(out number2);


    }

    // 일반적인 매개변수 -> Call by Value
    private void NomalParameter(int num)
    {
        num = 10;
    }

    // 참조 방식의 매개변수 -> Call by Reference
    private void ReferenceParameter(ref int num)
    {
        num = 20;
    }

    private void OutParameter(out int num)
    {
        num = 30;
    }


    #region 매개변수 방식
    // 선택적 매개변수 (Default 매개변수)
    private void DefaultParameter(int num = 3)
    {

    }

    // 오버로딩 : 매개변수를 다르게해서 다른 기능을 구현하는 방법
    private void OverloadingMethod() { Debug.Log("기능 A"); }

    private void OverloadingMethod(int num) { Debug.Log("기능 B"); }

    private void OverloadingMethod(float num) { Debug.Log("기능 C"); }

    private void OverloadingMethod(bool isNum) { Debug.Log("기능 D"); }

    private void OverloadingMethod(int num1, int num2) { Debug.Log("기능 E"); }
    #endregion
}