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

        public override string BufName => "Earsplitting Pitch";

        public override string bufActivatedText =>
            "Take 2~3 Bonus damage whenever The White Noise Damages this opponent. If the opponent has two or more Endured and/or Ineffective health defenses, whenever this character is Hit by an offensive die, they take damage equal to the half of the natural roll of that die instead. ";

        protected override string keywordIconId => "WhiteNoise2_md5488";
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