using System.Runtime.InteropServices;

namespace TuningShops.Memory
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct CVehicleModelInfoVarGlobal
    {
        [FieldOffset(0x58)]
        public AtArray<CVehicleKit> Kits;
    }
}
