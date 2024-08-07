using System.Collections.Generic;
using Animancer;
using GameScript.GameMain.Component;
using UnityEngine;
using UnityEngine.Playables;

namespace Wcng.FSM
{
    public class CharacterStateMachine : StateMachine<CharacterState>
    {
        public CharacterStateMachine()
        {
            
        }

        public CharacterStateMachine(List<IComponent> components,AnimancerComponent animancer,PlayableDirector playableDirector)
        {
            Components = components;
            AnimancerComponent = animancer;
            PlayableDirector = playableDirector;
        }
    }
}
