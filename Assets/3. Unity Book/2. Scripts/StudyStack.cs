using System.Collections.Generic;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public int[] array = new int[3] {1,2,3};
    public int[] array2;

    private void Start()
    {
        stack = new Stack<int>(array);

        array2 = stack.ToArray();

/*        for(int i = 1; i <= 10; i++) 
        {
            stack.Push(i);
        }

        Debug.Log(stack.Pop());     //  Last ���� ���� (�� �� ������)
        Debug.Log(stack.Peek());    //  ������ ���� ����� Ȯ��*/
    }
}
