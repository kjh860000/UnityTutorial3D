using System;
using System.Collections;
using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state = new IdleState();

    void Start()
    {
        state.StateEnter();
    }

    void OnDestroy()
    {
        state.StateExit();
    }

    void Update()
    {
        state?.StateUpdate();

        #region 기능 테스트

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(new IdleState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(new MoveState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(new AttackState());
        }

        #endregion
    }

    public void SetState(IState newState)
    {
        if (state != newState)
        {
            state.StateExit(); // 상태 변경 전

            state = newState; // 상태 변경

            state.StateEnter(); // 상태 변경 후
        }
    }
}
