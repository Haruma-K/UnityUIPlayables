using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityUIPlayables
{
    [Serializable]
    public abstract class AnimationTimelineClip<TAnimationBehaviour> : PlayableAsset, ITimelineClipAsset
        where TAnimationBehaviour : AnimationBehaviour, new()
    {
        public TAnimationBehaviour template = new TAnimationBehaviour();

        public ClipCaps clipCaps => ClipCaps.Blending;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<TAnimationBehaviour>.Create(graph, template);
        }
    }
}