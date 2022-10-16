using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardAbility_MultiplyNatX3_md5488 : DiceCardAbilityBase
    {
        public override void OnRollDice()
        {
            var rolledDice = behavior.DiceVanillaValue;
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = rolledDice * 2
            });
        }
        public static string Desc = "Multiply the natural roll of this die by 3";
    }
}
