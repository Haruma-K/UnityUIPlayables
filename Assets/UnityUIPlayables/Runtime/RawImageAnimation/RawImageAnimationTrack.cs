using UnityEngine.Timeline;
using UnityEngine.UI;

namespace UnityUIPlayables
{
    [TrackColor(0.1098f, 0.3529f, 0.8392f)]
    [TrackClipType(typeof(RawImageAnimationClip))]
    [TrackBindingType(typeof(RawImage))]
    public class RawImageAnimationTrack
        : AnimationTrack<RawImage, RawImageAnimationMixer, RawImageAnimationMixerBehaviour, RawImageAnimationBehaviour>
    {
    }
}