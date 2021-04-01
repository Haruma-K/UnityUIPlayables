using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;

namespace UnityUIPlayables.Editor
{
    public class AnimationTimelineClipEditor<TAnimationBehaviour> : ClipEditor
        where TAnimationBehaviour : AnimationBehaviour, new()
    {
        private Texture2D _pointTexture;

        public override void OnCreate(TimelineClip clip, TrackAsset track, TimelineClip clonedFrom)
        {
        }

        public override void OnClipChanged(TimelineClip clip)
        {
        }

        public override void DrawBackground(TimelineClip clip, ClipBackgroundRegion region)
        {
            var animationTimelineClip = (AnimationTimelineClip<TAnimationBehaviour>) clip.asset;
            var duration = clip.duration;
            var behaviour = animationTimelineClip.template;
            var loopDuration = behaviour.LoopDuration;
            if (loopDuration <= 0.0f)
            {
                return;
            }

            if (_pointTexture == null)
            {
                _pointTexture = Resources.Load<Texture2D>("tex_unityuiplayables_icon_diamond");
            }

            var time = 0.0f;
            var position = region.position;
            position.width = 12;
            position.height = 12;
            position.y += position.height / 2;
            var lengthPerLoop = (float) (region.position.width * loopDuration / duration);
            while (true)
            {
                time += loopDuration;
                if (time < duration)
                {
                    position.x += lengthPerLoop;
                    GUI.DrawTexture(position, _pointTexture, ScaleMode.ScaleToFit, true, 1, Color.grey, Vector4.zero,
                        Vector4.zero);
                }
                else
                {
                    break;
                }
            }
        }
    }
}