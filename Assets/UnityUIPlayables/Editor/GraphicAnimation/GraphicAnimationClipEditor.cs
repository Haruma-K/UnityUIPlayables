using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(GraphicAnimationClip))]
    public class GraphicAnimationClipEditor : AnimationTimelineClipEditor<GraphicAnimationBehaviour>
    {
    }
}