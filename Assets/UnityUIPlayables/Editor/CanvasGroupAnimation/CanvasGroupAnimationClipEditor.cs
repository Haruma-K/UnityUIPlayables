using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(CanvasGroupAnimationClip))]
    public class CanvasGroupAnimationClipEditor : AnimationTimelineClipEditor<CanvasGroupAnimationBehaviour>
    {
    }
}