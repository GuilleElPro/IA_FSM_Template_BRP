using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Attack : State
{
	//El NPC debe seguir al jugador y girar mirándolo.
    float rotationSpeed = 2.0f;
    AudioSource shoot;
    public Attack(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.ATTACK;
        //Fuente de audio que lleva adjunta el NPC (Ugg)
        shoot = _npc.GetComponent<AudioSource>();
		//Podriamos hacerlo en la clase State en vez de cargarlo cada vez
        //que se ataca, pero aqui lo hemos hecho asi.
    }
	
    public override void Enter()
    {
        //TODO
        anim.SetTrigger("isShooting");

        if (shoot != null)
            shoot.Play();

        base.Enter();
    }
	
    public override void Update()
    {
        //TODO
        // Calculamos la dirección hacia el jugador
        Vector3 direction = player.position - npc.transform.position;
        direction.y = 0;

        // Giramos el NPC para que mire al jugador
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);

            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,rotation,rotationSpeed * Time.deltaTime);
        }

        // Seguimos al jugador
        agent.SetDestination(player.position);

        // Si el jugador se aleja, volvemos a perseguirlo
        if (!CanAttackPlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
            return;
        }

       
    }
    public override void Exit()
    {
        //TODO
        anim.ResetTrigger("isShooting");
        if(shoot != null)
            shoot.Stop();
        base.Exit();
    }
}
