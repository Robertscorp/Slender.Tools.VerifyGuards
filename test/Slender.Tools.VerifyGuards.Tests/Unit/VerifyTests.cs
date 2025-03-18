﻿using Slender.Tools.VerifyGuards.Tests.Support;

namespace Slender.Tools.VerifyGuards.Tests.Unit
{

    public class VerifyTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly TestClass3 m_TestClass3 = new(1);

        #endregion Fields

        #region - - - - - - Guards (Instance From Different Sources) Tests - - - - - -

        [Fact]
        public void Guards_InstanceFromConstructor_DoesNotThrowException()
            => Verify.Guards(() => new TestClass3(1).TestMethod(Is.NotNullable<int>()));

        [Fact]
        public void Guards_InstanceFromField_DoesNotThrowException()
            => Verify.Guards(() => this.m_TestClass3.TestMethod(Is.NotNullable<int>()));

        [Fact]
        public void Guards_InstanceFromParameter_DoesNotThrowException()
            => this.Guards_InstanceFromParameter_DoesNotThrowException_SupportMethod(this.m_TestClass3);

        private void Guards_InstanceFromParameter_DoesNotThrowException_SupportMethod(TestClass3 testClass3)
            => Verify.Guards(() => testClass3.TestMethod(Is.NotNullable<int>()));

        [Fact]
        public void Guards_InstanceFromVariable_DoesNotThrowException()
        {
            var _TestClass3 = this.m_TestClass3;
            Verify.Guards(() => _TestClass3.TestMethod(Is.NotNullable<int>()));
        }

        #endregion Guards (Instance From Different Sources) Tests

        #region - - - - - - Guards (Not Nullable Constructor) Tests - - - - - -

        [Fact]
        public void Guards_NotNullableConstructor_AllParamsDeclaredAsNotNullable_DoesNotThrowException()
            => Verify.Guards(()
                => new TestClass(
                    Is.NotNullable<string>(),
                    Is.NotNullable<int>(),
                    Is.NotNullable<TestClass2>(),
                    Is.NotNullable<ITestInterface>()));

        [Fact]
        public void Guards_NotNullableConstructor_StringParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.Nullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableConstructor_IntParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.NotNullable<string>(),
                        Is.Nullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableConstructor_TestClass2ParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableConstructor_ITestInterfaceParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        #endregion Guards (Not Nullable Constructor) Tests

        #region - - - - - - Guards (Not Nullable Instance Action) Tests - - - - - -

        [Fact]
        public void Guards_NotNullableInstanceAction_AllParamsDeclaredAsNotNullable_DoesNotThrowException()
            => Verify.Guards((TestClass tc)
                => tc.InstanceActionNotNullableParams(
                    Is.NotNullable<string>(),
                    Is.NotNullable<int>(),
                    Is.NotNullable<TestClass2>(),
                    Is.NotNullable<ITestInterface>()));

        [Fact]
        public void Guards_NotNullableInstanceAction_StringParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNotNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableInstanceAction_IntParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableInstanceAction_TestClass2ParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableInstanceAction_ITestInterfaceParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        #endregion Guards (Not Nullable Instance Action) Tests

        #region - - - - - - Guards (Not Nullable Instance Function) Tests - - - - - -

        [Fact]
        public void Guards_NotNullableInstanceFunction_AllParamsDeclaredAsNotNullable_DoesNotThrowException()
            => Verify.Guards((TestClass tc)
                => tc.InstanceFuncNotNullableParams(
                    Is.NotNullable<string>(),
                    Is.NotNullable<int>(),
                    Is.NotNullable<TestClass2>(),
                    Is.NotNullable<ITestInterface>()));

        [Fact]
        public void Guards_NotNullableInstanceFunction_StringParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNotNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableInstanceFunction_IntParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableInstanceFunction_TestClass2ParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableInstanceFunction_ITestInterfaceParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        #endregion Guards (Not Nullable Instance Function) Tests

        #region - - - - - - Guards (Not Nullable Null Value Type) Tests - - - - - -

        [Fact]
        public void Guards_NullableValueTypeParam_NullableIntNotNullParam_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.NullableValueTypeParam(Is.NotNullable<int?>()))));

        #endregion Guards (Not Nullable Null Value Type) Tests

        #region - - - - - - Guards (Not Nullable Static Action) Tests - - - - - -

        [Fact]
        public void Guards_NotNullableStaticAction_AllParamsDeclaredAsNotNullable_DoesNotThrowException()
            => Verify.Guards(()
                => TestClass.StaticActionNotNullableParams(
                    Is.NotNullable<string>(),
                    Is.NotNullable<int>(),
                    Is.NotNullable<TestClass2>(),
                    Is.NotNullable<ITestInterface>()));

        [Fact]
        public void Guards_NotNullableStaticAction_StringParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableStaticAction_IntParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableStaticAction_TestClass2ParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableStaticAction_ITestInterfaceParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        #endregion Guards (Not Nullable Static Action) Tests

        #region - - - - - - Guards (Not Nullable Static Function) Tests - - - - - -

        [Fact]
        public void Guards_NotNullableStaticFunction_AllParamsDeclaredAsNotNullable_DoesNotThrowException()
            => Verify.Guards(()
                => TestClass.StaticActionNotNullableParams(
                    Is.NotNullable<string>(),
                    Is.NotNullable<int>(),
                    Is.NotNullable<TestClass2>(),
                    Is.NotNullable<ITestInterface>()));

        [Fact]
        public void Guards_NotNullableStaticFunction_StringParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableStaticFunction_IntParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableStaticFunction_TestClass2ParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_NotNullableStaticFunction_ITestInterfaceParamDeclaredAsNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNotNullableParams(
                        Is.NotNullable<string>(),
                        Is.NotNullable<int>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        #endregion Guards (Not Nullable Static Function) Tests

        #region - - - - - - Guards (Nullable Constructor) Tests - - - - - -

        [Fact]
        public void Guards_NullableConstructor_AllParamsDeclaredAsNullable_DoesNotThrowException()
            => Verify.Guards(()
                => new TestClass(
                    Is.Nullable<string>(),
                    Is.Nullable<int?>(),
                    Is.Nullable<TestClass2>(),
                    Is.Nullable<ITestInterface>()));

        [Fact]
        public void Guards_NullableConstructor_StringParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.NotNullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableConstructor_IntParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.Nullable<string>(),
                        Is.NotNullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableConstructor_TestClass2ParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableConstructor_ITestInterfaceParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => new TestClass(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        #endregion Guards (Nullable Constructor) Tests

        #region - - - - - - Guards (Nullable Instance Action) Tests - - - - - -

        [Fact]
        public void Guards_NullableInstanceAction_AllParamsDeclaredAsNullable_DoesNotThrowException()
            => Verify.Guards((TestClass tc)
                => tc.InstanceActionNullableParams(
                    Is.Nullable<string>(),
                    Is.Nullable<int?>(),
                    Is.Nullable<TestClass2>(),
                    Is.Nullable<ITestInterface>()));

        [Fact]
        public void Guards_NullableInstanceAction_StringParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableInstanceAction_IntParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableInstanceAction_TestClass2ParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableInstanceAction_ITestInterfaceParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceActionNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        #endregion Guards (Nullable Instance Action) Tests

        #region - - - - - - Guards (Nullable Instance Function) Tests - - - - - -

        [Fact]
        public void Guards_NullableInstanceFunction_AllParamsDeclaredAsNullable_DoesNotThrowException()
            => Verify.Guards((TestClass tc)
                => tc.InstanceFuncNullableParams(
                    Is.Nullable<string>(),
                    Is.Nullable<int?>(),
                    Is.Nullable<TestClass2>(),
                    Is.Nullable<ITestInterface>()));

        [Fact]
        public void Guards_NullableInstanceFunction_StringParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableInstanceFunction_IntParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableInstanceFunction_TestClass2ParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableInstanceFunction_ITestInterfaceParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards((TestClass tc)
                    => tc.InstanceFuncNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        #endregion Guards (Nullable Instance Function) Tests

        #region - - - - - - Guards (Invalid Expression) Tests - - - - - -

        [Fact]
        public void Guards_InvalidExpression1_ThrowsGuardException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(() => new int())));

        [Fact]
        public void Guards_InvalidExpression2_ThrowsGuardException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(() => 10 + 10)));

        [Fact]
        public void Guards_InvalidExpression3_ThrowsGuardException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(() => (int)TestClass.NoParameters())));

        [Fact]
        public void Guards_InvalidExpression4_ThrowsGuardException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(() => (decimal)10)));

        [Fact]
        public void Guards_InvalidExpression5_ThrowsGuardException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(() => string.Empty)));

        [Fact]
        public void Guards_InvalidExpression6_ThrowsGuardException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(() => TestClass.StaticActionNotNullableParams(string.Empty, 1, default!, Is.NotNullable<ITestInterface>()))));

        [Fact]
        public void Guards_InvalidExpression7_ThrowsGuardException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(() => TestClass.StaticActionNullableParams(default, default, default, Is.Nullable<ITestInterface>()))));

        #endregion Guards (Invalid Expression) Tests

        #region - - - - - - Guards (Nullable Static Action) Tests - - - - - -

        [Fact]
        public void Guards_NullableStaticAction_AllParamsDeclaredAsNullable_DoesNotThrowException()
            => Verify.Guards(()
                => TestClass.StaticActionNullableParams(
                    Is.Nullable<string>(),
                    Is.Nullable<int?>(),
                    Is.Nullable<TestClass2>(),
                    Is.Nullable<ITestInterface>()));

        [Fact]
        public void Guards_NullableStaticAction_StringParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableStaticAction_IntParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableStaticAction_TestClass2ParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableStaticAction_ITestInterfaceParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        #endregion Guards (Nullable Static Action) Tests

        #region - - - - - - Guards (Nullable Static Function) Tests - - - - - -

        [Fact]
        public void Guards_NullableStaticFunction_AllParamsDeclaredAsNullable_DoesNotThrowException()
            => Verify.Guards(()
                => TestClass.StaticActionNullableParams(
                    Is.Nullable<string>(),
                    Is.Nullable<int?>(),
                    Is.Nullable<TestClass2>(),
                    Is.Nullable<ITestInterface>()));

        [Fact]
        public void Guards_NullableStaticFunction_StringParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.NotNullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableStaticFunction_IntParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.Nullable<string>(),
                        Is.NotNullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableStaticFunction_TestClass2ParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.NotNullable<TestClass2>(),
                        Is.Nullable<ITestInterface>()))));

        [Fact]
        public void Guards_NullableStaticFunction_ITestInterfaceParamDeclaredAsNotNullable_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.StaticActionNullableParams(
                        Is.Nullable<string>(),
                        Is.Nullable<int?>(),
                        Is.Nullable<TestClass2>(),
                        Is.NotNullable<ITestInterface>()))));

        #endregion Guards (Nullable Static Function) Tests

        #region - - - - - - Guards (Nullable Non-Null Value Type) Tests - - - - - -

        [Fact]
        public void Guards_NotNullableValueTypeParam_NotNullableIntNullParam_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.NotNullableValueTypeParam(Is.Nullable<int>()))));

        #endregion Guards (Nullable Non-Null Value Type) Tests

        #region - - - - - - Guards (Non-Public Constructor) - - - - - -

        [Fact]
        public void Guards_NonPublicConstructor_ResolvingConstructorAsParameter_ResolvesCorrectly()
            => Verify.Guards((TestClass5 tc) => tc.NoParameters());

        #endregion Guards (Non-Public Constructor)

        #region - - - - - - Guards (Unconstructible Parameter Direct) Tests - - - - - -

        [Fact]
        public void Guards_UnconstructibleParamDirect_NotSpecifyingValue_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.UnconstructibleParamDirect(Is.Nullable<TestClass3>()))));

        [Fact]
        public void Guards_UnconstructibleParamDirect_ManuallySpecifyingValue_DoesNotThrowException()
            => Assert.Null(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.UnconstructibleParamDirect(Is.Nullable(new TestClass3(1))))));

        #endregion Guards (Unconstructible Parameter Direct) Tests

        #region - - - - - - Guards (Unconstructible Parameter Indirect) Tests - - - - - -

        [Fact]
        public void Guards_UnconstructibleParamIndirect_NotSpecifyingValue_ThrowsException()
            => Assert.IsType<GuardException>(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.UnconstructibleParamIndirect(Is.Nullable<TestClass4>()))));

        [Fact]
        public void Guards_UnconstructibleParamIndirect_ManuallySpecifyingValue_DoesNotThrowException()
            => Assert.Null(Record.Exception(()
                => Verify.Guards(()
                    => TestClass.UnconstructibleParamIndirect(Is.Nullable(new TestClass4(new TestClass3(1)))))));

        #endregion Guards (Unconstructible Parameter Indirect) Tests

    }

}
