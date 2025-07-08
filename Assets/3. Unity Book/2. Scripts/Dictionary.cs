using UnityEngine;
using System.Collections.Generic;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int age, string name, float height, float weight) 
    {
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
    }

}
public class Dictionary : MonoBehaviour
{
    //public Dictionary<string, int> persons = new Dictionary<string, int>();
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    private void Start()
    {
        /*        persons.Add("ö��", 10);
                persons.Add("����", 15);
                persons.Add("����", 17);

                int age = persons["ö��"];
                Debug.Log(age);

                foreach (var person in persons)
                {
                    Debug.Log(person.Key);  //�̸�
                    Debug.Log(person.Value);    //����
                }

                // true / false
                persons.ContainsKey("ö��");  // ö���� ����
                persons.ContainsValue(17);  // 17�� ����*/

        persons.Add("ö��", new PersonData(10, "ö��", 150f, 30f));
        persons.Add("����", new PersonData(10, "����", 150f, 30f));
        persons.Add("����", new PersonData(10, "����", 150f, 30f));

        Debug.Log(persons["ö��"].age);
        Debug.Log(persons["ö��"].name);
        Debug.Log(persons["ö��"].height);
        Debug.Log(persons["ö��"].weight);
    }
}
