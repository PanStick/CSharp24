using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad01
{
    class NonPlayerCharacter(string name, NpcDialogPart openingDialog)
    {
        readonly string r_name = name;
        readonly NpcDialogPart r_openingDialog = openingDialog;

        public string Name { get { return r_name; } }

        public List<HeroDialogPart> NpcDialogPartStartTalking(DialogParser parser)
        {
            Console.WriteLine(parser.ParseDialog(r_openingDialog));
            return r_openingDialog.Responses;
        }
    }
}
