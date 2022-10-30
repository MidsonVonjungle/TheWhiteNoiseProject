using BigDLL4221.Buffs;
using LOR_DiceSystem;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_CripplingPitch_md5488 : BattleUnitBuf_BaseBufWithTitle_DLL4221
    {
        public BattleUnitBuf_CripplingPitch_md5488()
        {
            stack = 0;
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

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.card.target?.passiveDetail.HasPassive<PassiveAbility_TheWhiteNoise_md5488>() == null) return;
            if (behavior.Detail == BehaviourDetail.Slash || behavior.Detail == BehaviourDetail.Penetrate ||
                behavior.Detail == BehaviourDetail.Hit)
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    max = -2
                });
        }
    }
}