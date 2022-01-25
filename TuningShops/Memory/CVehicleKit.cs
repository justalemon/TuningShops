using System.Runtime.InteropServices;

namespace TuningShops.Memory
{
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    internal struct CVehicleKit
    {
        [FieldOffset(0x00)]
        public uint kitName;
        [FieldOffset(0x04)]
        public ushort id;
        [FieldOffset(0x08)]
        public EModKitType kitType;
        [FieldOffset(0x10)]
        public AtArray<CVehicleModVisible> visibleMods;
        [FieldOffset(0x20)]
        public AtArray<CVehicleModLink> linkMods;
    }
}
