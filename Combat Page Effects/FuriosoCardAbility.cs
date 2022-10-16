using System.Linq;
using TheWhiteNoiseProject.Buffs;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_WhiteNoiseFuriosoCard : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_TheWhiteNoise_md5488) is
                PassiveAbility_TheWhiteNoise_md5488 passiveAbility)
                return passiveAbility.IsActivatedSpecialCard();
            return false;
        }

        public override void OnUseCard()
        {
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_TheWhiteNoise_md5488) is
                PassiveAbility_TheWhiteNoise_md5488 passiveAbility)
                passiveAbility.ResetUsedCount();
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            behavior.card.target?.bufListDetail.GetActivatedBufList().FirstOrDefault(x => x is BattleUnitBuf_WhiteNoiseBuff_md5488)?.OnAddBuf(-3);
        }
    }
}