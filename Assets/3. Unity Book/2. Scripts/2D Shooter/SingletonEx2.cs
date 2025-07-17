using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)   // instance가 비어있으면 자신을 할당
        {
            Instance = this;
        }
        else    // 이미 singletonEx2가 존재하면 this 스크립트 삭제 >> 중복 생성 방지
        {
            Destroy(gameObject);
        }
    }
}