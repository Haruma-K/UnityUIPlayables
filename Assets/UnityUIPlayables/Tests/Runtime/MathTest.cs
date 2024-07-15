using System;
using NUnit.Framework;
using UnityEngine;

namespace UnityUIPlayables.Tests
{
    internal sealed class MathTest
    {
        [Test]
        public void RepeatWithLargerBoundaryValue_WhenValueIsZero_ReturnsZero()
        {
            var result = Math.RepeatWithLargerBoundaryValue(0, 1);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void RepeatWithLargerBoundaryValue_WhenValueIsLength_ReturnsOne()
        {
            var result = Math.RepeatWithLargerBoundaryValue(1, 1);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void RepeatWithLargerBoundaryValue_WhenValueIsLengthPlusEpsilon_ReturnsEpsilon()
        {
            var result = Math.RepeatWithLargerBoundaryValue(1.0f + 0.0001f, 1);
            Assert.That(Mathf.Abs(result - 0.0001f) < 0.0001f);
        }

        [Test]
        public void RepeatWithLargerBoundaryValue_WhenValueIsLengthTimesTwo_ReturnsOne()
        {
            var result = Math.RepeatWithLargerBoundaryValue(2, 1);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void RepeatWithLargerBoundaryValue_WhenValueIsNegative_Throws()
        {
            Assert.That(() => Math.RepeatWithLargerBoundaryValue(-1, 1), Throws.InstanceOf<Exception>());
        }
    }
}