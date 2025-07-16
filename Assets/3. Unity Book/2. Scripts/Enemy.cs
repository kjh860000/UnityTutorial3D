using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 dir;

    public GameObject explosionFactory;
    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 3 )  // 30%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        var score = sm.GetScore() + 10;
        sm.SetScore(score);

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
