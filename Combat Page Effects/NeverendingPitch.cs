using System.Collections.Generic;
using System.Linq;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_NeverendingPitch_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[Start of Clash] Reduce Power of all target's dice by 1";

        private static readonly List<KeywordBuf> Debuffs = new List<KeywordBuf>
            { KeywordBuf.Weak, KeywordBuf.Disarm, KeywordBuf.Vulnerable, KeywordBuf.Paralysis };

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(targetUnit);
            self.exhaust = true;
        }

        private static void Activate(BattleUnitModel unit)
        {
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
    }
}