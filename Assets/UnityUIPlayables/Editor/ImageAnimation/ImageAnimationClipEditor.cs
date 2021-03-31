using UnityEditor.Timeline;

namespace UnityUIPlayables.Editor
{
    [CustomTimelineEditor(typeof(ImageAnimationClip))]
    public class ImageAnimationClipEditor : AnimationTimelineClipEditor<ImageAnimationBehaviour>
    {
    }
}