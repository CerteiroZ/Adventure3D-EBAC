using Ebac.StateMachine;
using UnityEngine;

public class PlayerIdleStates : StateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        var animator = objs[0] as Animator;
        animator.SetTrigger("IDLE");
    }
}

public class PlayerRunStates : StateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        var animator = objs[0] as Animator;
        animator.SetTrigger("RUN");
    }
}

public class PlayerJumpStates : StateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        var animator = objs[0] as Animator;
        animator.SetTrigger("JUMP");
    }
}
