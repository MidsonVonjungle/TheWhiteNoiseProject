using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Dice_Effects
{
    public class DiceCardAbility_WhiteFurioso_md5488 : DiceCardAbilityBase
    {

        public override void OnSucceedAttack()
        {
            this.owner.allyCardDetail.DrawCards(3);
            this.owner.cardSlotDetail.RecoverPlayPointByCard(5);
        }
    }
}
