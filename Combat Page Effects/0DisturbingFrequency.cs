using BigDLL4221.Extensions;
using System.Linq;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_DisturbingFrequency_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "Inflict 2 Disarm and lower the *min* roll of all defensive die by 2 against The White Noise.\n\n[Intensify] If the opponent has 4 or more Endured, purge all its stacks instead.";

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(targetUnit);
            self.exhaust = true;
        }

        private static void Activate(BattleUnitModel unit)
        {
            var strengthBuff = unit.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x.bufType == KeywordBuf.Endurance && !x.IsDestroyed());
            if (strengthBuff == null || strengthBuff.stack < 4)
            {
                unit.bufListDetail.AddBuf(new BattleUnitBuf_DisturbingFrequency_md5488());
                unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Disarm,2);
            }
            else unit.bufListDetail.RemoveBufAll(KeywordBuf.Endurance);
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit.GetActiveBuff<BattleUnitBuf_WhiteNoiseBuff_md5488>().stack > 2;
        }
    }
}