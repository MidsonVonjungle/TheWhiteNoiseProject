using BigDLL4221.Passives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhiteNoiseProject.Passives
{
    public class PassiveAbility_Charles_Leader_md5488 : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            if (this.owner.emotionDetail.EmotionLevel < 3)
                return;
            { this.owner.cardSlotDetail.RecoverPlayPoint(2); }
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            int num1 = 0;
            if (this.owner.emotionDetail.EmotionLevel >= 3)
                num1 = 2;
            behavior.ApplyDiceStatBonus(new DiceStatBonus()
            {
                min = num1,
            });
        }
    }
}
