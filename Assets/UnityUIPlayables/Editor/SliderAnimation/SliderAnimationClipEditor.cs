using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(SliderAnimationClip))]
    public class SliderAnimationClipEditor : AnimationTimelineClipEditor<SliderAnimationBehaviour>
    {
    }
}