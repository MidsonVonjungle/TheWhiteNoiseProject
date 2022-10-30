using BigDLL4221.Buffs;
using BigDLL4221.Extensions;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_EarsplittingResonance_md5488 : BattleUnitBuf_BaseBufWithTitle_DLL4221
    {
        private readonly bool _intesify;

        public BattleUnitBuf_EarsplittingResonance_md5488(bool intesify = false)
        {
            stack = 0;
            _intesify = intesify;
        }

        public override string BufName => "White Noise";

        public override string bufActivatedText =>
            "With 3 stacks of White Noise, a special page can be played against this character to inflict an unique ailment on them";

        protected override string keywordIconId => "WhiteNoise_md5488";
        public override int paramInBufDesc => 0;


        public override void OnRoundEnd()
        {
            _owner.bufListDetail.RemoveBuf(this);
        }

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