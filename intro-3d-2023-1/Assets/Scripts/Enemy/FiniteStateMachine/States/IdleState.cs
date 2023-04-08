using System;
using UnityEngine;

namespace Enemy.FiniteStateMachine.States
{
    public class IdleState: State
    {
        public IdleState() : base("Idle")
        {
        }

        public override StateType Type { get; }
        protected override void OnEnterState(global::FiniteStateMachine fms)
        {
            Debug.Log("Idle State Enter");
        }

        protected override void OnUpdateState(global::FiniteStateMachine fms, float deltaTime)
        {
            Debug.Log("Idle State Update");
        }

        protected override void OnExitState(global::FiniteStateMachine fms)
        {
            Debug.Log("Idle State Exit");
        }
    }
}