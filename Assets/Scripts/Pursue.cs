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
        anim.SetTrigger("isRunning");
        base.Enter();
    }
    public override void Update()
    {
       //TODO
       
        agent.SetDestination(player.position);
        
        if (!CanSeePlayer())
        {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
            return;
        }

        if (CanAttackPlayer())
        {
            nextState = new Attack(npc, agent, anim, player);
            stage = EVENT.EXIT;
            return;
        }

        
    }

    public override void Exit()
    {
        //TODO
        agent.ResetPath();
        anim.SetTrigger("isRunning");

        base.Exit();
    }

}
