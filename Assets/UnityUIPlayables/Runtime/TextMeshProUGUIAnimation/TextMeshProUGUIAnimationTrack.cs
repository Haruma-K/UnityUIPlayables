using TMPro;
using UnityEngine.Timeline;

namespace UnityUIPlayables
{
    [TrackColor(0.1098f, 0.3529f, 0.8392f)]
    [TrackClipType(typeof(TextMeshProUGUIAnimationClip))]
    [TrackBindingType(typeof(TextMeshProUGUI))]
    public class TextMeshProUGUIAnimationTrack
        : AnimationTrack<TextMeshProUGUI, TextMeshProUGUIAnimationMixer, TextMeshProUGUIAnimationMixerBehaviour,
            TextMeshProUGUIAnimationBehaviour>
    {
    }
}