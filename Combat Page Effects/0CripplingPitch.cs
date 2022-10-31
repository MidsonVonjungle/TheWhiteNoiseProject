using System.Linq;
using BigDLL4221.Extensions;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_CripplingPitch_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc =
            "Inflict 2 Feeble and lower the *max* roll of all offensive die by 2 against The White Noise.\n\n[Intensify] If the opponent has 4 or more Strength, purge all its stacks instead.";

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(targetUnit);
            unit.personalEgoDetail.RemoveCard(self.GetID());
            unit.personalEgoDetail.AddCard(self.GetID());
        }

        private static void Activate(BattleUnitModel unit)
        {
            unit.GetActiveBuff<BattleUnitBuf_WhiteNoiseBuff_md5488>()?.OnAddBuf(-3);
            var strengthBuff = unit.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x.bufType == KeywordBuf.Strength && !x.IsDestroyed());
            if (strengthBuff == null || strengthBuff.stack < 4)
            {
                unit.bufListDetail.AddBuf(new BattleUnitBuf_CripplingPitch_md5488());
                unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Weak, 2);
            }
            else
            {
                unit.bufListDetail.RemoveBufAll(KeywordBuf.Strength);
            }
        }

        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit.GetActiveBuff<BattleUnitBuf_WhiteNoiseBuff_md5488>()?.stack > 2;
        }
    }
}