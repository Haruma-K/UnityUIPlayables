using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(TextMeshProUGUIAnimationClip))]
    public class TextMeshProUGUIAnimationClipEditor : AnimationTimelineClipEditor<TextMeshProUGUIAnimationBehaviour>
    {
    }
}