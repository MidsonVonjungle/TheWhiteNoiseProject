using System.Linq;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_DisturbingFrequency_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[Start of Clash] Reduce Power of all target's dice by 1";

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
                unit.bufListDetail.AddBuf(new BattleUnitBuf_DisturbingFrequency_md5488());
            else unit.bufListDetail.RemoveBufAll(KeywordBuf.Endurance);
        }
    }
}