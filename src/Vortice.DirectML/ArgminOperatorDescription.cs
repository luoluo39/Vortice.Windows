// Copyright © Aaron Sun, Amer Koleci, and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.DirectML;

public partial struct ArgminOperatorDescription : IOperatorDescription, IOperatorDescriptionMarshal
{
    /// <summary>
    /// Gets the type of operator description.
    /// </summary>
    public OperatorType OperatorType => OperatorType.Argmin;

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_ARGMIN_OPERATOR_DESC::InputTensor']/*" />
    public TensorDescription InputTensor { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_ARGMIN_OPERATOR_DESC::OutputTensor']/*" />
    public TensorDescription OutputTensor { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_ARGMIN_OPERATOR_DESC::Axes']/*" />
    public int[] Axes { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_ARGMIN_OPERATOR_DESC::AxisDirection']/*" />
    public AxisDirection AxisDirection { get; set; }

    /// <inheritdoc></inheritdoc>/>
    public override string ToString() => $"Argmin: AxisDirection={AxisDirection}";

    #region Marshal
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct __Native
    {
        public IntPtr InputTensor;
        public IntPtr OutputTensor;
        public int AxisCount;
        public IntPtr Axes;
        public AxisDirection AxisDirection;
    }

    unsafe IntPtr IOperatorDescriptionMarshal.__MarshalAlloc()
    {
        __Native* @ref = UnsafeUtilities.Alloc<__Native>();

        @ref->InputTensor = InputTensor.__MarshalAlloc();
        @ref->OutputTensor = OutputTensor.__MarshalAlloc();
        @ref->AxisCount = Axes.Length;
        @ref->Axes = new(UnsafeUtilities.AllocWithData(Axes));
        @ref->AxisDirection = AxisDirection;

        return new(@ref);
    }

    unsafe void IOperatorDescriptionMarshal.__MarshalFree(ref IntPtr pDesc)
    {
        var @ref = (__Native*)pDesc;

        InputTensor.__MarshalFree(ref @ref->InputTensor);
        OutputTensor.__MarshalFree(ref @ref->OutputTensor);
        UnsafeUtilities.Free(@ref->Axes);

        UnsafeUtilities.Free(@ref);
    }
    #endregion

    public static implicit operator OperatorDescription(ArgminOperatorDescription description)
    {
        return new(description);
    }
}
