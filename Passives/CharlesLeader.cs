namespace TheWhiteNoiseProject.Passives
{
    public class PassiveAbility_Charles_Leader_md5488 : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            if (owner.emotionDetail.EmotionLevel < 4) return;
            owner.cardSlotDetail.RecoverPlayPoint(1);
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (owner.emotionDetail.EmotionLevel < 4) return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                min = 2
            });
        }
    }
}