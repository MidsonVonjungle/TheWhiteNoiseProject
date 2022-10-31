using BigDLL4221.Extensions;
using LOR_DiceSystem;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_EarsplittingResonance_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "Inflict 3 Fragile and take 2~3 Bonus damage whenever The White Noise Damages this opponent.\n\n [Intensify] If the opponent has two or more Endured and/or Ineffective health defenses, whenever this character is Hit by an offensive die, they take damage equal to the half of the natural roll of that die instead.";

        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(targetUnit);
            //self.exhaust = true;
            unit.personalEgoDetail.RemoveCard(self.GetID());
            unit.personalEgoDetail.AddCard(self.GetID());

            var battleUnitBuf = targetUnit.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_WhiteNoiseBuff_md5488);
            targetUnit.bufListDetail.RemoveBuf(battleUnitBuf);
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
            if(count < 2) unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Vulnerable,3);
            unit.bufListDetail.AddBuf(new BattleUnitBuf_EarsplittingResonance_md5488(count > 1));
        }

        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            var buff = targetUnit.GetActiveBuff<BattleUnitBuf_WhiteNoiseBuff_md5488>();
            return buff != null && buff.stack > 4;
            //Kamiyo, I changed the value to 4 because this card was incomplete, so I made it unselectable, once you add
            //the intensify property, fix it back to 2
        }
    }
}