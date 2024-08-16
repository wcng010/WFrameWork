using Animancer;
using UnityEngine;
using UnityEngine.Playables;

namespace Wcng.SkillEditor
{
    public class AnimationExtensionMixerPb: PlayableBehaviour
    {
        public AnimancerComponent animancer => _animancer? _animancer: _animancer = GameObject.FindWithTag("Player").GetComponentInChildren<AnimancerComponent>();
        private AnimancerComponent _animancer;
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            int inputCount = playable.GetInputCount();
            for (int i = 0; i < inputCount; i++)
            {
                var tempPlay = playable.GetInput(i);
                ScriptPlayable<AnimationExtensionPb> tempPlayable = (ScriptPlayable<AnimationExtensionPb>)tempPlay;
                var mixBehaviour = tempPlayable.GetBehaviour();
                float weight = playable.GetInputWeight(0); 
                Debug.Log(weight);
                //animancer.States.Current.Weight = weight;
            }
        }
    }
}