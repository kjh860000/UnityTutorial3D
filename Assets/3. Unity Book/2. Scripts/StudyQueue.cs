using UnityEngine;
using System.Collections.Generic;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    private void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            queue.Enqueue(i);
        }

        int output = queue.Dequeue();   // 값을 뽑음
        Debug.Log(output);

        Debug.Log(queue.Peek());    // 그 다음 뽑을 값 확인
        Debug.Log(queue.Contains(5));    // 값 5가 포함되어있는지 확인

        queue.Clear();  // 모든 값 삭제

        Debug.Log(queue.Count);    // 개수 확인
    }
}
