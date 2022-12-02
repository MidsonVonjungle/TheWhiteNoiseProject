using System.Collections.Generic;
using System.Linq;
using BigDLL4221.Extensions;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_NeverendingPitch_md5488 : DiceCardSelfAbilityBase
    {
     //   public static string Desc =
         //   "If the opponent has Feeble, Disarm, Paralysis and/or Fragile, transfer half of the stacks of every ailment the next turn.\n\n[Intensify] If the opponent has no Feeble, Disarm, Fragile or Paralysis, inflict one of these ailments on hit at a 15% chance the next scene.";

        private static readonly List<KeywordBuf> Debuffs = new List<KeywordBuf>
            { KeywordBuf.Weak, KeywordBuf.Disarm, KeywordBuf.Vulnerable, KeywordBuf.Paralysis };

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(targetUnit);
            unit.personalEgoDetail.RemoveCard(self.GetID());
            unit.personalEgoDetail.AddCard(self.GetID());
        }

        private static void Activate(BattleUnitModel unit)
        {
            unit.GetActiveBuff<BattleUnitBuf_WhiteNoiseBuff_md5488>()?.OnAddBuf(-3);
            var buffs = unit.bufListDetail.GetActivatedBufList().Where(x => Debuffs.Contains(x.bufType));
            var foreachEntry = false;
            foreach (var buff in buffs)
            {
                foreachEntry = true;
                unit.bufListDetail.AddKeywordBufByEtc(buff.bufType, buff.stack / 2);
                buff.stack /= 2;
            }

            if (!foreachEntry) unit.bufListDetail.AddBuf(new BattleUnitBuf_NeverendingPitch_md5488());
        }

        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit.GetActiveBuff<BattleUnitBuf_WhiteNoiseBuff_md5488>()?.stack > 2;
        }
    }
}