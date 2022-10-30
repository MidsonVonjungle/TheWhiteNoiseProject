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

        public override string BufName => "Crippling Pitch";

        public override string bufActivatedText =>
            "Inflict 2 Feeble and lower the *max* roll of all offensive die by 2 against The White Noise. If the opponent has 4 or more Strength, purge all its stacks instead.";

        protected override string keywordIconId => "WhiteNoise2_md5488";
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