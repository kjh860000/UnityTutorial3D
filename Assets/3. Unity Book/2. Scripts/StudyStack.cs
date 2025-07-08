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

        Debug.Log(stack.Pop());     //  Last 값을 뽑음 (맨 위 데이터)
        Debug.Log(stack.Peek());    //  다음에 뽑힐 대상을 확인*/
    }
}
