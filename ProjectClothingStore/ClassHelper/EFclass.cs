using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectClothingStore.DB;

namespace ProjectClothingStore.ClassHelper
{
    public static class EFclass
    {
        public static Entities Contexts { get; } = new Entities();
    }
}
