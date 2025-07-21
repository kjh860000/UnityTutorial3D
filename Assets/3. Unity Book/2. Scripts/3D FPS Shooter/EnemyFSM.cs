using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    private EnemyState m_state;

    private Transform player;
    private CharacterController cc;

    private Animator anim;

    public float findDistance = 8f;
    public float attackDistance = 3f;
    public float moveSpeed = 5f;

    private float currentTime = 0f;
    private float attackDelay = 2f;

    public int attackPower = 3;
    public int hp = 50;
    private int maxHp = 50;
    public Slider hpSlider;

    private Vector3 originPos;
    public float moveDistance = 20f;

    private void Start()
    {
        m_state = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        anim = transform.GetComponentInChildren<Animator>();

        Cursor.visible = false;

    }

    private void Update()
    {
        switch (m_state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                Die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle()
    {
        if(Vector3.Distance(transform.position, player.position) < findDistance)
        {
            anim.SetTrigger("IdleToMove");
            m_state = EnemyState.Move;
            Debug.Log("상태 전환 : Idle >> Move");
        }
    }
    private void Move()
    {
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_state = EnemyState.Return;
            Debug.Log("상태 전환 : Move >> Return");
        }
        else if (Vector3.Distance(transform.position, player.position)>attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);

            transform.forward = dir;
        }
        else
        {
            currentTime = attackDelay;
            m_state = EnemyState.Attack;
            Debug.Log("상태 전환 : Move >> Attack");
        }
    }
    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position)<attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                currentTime = 0;
                player.GetComponent<FPSPlayerMove>().DamageAction(attackPower);
                Debug.Log("Attack");
            }
        }
        else
        {
            currentTime = 0f;
            m_state = EnemyState.Move;
            Debug.Log("상태 전환 : Attack >> Move");
        }
    }
    private void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        else
        {
            transform.position = originPos;
            hp = 15;
            anim.SetTrigger("MoveToIdle");
            m_state = EnemyState.Idle;
            Debug.Log("상태 전환 : Return >> Idle");
        }
    }
    public void HitEnemy(int hitPower)
    {
        if (m_state == EnemyState.Damaged || m_state == EnemyState.Die || m_state == EnemyState.Return)
            return;

        hp -= hitPower;

        if (hp > 0)
        {
            m_state = EnemyState.Damaged;
            Debug.Log("상태 전환 : Any State >> Damaged");

            Damaged();
        }
        else
        {
            m_state = EnemyState.Die;
            Debug.Log("상태 전환 : Any State >> Die");

            Die();
        }
    }
    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);
        m_state = EnemyState.Move;
        Debug.Log("상태 전환 : Damage >> Move");
    }
    private void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
