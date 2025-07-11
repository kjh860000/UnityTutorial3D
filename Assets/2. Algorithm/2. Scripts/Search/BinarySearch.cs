using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private int target = 7;

    private void Start()
    {
        int result = BSearch();
        Debug.Log(result);
    }

    private int BSearch()
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right) 
        {
            int mid = (right + left) / 2;

            if (array[mid] == target)
                return mid;
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else  // array[mid] > target
            {
                right = mid - 1;
            }
        }
        return -1;  // 찾고자 하는 값이 존재하지 않을경우 실패 신호로 -1 출력
    }
}
