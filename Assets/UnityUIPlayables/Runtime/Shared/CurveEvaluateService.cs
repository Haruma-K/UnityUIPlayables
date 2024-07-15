using UnityEngine;
using UnityEngine.Assertions;

namespace UnityUIPlayables
{
    internal sealed class CurveEvaluateService
    {
        internal float EvaluateRepeat(Curve curve, float time, float loopDuration)
        {
            Assert.IsNotNull(curve);
            Assert.IsTrue(time >= 0);
            Assert.IsTrue(loopDuration > 0);

            var progress = time / loopDuration;
            var repeatedProgress = Math.RepeatWithLargerBoundaryValue(progress, 1.0f);
            var evaluatedProgress = curve.Evaluate(repeatedProgress);
            return evaluatedProgress;
        }

        internal float EvaluateReverse(Curve curve, float time, float loopDuration)
        {
            Assert.IsNotNull(curve);
            Assert.IsTrue(time >= 0);
            Assert.IsTrue(loopDuration > 0);

            var progress = time / loopDuration;
            var reverse = Mathf.Floor(progress) % 2 != 0;
            var repeatedProgress = Math.RepeatWithLargerBoundaryValue(progress, 1.0f);
            var evaluatedProgress = curve.Evaluate(repeatedProgress);
            if (reverse)
                evaluatedProgress = 1 - evaluatedProgress;
            return evaluatedProgress;
        }

        internal float EvaluatePingPong(Curve curve, float time, float loopDuration)
        {
            Assert.IsNotNull(curve);
            Assert.IsTrue(time >= 0);
            Assert.IsTrue(loopDuration > 0);

            var progress = time / loopDuration;
            var repeatedProgress = Mathf.PingPong(progress, 1.0f);
            var evaluatedProgress = curve.Evaluate(repeatedProgress);
            return evaluatedProgress;
        }
    }
}