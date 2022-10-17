namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_Reverse_Allas_Workshop_md5488 : DiceCardSelfAbility_WhiteNoiseBaseCard_md5488
    {
        public static string Desc = "[Start of Clash] : Reduce Power of all target's dice by 1";

        public override void OnStartParrying()
        {
            card.target?.currentDiceAction?.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = -1
            });
        }
    }
}