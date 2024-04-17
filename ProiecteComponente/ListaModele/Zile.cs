
using System;

namespace ListaModele
{
    [Flags]
    public enum Zile
    {
        Nu       = 0,    // 0b_0000_0000
        Luni     = 1,    // 0b_0000_0001
        Marti    = 2,    // 0b_0000_0010
        Miercuri = 4,    // 0b_0000_0100
        Joi      = 8,    // 0b_0000_1000
        Vineri   = 16,   // 0b_0001_0000 
        Sambata  = 32,   // 0b_0010_0000
        Duminica = 64,   // 0b_0100_0000
        Weekend  = Sambata | Duminica
    }
}
