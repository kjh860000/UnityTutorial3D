using UnityEngine;

public class Permutation : MonoBehaviour
{
    // 모든 배열 가능한 순서 출력
    public int[] array = new int[3] {1, 2, 3};

    private void Start()
    {
        PermutationFunction(array, 0);
    }

    void PermutationFunction(int[] arr, int start)
    {
        if (start == arr.Length)
        {
            Debug.Log(string.Join(", ", arr));
            return;
        }

        for (int i = start; i < arr.Length; i++)
        {
            // Swap : 자리바꾸기
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFunction(arr, start + 1);

            // 원상복구 BackTracking
            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
        }
    }
}
