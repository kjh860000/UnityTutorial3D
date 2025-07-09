using System.Collections;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 };
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars;

    public static GameObject selectDonut;
    public static bool isSelected;

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--)
        {
            GameObject donut = Instantiate(donutPrefabs[i]);
            donut.transform.position = new Vector3(-5f, 5f, 0);

            bars[0].PushDonut(donut);   // 생성한 도넛을 해당 bar의 stack push

            yield return new WaitForSeconds(1f);
        }
    }
}
