using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Idle : State //Clase Idle que hereda de State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    //Debemos ahora crear las 3 funciones (public override) para las etapas de Enter, Update y Exit de esta clase/estado
    public override void Enter()
    {
        //TODO
        anim.SetTrigger("isIdle"); //Activamos la animacion Idle
        base.Enter(); //Aqui ya se hace stage = EVENT.UPDATE;, no necesitamos hacerlo aqui
    }

    //Update se ejecuta una y otra vez y necesita un evento que le haga salir (que rompa la secuencia)
    public override void Update()
    {
        //TODO
        for(float time=0; time <= 10f; time += Time.deltaTime)
        if (time >= 10f)
        {
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        //TODO
        anim.ResetTrigger("isIdle"); //Desactivamos la animacion Idle
        base.Exit();
    }
}
