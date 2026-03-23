using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pursue: State
{
    public Pursue(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PURSUE;
        //TODO
    }
    public override void Enter()
    {
        //TODO
        base.Enter();
    }
    public override void Update()
    {
       //TODO
        stage = EVENT.EXIT;
    }

    public override void Exit()
    {
        //TODO
        base.Exit();
    }

}
