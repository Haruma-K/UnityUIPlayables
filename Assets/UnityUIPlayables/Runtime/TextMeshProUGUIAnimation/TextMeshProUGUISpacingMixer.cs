using TMPro;
using UnityEngine;

namespace UnityUIPlayables
{
    public class TextMeshProUGUISpacingMixer
    {
        private float _blendedCharacter;
        private float _blendedLine;
        private float _blendedParagraph;
        private float _blendedWord;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedCharacter = 0.0f;
            _blendedLine = 0.0f;
            _blendedWord = 0.0f;
            _blendedParagraph = 0.0f;
            _totalWeight = 0.0f;
        }

        public void Blend(TextMeshProUGUIAnimationValue.SpacingValue startValue,
            TextMeshProUGUIAnimationValue.SpacingValue endValue, float inputWeight, float progress)
        {
            _blendedCharacter += Mathf.Lerp(startValue.Character, endValue.Character, progress) * inputWeight;
            _blendedLine += Mathf.Lerp(startValue.Line, endValue.Line, progress) * inputWeight;
            _blendedWord += Mathf.Lerp(startValue.Word, endValue.Word, progress) * inputWeight;
            _blendedParagraph += Mathf.Lerp(startValue.Paragraph, endValue.Paragraph, progress) * inputWeight;
            _totalWeight += inputWeight;
        }

        public void ApplyFrame(TextMeshProUGUI binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedCharacter += binding.characterSpacing * (1f - _totalWeight);
            _blendedLine += binding.lineSpacing * (1f - _totalWeight);
            _blendedWord += binding.wordSpacing * (1f - _totalWeight);
            _blendedParagraph += binding.paragraphSpacing * (1f - _totalWeight);
            binding.characterSpacing = _blendedCharacter;
            binding.lineSpacing = _blendedLine;
            binding.wordSpacing = _blendedWord;
            binding.paragraphSpacing = _blendedParagraph;
        }
    }
}