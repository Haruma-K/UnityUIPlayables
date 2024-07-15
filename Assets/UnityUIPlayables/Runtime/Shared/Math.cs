using UnityEngine;
using UnityEngine.Assertions;

namespace UnityUIPlayables
{
    internal static class Math
    {
        /// <summary>
        ///     The Mathf.Repeat function in Unity returns zero when it hits the boundary value.
        ///     This method returns the larger value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static float RepeatWithLargerBoundaryValue(float value, float length)
        {
            Assert.IsTrue(value >= 0);
            Assert.IsTrue(length > 0);

            if (value == 0.0f)
                return 0.0f;

            var result = Mathf.Repeat(value, length);
            return result == 0.0f ? length : result;
        }
    }
}