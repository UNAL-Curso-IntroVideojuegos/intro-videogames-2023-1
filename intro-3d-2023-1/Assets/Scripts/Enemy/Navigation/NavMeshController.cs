using System;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] private Transform[] _waypointObjects;
    [SerializeField] [HideInInspector] private Vector3[] _waypoints;
    
    private Transform _target;  
    
    private int _currentWaypoint;
    private NavMeshAgent _agent;

    public bool IsMoving => _agent != null && _agent.velocity.magnitude > 0.1f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start(){
        _currentWaypoint = 0;  

        _waypoints = new Vector3[_waypointObjects.Length];
        for (int i = 0; i < _waypointObjects.Length; i++)
        {
            _waypoints[i] = _waypointObjects[i].position;
            _waypointObjects[i].gameObject.SetActive(false);
        }
    }

    public void SetTarget(Transform target) => _target = target;

    public void SetSpeed(float speed) => _agent.speed = speed;
    
    public void GoToNextWaypoint(){  
        _agent.SetDestination(_waypoints[_currentWaypoint]);  
        _currentWaypoint++;  
        if (_currentWaypoint >= _waypoints.Length)  
            _currentWaypoint = 0;  
    }
    
    public void GoToTarget(){  
        _agent.SetDestination(_target.position);
        _agent.isStopped = false;
    }
    
    public void StopAgent(){  
        _agent.isStopped = true;
        _agent.velocity = Vector3.zero;
        _agent.ResetPath();  
    }
    
    public bool IsAtDestination()
    {
        if (_agent.pathPending)
            return false;

        if (_agent.remainingDistance > _agent.stoppingDistance)
            return false;

        return !_agent.hasPath || _agent.velocity.sqrMagnitude == 0f;
    }

    private void OnValidate()
    {
        _waypoints = new Vector3[_waypointObjects.Length];
        for (int i = 0; i < _waypointObjects.Length; i++)
        {
            _waypoints[i] = _waypointObjects[i].position;
        }
    }
}