using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5f;

    public GameObject explosionFactory;
    private void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 7 )  // %
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
/*        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        var score = sm.GetScore() + 10;
        sm.SetScore(score);*/

        ScoreManager.Instance.Score += 10;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if (other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //player.bulletObjectPool.Add(other.gameObject);

            PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject);
        }

        EnemyManager.Instance.enemyObjectPool.Add(gameObject);
        gameObject.SetActive(false);
    }
}
