using System.Runtime.InteropServices;

namespace TuningShops.Memory
{
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    internal struct CVehicleModVisible
    {
        [FieldOffset(0x10)]
        public uint modelName;
        [FieldOffset(0x18)]
        public nint modShopLabel; // const char*
        [FieldOffset(0x20)]
        public AtArray<uint> linkedModels;
        [FieldOffset(0x30)]
        public EVehicleModType type;
        [FieldOffset(0x34)]
        public EVehicleModBone bone;
        [FieldOffset(0x38)]
        public EVehicleModBone collisionBone;
        [FieldOffset(0x40)]
        public AtArray<EVehicleModBone> turnOffBones;
        // ...
    }
}
