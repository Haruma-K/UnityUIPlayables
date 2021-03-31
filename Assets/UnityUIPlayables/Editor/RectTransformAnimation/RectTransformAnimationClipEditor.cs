using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(RectTransformAnimationClip))]
    public class RectTransformAnimationClipEditor : AnimationTimelineClipEditor<RectTransformAnimationBehaviour>
    {
    }
}