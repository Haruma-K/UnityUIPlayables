using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityUIPlayables
{
    public abstract class
        AnimationTrack<TBinding, TValueMixer, TAnimationMixerBehaviour, TAnimationBehaviour> : TrackAsset
        where TAnimationMixerBehaviour : AnimationMixerBehaviour<TBinding, TValueMixer, TAnimationBehaviour>, new()
        where TValueMixer : AnimationMixer<TBinding, TAnimationBehaviour>, new()
        where TBinding : Component
        where TAnimationBehaviour : AnimationBehaviour, new()
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<TAnimationMixerBehaviour>.Create(graph, inputCount);
        }

        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            var component = director.GetGenericBinding(this) as TBinding;
            if (component == null)
            {
                return;
            }

            var so = new SerializedObject(component);
            var iterator = so.GetIterator();
            while (iterator.NextVisible(true))
            {
                if (iterator.hasVisibleChildren)
                {
                    continue;
                }

                driver.AddFromName<TBinding>(component.gameObject, iterator.propertyPath);
            }
#endif
            base.GatherProperties(director, driver);
        }
    }
}