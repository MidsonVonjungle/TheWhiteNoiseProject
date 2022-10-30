using LOR_DiceSystem;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_EarsplittingResonance_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[Start of Clash] Reduce Power of all target's dice by 1";

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(targetUnit);
            self.exhaust = true;
        }

        private static void Activate(BattleUnitModel unit)
        {
            var count = 0;
            var slashResist = unit.GetResistHP(BehaviourDetail.Slash);
            var pierceResist = unit.GetResistHP(BehaviourDetail.Penetrate);
            var hitResist = unit.GetResistHP(BehaviourDetail.Hit);
            if (slashResist == AtkResist.Endure || slashResist == AtkResist.Immune) count++;
            if (pierceResist == AtkResist.Endure || pierceResist == AtkResist.Immune) count++;
            if (hitResist == AtkResist.Endure || hitResist == AtkResist.Immune) count++;
            unit.bufListDetail.AddBuf(new BattleUnitBuf_EarsplittingResonance_md5488(count > 1));
        }
    }
}