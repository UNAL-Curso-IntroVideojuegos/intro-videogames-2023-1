using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
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

        if (!_target) //_target == null
            _target = GameObject.FindWithTag("Player").transform;

        Bind(_config.FSMData);
        ToState(_config.InitialState);
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
        if(newState == _currentState)
            return;
        
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

    private void Bind(FSMData fsmData)
    {
        foreach (FSMStateData stateData in fsmData.States)
        {
            State state = State.CreateState(stateData.StateType);
            if(state == null)
                continue;

            foreach (FSMTransitionData transitionData in stateData.Transition)
            {
                state.AddTransition(transitionData.TargetState, transitionData.Decision);
            }
            
            _statesDic.Add(stateData.StateType, state);
        }
    }
}