using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Mover el personaje por los wayPoints, necesita un index para saber por donde vamos
//Recuerda que no tenemos que guardar los waypoints en ningún sitio
//puesto que la clase GameEnvirontment (Singleton) ya lo hace
public class Patrol: State
{
    int completedLoops;
    int currentIndex = -1;
    public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PATROL;
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