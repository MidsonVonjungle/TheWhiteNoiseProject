namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_Reverse_Atelier_Logic_md5488 : DiceCardSelfAbility_WhiteNoiseBaseCard_md5488
    {
        public static string Desc = "[On Use] : Draw 1 Page";

        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            base.OnUseCard();
        }
    }
}