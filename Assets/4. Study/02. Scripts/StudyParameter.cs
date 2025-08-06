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

    // �Ϲ����� �Ű����� -> Call by Value
    private void NomalParameter(int num)
    {
        num = 10;
    }

    // ���� ����� �Ű����� -> Call by Reference
    private void ReferenceParameter(ref int num)
    {
        num = 20;
    }

    private void OutParameter(out int num)
    {
        num = 30;
    }


    #region �Ű����� ���
    // ������ �Ű����� (Default �Ű�����)
    private void DefaultParameter(int num = 3)
    {

    }

    // �����ε� : �Ű������� �ٸ����ؼ� �ٸ� ����� �����ϴ� ���
    private void OverloadingMethod() { Debug.Log("��� A"); }

    private void OverloadingMethod(int num) { Debug.Log("��� B"); }

    private void OverloadingMethod(float num) { Debug.Log("��� C"); }

    private void OverloadingMethod(bool isNum) { Debug.Log("��� D"); }

    private void OverloadingMethod(int num1, int num2) { Debug.Log("��� E"); }
    #endregion
}