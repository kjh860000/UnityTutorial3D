using UnityEngine;
using System.Collections.Generic;

public class DepthFirstSearch : MonoBehaviour
{
    public int[,] nodes = new int[8, 8]
    {
      // 0  1  2  3  4  5  6  7
        {0, 1, 1, 1, 0, 0, 0, 0}, // 0
        {1, 0, 0, 0, 1, 1, 0, 0}, // 1
        {1, 0, 0, 0, 0, 0, 0, 0}, // 2
        {1, 0, 0, 0, 0, 0, 1, 0}, // 3
        {0, 1, 0, 0, 0, 1, 0, 0}, // 4
        {0, 1, 0, 0, 1, 0, 0, 1}, // 5
        {0, 0, 0, 1, 0, 0, 0, 0}, // 6
        {0, 0, 0, 0, 0, 1, 0, 0}, // 7
    };

    public Stack<int> stack = new Stack<int>();
    private bool[] visited = new bool[8];

    private void Start()
    {
        DFSearch(0);
    }

    void DFSearch(int start)
    {
        stack.Push(start);

        while (stack.Count > 0)
        {
            int index = stack.Pop();

            if (!visited[index])    // �湮 ����
            {
                visited[index] = true;
                Debug.Log($"{index}�� ��忡 �湮");

                for (int i = nodes.GetLength(0) - 1; i >= 0; i--)
                {
                    if (nodes[index, i] == 1 && !visited[i])
                        stack.Push(i);
                }
            }
        }
    }
}
