using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(TextAnimationClip))]
    public class TextAnimationClipEditor : AnimationTimelineClipEditor<TextAnimationBehaviour>
    {
    }
}