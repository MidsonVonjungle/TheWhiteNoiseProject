using BigDLL4221.Buffs;
using BigDLL4221.Extensions;
using LOR_DiceSystem;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_DisturbingFrequency_md5488 : BattleUnitBuf_BaseBufWithTitle_DLL4221
    {
        public BattleUnitBuf_DisturbingFrequency_md5488()
        {
            stack = 0;
        }

        public override string BufName => "Disturbing Pitch";

        public override string bufActivatedText =>
            "Inflict 2 Disarm and lower the *min* roll of all defensive die by 2 against The White Noise.\n\n[Intensify] If the opponent has 4 or more Endured, purge all its stacks instead.";

        protected override string keywordIconId => "WhiteNoise2_md5488";
        public override int paramInBufDesc => 0;


        public override void OnRoundEnd()
        {
            _owner.bufListDetail.RemoveBuf(this);
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.card.target?.GetActivePassive<PassiveAbility_TheWhiteNoise_md5488>() == null) return;
            if (behavior.Detail == BehaviourDetail.Guard || behavior.Detail == BehaviourDetail.Evasion)
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    min = -2
                });
        }
    }
}