namespace TheWhiteNoiseProject
{
    public class DiceCardSelfAbility_powerDown1target_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[Start of Clash] Reduce Power of all target's dice by 1";

        public override void OnStartParrying()
        {
            card.target?.currentDiceAction?.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = -1
            });
        }
    }
}