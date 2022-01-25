using System.Runtime.InteropServices;

namespace TuningShops.Memory
{
    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    internal struct AtArray<T> where T : unmanaged
    {
        public unsafe T* Items;
        public ushort Count;
        public ushort Size;
    }
}
