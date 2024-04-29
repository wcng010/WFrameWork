using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NotImplementedException = System.NotImplementedException;

namespace Wcng
{
    public class CombatEventCentreManager: Manager,IManager
    {
     
        private static readonly IDictionary<CombatEventType, UnityEvent> Events =
            new Dictionary<CombatEventType, UnityEvent>(); //Events字典装有若干个事件，一一对应事件类型，
        
        public void Subscribe(CombatEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent; //事件
            if (Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener); //向事件中添加函数
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        public void Unsubscribe(CombatEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;
            if (Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
                if (Events[eventType].GetPersistentEventCount() == 0)
                    Events.Remove(eventType);
            }
        }

        public void Publish(CombatEventType eventType)
        {
            UnityEvent thisEvent;
            if (Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
        
        //如果有事件就返回Ture,没有事件就返回False
        public bool PublishBool (CombatEventType eventType)
        {
            UnityEvent thisEvent;
            if (Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke();
                return true;
            }
            return false;
        }

        public override void OnManagerInit()
        {
            
        }

        public override void OnManagerDestroy()
        {
            
        }

        public override void OnManagerOpen()
        {
            
        }

        public override void OnManagerClose()
        {
           
        }
    }
}