using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad01
{
    class HeroDialogPart : IDialogPart
    {
        readonly string r_dialog;
        public NpcDialogPart? Response { get; set; }
        public HeroDialogPart(string dialog, NpcDialogPart response)
        {
            r_dialog = dialog;
            Response = response;
        }
        public HeroDialogPart(string dialog = "")
        {
            r_dialog = dialog;
        }
        public string GetDialog() { return r_dialog; }
    }
}
