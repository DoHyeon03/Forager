using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum ENEMYSTATE
    {
        IDLE=0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }

    public ENEMYSTATE enemyState;

    public float moveSpeed;
    public bool playerTriggerOn;

    public NavMeshAgent navMeshAgent;


    void Start()
    {

    }


    void Update()
    {
        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                navMeshAgent.speed = 0;

                if (playerTriggerOn)
                {
                    enemyState = ENEMYSTATE.MOVE;
                }
                break;
            case ENEMYSTATE.MOVE:

                break;
            case ENEMYSTATE.ATTACK:
                break;
            case ENEMYSTATE.DAMAGE:
                break;
            case ENEMYSTATE.DEAD:
                break;
            default:
                break;
        }
    }
}
