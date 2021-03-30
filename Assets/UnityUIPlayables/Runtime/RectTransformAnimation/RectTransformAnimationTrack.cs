using UnityEngine;
using UnityEngine.Timeline;

namespace UnityUIPlayables
{
    [TrackColor(0.1098f, 0.3529f, 0.8392f)]
    [TrackClipType(typeof(RectTransformAnimationClip))]
    [TrackBindingType(typeof(RectTransform))]
    public class RectTransformAnimationTrack
        : AnimationTrack<RectTransform, RectTransformAnimationMixer, RectTransformAnimationMixerBehaviour,
            RectTransformAnimationBehaviour>
    {
    }
}