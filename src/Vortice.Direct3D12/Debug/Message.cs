// Copyright � Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.Direct3D12.Debug;

public partial struct Message
{
    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[{Id}] [{Severity}] [{Category}] : {Description}";
    }

    #region Marshal
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal unsafe struct __Native
    {
        public MessageCategory Category;
        public MessageSeverity Severity;
        public MessageId Id;
        public sbyte* pDescription;
        public PointerSize DescriptionByteLength;
    }

    internal unsafe void __MarshalFrom(ref __Native @ref)
    {
        Category = @ref.Category;
        Severity = @ref.Severity;
        Id = @ref.Id;
        Description = (@ref.pDescription == null) ? null : new string(@ref.pDescription, 0, (int)@ref.DescriptionByteLength);
        DescriptionByteLength = @ref.DescriptionByteLength;
    }
    #endregion Marshal
}
