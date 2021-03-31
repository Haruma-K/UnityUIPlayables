using System.IO;
using Development.CodeGeneration.Editor.Templates;
using UnityEditor;
using UnityEngine;

namespace UnityUIPlayables.Editor
{
    public class ScriptGenerationWindow : ScriptableWizard
    {
        private const string BaseFolderPath = "Assets/UnityUIPlayables";
        
        [SerializeField] private string _bindingName;
        
        [MenuItem("UnityUIPlayables/Development/Script Generation Window")]
        private static void Open()
        {
            DisplayWizard<ScriptGenerationWindow>(ObjectNames.NicifyVariableName(nameof(ScriptGenerationWindow)));
        }

        private void OnWizardCreate()
        {
            if (string.IsNullOrEmpty(_bindingName))
            {
                return;
            }
            
            var folderName = _bindingName + "Animation";
            var runtimeFolderPath = $"{BaseFolderPath}/Runtime/{folderName}";
            var editorFolderPath = $"{BaseFolderPath}/Editor/{folderName}";

            if (!Directory.Exists(runtimeFolderPath))
            {
                Directory.CreateDirectory(runtimeFolderPath);
            }
            
            if (!Directory.Exists(editorFolderPath))
            {
                Directory.CreateDirectory(editorFolderPath);
            }

            var animationBehaviourFilePath = $"{runtimeFolderPath}/{_bindingName}AnimationBehaviour.cs";
            var animationBehaviourContents = new AnimationBehaviourTemplate(_bindingName).TransformText();
            File.WriteAllText(animationBehaviourFilePath, animationBehaviourContents);

            var animationMixerBehaviourFilePath = $"{runtimeFolderPath}/{_bindingName}AnimationMixerBehaviour.cs";
            var animationMixerBehaviourContents = new AnimationMixerBehaviourTemplate(_bindingName).TransformText();
            File.WriteAllText(animationMixerBehaviourFilePath, animationMixerBehaviourContents);

            var animationMixerFilePath = $"{runtimeFolderPath}/{_bindingName}AnimationMixer.cs";
            var animationMixerContents = new AnimationMixerTemplate(_bindingName).TransformText();
            File.WriteAllText(animationMixerFilePath, animationMixerContents);

            var animationTimelineClipFilePath = $"{runtimeFolderPath}/{_bindingName}AnimationClip.cs";
            var animationTimelineClipContents = new AnimationTimelineClipTemplate(_bindingName).TransformText();
            File.WriteAllText(animationTimelineClipFilePath, animationTimelineClipContents);

            var animationTrackFilePath = $"{runtimeFolderPath}/{_bindingName}AnimationTrack.cs";
            var animationTrackContents = new AnimationTrackTemplate(_bindingName).TransformText();
            File.WriteAllText(animationTrackFilePath, animationTrackContents);

            var animationValueFilePath = $"{runtimeFolderPath}/{_bindingName}AnimationValue.cs";
            var animationValueContents = new AnimationValueTemplate(_bindingName).TransformText();
            File.WriteAllText(animationValueFilePath, animationValueContents);

            var animationBehaviourDrawerFilePath = $"{editorFolderPath}/{_bindingName}AnimationBehaviourDrawer.cs";
            var animationBehaviourDrawerContents = new AnimationBehaviourDrawerTemplate(_bindingName).TransformText();
            File.WriteAllText(animationBehaviourDrawerFilePath, animationBehaviourDrawerContents);

            var animationClipEditorFilePath = $"{editorFolderPath}/{_bindingName}AnimationClipEditor.cs";
            var animationClipEditorContents = new AnimationClipEditorTemplate(_bindingName).TransformText();
            File.WriteAllText(animationClipEditorFilePath, animationClipEditorContents);
            
            AssetDatabase.Refresh();
        }
    }
}
