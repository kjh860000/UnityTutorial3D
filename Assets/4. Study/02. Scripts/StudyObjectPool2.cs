using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class StudyObjectPool2 : StudyGenericSingleton<StudyObjectPool2>
{
    public ObjectPool<GameObject> objPool;
    public GameObject objPrefab;

    void Awake()
    {
        objPool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);

        return obj;
    }

    private void GetObject(GameObject obj)
    {
        Debug.Log("Ǯ���� ������Ʈ �̴� ���");
        obj.SetActive(true);
    }

    private void ReleaseObject(GameObject obj)
    {
        Debug.Log("Ǯ�� ������Ʈ�� �ִ� ���");
        obj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objPool.Get();
        }

        // ������ ������Ʈ���� ����ϴ� ���
        // StudyObjectPool2.Instance.objPool.Release(gameObject);
    }
}
