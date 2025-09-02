using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetCsvParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int attack;

        public CharacterData(string charID, string name, int hp, int attack)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
    }

    public string URL;
    public List<CharacterData> characters = new List<CharacterData>();

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        Debug.Log(data);
    }
}