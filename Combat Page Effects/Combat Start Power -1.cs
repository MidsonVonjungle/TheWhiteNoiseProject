using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhiteNoiseProject
{
    public class DiceCardSelfAbility_powerDown1target_md5488 : DiceCardSelfAbilityBase
    {
        public override void OnStartParrying()
        {
            BattleUnitModel target = this.card.target;
            if (target == null)
                return;
            BattlePlayingCardDataInUnitModel currentDiceAction = target.currentDiceAction;
            if (currentDiceAction == null)
                return;
            currentDiceAction.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus()
            {
                power = -1
            });
        }
        public static string Desc = "[Start of Clash] Reduce Power of all target's dice by 1";
    }

}
