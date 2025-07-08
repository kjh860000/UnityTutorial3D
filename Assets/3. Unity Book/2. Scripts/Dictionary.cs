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
        /*        persons.Add("Ã¶¼ö", 10);
                persons.Add("¿µÈñ", 15);
                persons.Add("µ¿¼ö", 17);

                int age = persons["Ã¶¼ö"];
                Debug.Log(age);

                foreach (var person in persons)
                {
                    Debug.Log(person.Key);  //ÀÌ¸§
                    Debug.Log(person.Value);    //³ªÀÌ
                }

                // true / false
                persons.ContainsKey("Ã¶¼ö");  // Ã¶¼ö°¡ Æ÷ÇÔ
                persons.ContainsValue(17);  // 17ÀÌ Æ÷ÇÔ*/

        persons.Add("Ã¶¼ö", new PersonData(10, "Ã¶¼ö", 150f, 30f));
        persons.Add("¿µÈñ", new PersonData(10, "¿µÈñ", 150f, 30f));
        persons.Add("µ¿¼ö", new PersonData(10, "µ¿¼ö", 150f, 30f));

        Debug.Log(persons["Ã¶¼ö"].age);
        Debug.Log(persons["Ã¶¼ö"].name);
        Debug.Log(persons["Ã¶¼ö"].height);
        Debug.Log(persons["Ã¶¼ö"].weight);
    }
}
