using System.Diagnostics;

namespace TuningShops.Memory
{
    public class MemoryPatterns
    {
        public static unsafe byte* FindPattern(string pattern, string mask)
        {
            ProcessModule module = Process.GetCurrentProcess().MainModule;

            ulong address = (ulong)module.BaseAddress.ToInt64();
            ulong endAddress = address + (ulong)module.ModuleMemorySize;

            for (; address < endAddress; address++)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (mask[i] != '?' && ((byte*)address)[i] != pattern[i])
                        break;
                    else if (i + 1 == pattern.Length)
                        return (byte*)address;
                }
            }

            return null;
        }
    }
}
