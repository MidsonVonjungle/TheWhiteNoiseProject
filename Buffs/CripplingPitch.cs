using BigDLL4221.Buffs;
using LOR_DiceSystem;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_CripplingPitch_md5488 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_CripplingPitch_md5488()
        {
            stack = 0;
        }

        public override string BufName => "Crippling Pitch";

     //   public override string bufActivatedText =>
       //     "Lower the *max* roll of all offensive die by 2 against The White Noise";

        protected override string keywordIconId => "WhiteNoise2_md5488";
        public override int paramInBufDesc => 0;
        public override int MaxStack => 0;

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