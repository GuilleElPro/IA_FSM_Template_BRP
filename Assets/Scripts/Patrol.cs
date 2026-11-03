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
       completedLoops = 0;
    }

    public override void Enter()
    {
        //TODO
        // Empezamos la patrulla
        currentIndex = 0;

        anim.SetTrigger("isWalking");

        // Indicamos el primer destino
        if (GameEnvironment.Singleton.Checkpoints.Count > 0)
        {
            agent.SetDestination(GameEnvironment.Singleton.Checkpoints[currentIndex].transform.position);
        }
        base.Enter();
    }
    public override void Update()
    {
        //TODO
        if (GameEnvironment.Singleton.Checkpoints.Count == 0)
            return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Pasamos al siguiente waypoint
            currentIndex++;

            // Si hemos llegado al final de la lista
            if (currentIndex >= GameEnvironment.Singleton.Checkpoints.Count)
            {
                currentIndex = 0;
                completedLoops++;
            }

            // Establecemos el siguiente destino
            agent.SetDestination(
                GameEnvironment.Singleton.Checkpoints[currentIndex].transform.position
            );
        }

        // Si vemos al jugador, cambiamos al estado de persecución
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
            return;
        }

        if (completedLoops >= 2)
        {
            nextState = new Idle(npc, agent, anim, player);
            stage = EVENT.EXIT;
            return;
        }

    }

    public override void Exit()
    {
        //TODO
        agent.ResetPath();
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}