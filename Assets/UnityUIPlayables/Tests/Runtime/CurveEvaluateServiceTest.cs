using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UnityUIPlayables.Tests
{
    internal sealed class CurveEvaluateServiceTest
    {
        [Test]
        public void EvaluateRepeat_TimeIsZero_ReturnsZero()
        {
            var curve = Curve.CreateFromEasing(EaseType.Linear);
            var service = new CurveEvaluateService();
            
            var result = service.EvaluateRepeat(curve, 0.0f, 1.0f);
            
            Assert.That(result, Is.EqualTo(0));
        }
        
        [Test]
        public void EvaluateRepeat_TimeIsLoopDuration_ReturnsOne()
        {
            var curve = Curve.CreateFromEasing(EaseType.Linear);
            var service = new CurveEvaluateService();
            
            var result = service.EvaluateRepeat(curve, 1.0f, 1.0f);
            
            Assert.That(result, Is.EqualTo(1));
        }
        
        [Test]
        public void EvaluateRepeat_TimeIsLoopDurationPlusEpsilon_ReturnsEpsilon()
        {
            var curve = Curve.CreateFromEasing(EaseType.Linear);
            var service = new CurveEvaluateService();
            
            var result = service.EvaluateRepeat(curve, 1.0f + 0.0001f, 1.0f);
            
            Assert.That(Mathf.Abs(result - 0.0001f) < 0.0001f);
        }
        
        [Test]
        public void EvaluateRepeat_TimeIsDuration_ReturnsOne()
        {
            var curve = Curve.CreateFromEasing(EaseType.Linear);
            var service = new CurveEvaluateService();
            
            var result = service.EvaluateRepeat(curve, 3.0f, 1.0f);
            
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
