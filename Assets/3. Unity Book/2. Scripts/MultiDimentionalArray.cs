using UnityEngine;

public class MultiDimentionalArray : MonoBehaviour
{
    public int[,] array1 = new int[3, 3];
    public int[,,] array2 = new int[3, 3, 3];

    private void Start()
    {
        int number1 = array1[1, 0];
    }
}
