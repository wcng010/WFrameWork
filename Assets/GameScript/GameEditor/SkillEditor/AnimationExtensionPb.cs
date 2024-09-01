using Animancer;
using Animancer.Editor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Wcng.SkillEditor
{
    public class AnimationExtensionPb : PlayableBehaviour
    {
        public AnimancerComponent Animancer => _animancer? _animancer: _animancer = GameObject.FindWithTag("Player").GetComponentInChildren<AnimancerComponent>();
        private AnimancerComponent _animancer;
        public ClipTransition AnimancerClip;
        private AvatarMask _actionMask;
        private AnimancerLayer BaseLayer => _animancer.Layers[0];
        private bool _canPlayActionFullBody;
        private bool _isPlay;
        private float _time;
        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if (Application.isEditor)
            {
                base.PrepareFrame(playable, info);
                Animancer.States.Current.Speed = 0;
                _time = (float)playable.GetTime();
                Animancer.States.Current.Time = _time;
                OnValidate();
            }
        }
        
        
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (Animancer.States.Current==null||Animancer.States.Current.Clip != AnimancerClip.Clip)
            {
                BaseLayer.Play(AnimancerClip);
            }
        }
        
        private void OnValidate()
        {
            AnimancerUtilities.EditModeSampleAnimation(AnimancerClip.Clip, Animancer, _time * AnimancerClip.Clip.length);
        }
    }
}