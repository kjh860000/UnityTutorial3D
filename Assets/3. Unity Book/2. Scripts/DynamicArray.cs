using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    //private object[] array = new object[3];

    public List<int> list1 = new List<int> { 1, 2, 3 };

    private void Start()
    {
        list1.Add(10);
    }
/*    void Add(object o)
    {
        var temp = new object[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }

        array = temp;
        array[array.Length-1] = o;
    }*/
}
