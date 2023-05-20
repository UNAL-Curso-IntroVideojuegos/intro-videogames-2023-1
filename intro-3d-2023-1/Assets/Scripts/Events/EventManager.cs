using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IEvent { }

public class EnemyDeathEvent : IEvent
{
    public Enemy EnemyDeath;
    public int Points;
}

public class EventManager : Singleton<EventManager>
{
    private Queue eventQueue = new Queue();
    private bool limitQueueProcesing = false;
    private float queueProcessTime = 0;

    
    private Dictionary<Type, EventDelegate> delegates = new Dictionary<Type, EventDelegate>();
    private Dictionary<Delegate, EventDelegate> delegateLookup = new Dictionary<Delegate, EventDelegate>();

    public delegate void EventDelegate<T>(T e) where T : IEvent;
    private delegate void EventDelegate(IEvent e);

    public void AddListener<T>(EventDelegate<T> del) where T : IEvent
    {
        AddDelegate<T>(del);
    }

    public void RemoveListener<T>(EventDelegate<T> del) where T : IEvent
    {
        EventDelegate internalDelegate;

        if (delegateLookup.TryGetValue(del, out internalDelegate)) {
            EventDelegate tempDel;

            if (delegates.TryGetValue(typeof(T), out tempDel)) {
                tempDel -= internalDelegate;

                if (tempDel == null){
                    delegates.Remove(typeof(T));
                } else {
                    delegates[typeof(T)] = tempDel;
                }
            }

            delegateLookup.Remove(del);
        }
    }

    public bool HasListener<T>(EventDelegate<T> del) where T : IEvent
    {
        return delegateLookup.ContainsKey(del);
    }

    public void Dispatch(IEvent e)
    {
        EventDelegate del;

        if (delegates.TryGetValue(e.GetType(), out del)) {
            del.Invoke(e);
            
            foreach (EventDelegate k in delegates[e.GetType()].GetInvocationList()) {
                delegates[e.GetType()] -= k;

                if (delegates[e.GetType()] == null) {
                    delegates.Remove(e.GetType());
                }
            }
        } else {
            Debug.Log($"Event '{e.GetType()}' has no listeners...");
        }
    }

    private EventDelegate AddDelegate<T>(EventDelegate<T> del) where T : IEvent
    {
        if (delegateLookup.ContainsKey(del)) {
            return null;
        }

        EventDelegate tempDel;
        EventDelegate internalDelegate = (e) => del((T) e);

        delegateLookup[del] = internalDelegate;

        if (delegates.TryGetValue(typeof(T), out tempDel)) {
            delegates[typeof(T)] = tempDel += internalDelegate;
        } else {
            delegates[typeof(T)] = internalDelegate;
        }

        return internalDelegate;
    }
}