﻿using System.Collections.Generic;
using Torch.Utils;
using Xunit;

namespace Torch.Tests
{
    public class TorchReflectionTest
    {
        static TorchReflectionTest()
        {
            TestUtils.Init();
        }

        private static ReflectionTestManager _manager;

        private static ReflectionTestManager Manager()
        {
            if (_manager != null)
                return _manager;

            return _manager = new ReflectionTestManager().Init(typeof(TorchBase).Assembly);
        }

        public static IEnumerable<object[]> Getters => Manager().Getters;

        public static IEnumerable<object[]> Setters => Manager().Setters;

        public static IEnumerable<object[]> Invokers => Manager().Invokers;

        #region Binding
        [Theory]
        [MemberData(nameof(Getters))]
        public void TestBindingGetter(ReflectionTestManager.FieldRef field)
        {
            if (field.Field == null)
                return;
            Assert.True(ReflectedManager.Process(field.Field));
            if (field.Field.IsStatic)
                Assert.NotNull(field.Field.GetValue(null));
        }

        [Theory]
        [MemberData(nameof(Setters))]
        public void TestBindingSetter(ReflectionTestManager.FieldRef field)
        {
            if (field.Field == null)
                return;
            Assert.True(ReflectedManager.Process(field.Field));
            if (field.Field.IsStatic)
                Assert.NotNull(field.Field.GetValue(null));
        }

        [Theory]
        [MemberData(nameof(Invokers))]
        public void TestBindingInvoker(ReflectionTestManager.FieldRef field)
        {
            if (field.Field == null)
                return;
            Assert.True(ReflectedManager.Process(field.Field));
            if (field.Field.IsStatic)
                Assert.NotNull(field.Field.GetValue(null));
        }
        #endregion
    }
}
