using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] private StateType _initialState;
    
    [Space(10)]
    [SerializeField] private Animator _anim;
    
    [Space(10)]
    [SerializeField] private Transform _target;

    public Transform Target => _target;
    public NavMeshController NavMeshController => _navMeshController;
    public EnemyConfig Config => _config;

    
    private NavMeshController _navMeshController;
    private EnemyConfig _config;
    private Dictionary<StateType, State> _statesDic = new();
    private StateType _currentState;
    private float _currentSpeed = 1;

    void Start()
    {
        _navMeshController = GetComponent<NavMeshController>();
        _config = GetComponent<EnemyConfig>();
        
        _statesDic.Add(StateType.Patrol, new PatrolState());
        _statesDic.Add(StateType.Chase, new ChaseState());
        _statesDic.Add(StateType.Attack, new AttackState());

        ToState(_initialState);
    }
    
    void Update()
    {
        if (_statesDic.ContainsKey(_currentState))
        {
            _statesDic[_currentState].OnUpdate(this, Time.deltaTime);
            _statesDic[_currentState].CheckTransition(this, Time.deltaTime);
        }
        
        if (_anim)
        {
            _anim.SetBool("IsWalking", _navMeshController.IsMoving);
            _anim.SetFloat("WalkSpeed", 1);
        }
    }

    public void TriggerAnimation(string animation)
    {
        _anim.SetTrigger(animation);
    }

    public void SetMovementSpeed(float speed)
    {
        _currentSpeed = speed;
        _navMeshController.SetSpeed(_currentSpeed);
    }
    
    public void ToState(StateType newState)
    {
        if (_statesDic.ContainsKey(_currentState))
        {
            _statesDic[_currentState].OnExit(this);
        }
        
        _currentState = newState;

        if (_statesDic.ContainsKey(_currentState))
        {
            _statesDic[_currentState].OnEnter(this);
        }
    }
}