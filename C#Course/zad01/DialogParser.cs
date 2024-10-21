using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad01
{
    //static class, doesnt need the Hero
    class DialogParser(Hero hero)
    {
        Hero hero = hero;
        readonly string r_heroName = "#HERONAME#";

        public string ParseDialog(IDialogPart dialogPart)
        {
            return dialogPart.GetDialog().Replace(r_heroName, hero.Name);
        }
    }
}
