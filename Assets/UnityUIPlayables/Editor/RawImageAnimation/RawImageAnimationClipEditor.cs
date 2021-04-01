using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(RawImageAnimationClip))]
    public class RawImageAnimationClipEditor : AnimationTimelineClipEditor<RawImageAnimationBehaviour>
    {
    }
}