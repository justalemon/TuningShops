using System.Runtime.InteropServices;

namespace TuningShops.Memory
{
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CVehicleModLink
    {
        [FieldOffset(0x10)]
        public uint modelName;
        [FieldOffset(0x14)]
        public EVehicleModBone bone;
        [FieldOffset(0x18), MarshalAs(UnmanagedType.I1)]
        public bool turnOffExtra;
    }
}
