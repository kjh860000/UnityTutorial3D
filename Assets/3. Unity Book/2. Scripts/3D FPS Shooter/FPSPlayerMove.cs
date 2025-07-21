using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 7f;
    public float gravity = -20f;
    private float yVelocity = 0;

    public float jumpPower = 10f;
    public bool isJumping = false;

    public int hp = 50;

    private int maxHp = 50;
    public Slider hpSlider;

    public GameObject hitEffect;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return; float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3 (h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0;

        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            yVelocity = jumpPower;
        }
    }

    public void DamageAction(int damage)
    {
        hp -= damage;
        hpSlider.value = (float)hp / (float)maxHp;

        if(hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        hitEffect.SetActive(false);
    }
}
