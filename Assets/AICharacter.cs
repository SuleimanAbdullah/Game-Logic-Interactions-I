using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class AICharacter : MonoBehaviour
{
    [SerializeField]
    private Transform[] _wayPoints;
    private NavMeshAgent _agent;

    private int _currentWaypoint = 0;
    private bool _isReverse;
    private bool _isAttacking = false;

    private enum AIState
    {
        Walking,
        Jumping,
        Attacking,
        Death
    }

    [SerializeField]
    private AIState _currentState;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (_agent != null)
        {
            _agent.destination = _wayPoints[_currentWaypoint].position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentState = AIState.Attacking;
        }

        switch (_currentState)
        {
            case AIState.Walking:
                CalculateAIMovement();
                break;
            case AIState.Jumping:

                StartCoroutine(AttackRoutine());
                break;
            case AIState.Attacking:
                if (_isAttacking == false)
                {
                    Debug.Log("Current State :" + _currentState);
                    StartCoroutine(AttackRoutine());
                }
                break;
            case AIState.Death:
                break;
        }
    }

    void Forward()
    {
        if (_currentWaypoint == _wayPoints.Length - 1)
        {
            _isReverse = true;
            _currentWaypoint--;
        }
        else
        {
            _currentWaypoint++;
        }
    }

    void Reverse()
    {
        if (_currentWaypoint == 0)
        {
            _isReverse = false;
            _currentWaypoint++;
        }
        else
        {
            _currentWaypoint--;
        }
    }

    void CalculateAIMovement()
    {
        if (_agent.remainingDistance < 1)
        {
            if (_isReverse == true)
            {
                Reverse();
            }

            else
            {
                Forward();
            }

            _agent.SetDestination(_wayPoints[_currentWaypoint].position);
        }
    }

    IEnumerator AttackRoutine()
    {
        _isAttacking = true;
        _agent.isStopped = true;
        _currentState = AIState.Attacking;
        yield return new WaitForSeconds(3f);
        _isAttacking = false;
        _agent.isStopped = false;
        _currentState = AIState.Walking;
    }
}
