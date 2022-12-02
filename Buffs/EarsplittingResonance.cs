using BigDLL4221.Buffs;
using BigDLL4221.Extensions;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_EarsplittingResonance_md5488 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        private readonly bool _intesify;

        public BattleUnitBuf_EarsplittingResonance_md5488(bool intesify = false)
        {
            stack = 0;
            _intesify = intesify;
        }
        protected override string keywordId => _intesify
            ? "EarsplittingResonance1_md5488"
            : "EarsplittingResonance2_md5488";
        public override string BufName => "Earsplitting Pitch";

        protected override string keywordIconId => "WhiteNoise2_md5488";
        public override int paramInBufDesc => 0;

        public override int MaxStack => 0;

        public override void BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (_intesify || attacker.GetActivePassive<PassiveAbility_TheWhiteNoise_md5488>() == null) return;
            _owner.TakeDamage(RandomUtil.Range(2, 3));
        }

        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            if (!_intesify || atkDice == null) return;
            _owner.TakeDamage(atkDice.DiceVanillaValue / 2);
        }
    }
}