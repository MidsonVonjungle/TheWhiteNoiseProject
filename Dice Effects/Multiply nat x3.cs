namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardAbility_MultiplyNatX3_md5488 : DiceCardAbilityBase
    {
        public static string Desc = "Multiply the natural roll of this die by 3";

        public override void OnRollDice()
        {
            var rolledDice = behavior.DiceVanillaValue;
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                power = rolledDice * 2
            });
        }
    }
}