using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad01
{
    class NpcDialogPart : IDialogPart
    {
        readonly string r_dialog;
        public List<HeroDialogPart>? Responses { get; set; }

        public NpcDialogPart(string dialog = "")
        {
            r_dialog = dialog;
        }
        public NpcDialogPart(string dialog, List<HeroDialogPart> responses)
        {
            r_dialog = dialog;
            Responses = new(responses);
        }
        public string GetDialog() { return r_dialog; }
    }
}
