using UnityEngine.Timeline;
using UnityEngine.UI;

namespace UnityUIPlayables
{
    [TrackColor(0.1098f, 0.3529f, 0.8392f)]
    [TrackClipType(typeof(TextAnimationClip))]
    [TrackBindingType(typeof(Text))]
    public class TextAnimationTrack
        : AnimationTrack<Text, TextAnimationMixer, TextAnimationMixerBehaviour, TextAnimationBehaviour>
    {
    }
}