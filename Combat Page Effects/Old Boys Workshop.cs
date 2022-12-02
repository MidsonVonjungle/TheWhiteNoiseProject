namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_Old_Boys_Workshop_md5488 : DiceCardSelfAbility_WhiteNoiseBaseCard_md5488
    {
        //public static string Desc = "[On Use] Restore 3 Light, Draw 1 Page";

        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPointByCard(3);
            owner.allyCardDetail.DrawCards(1);
            base.OnUseCard();
        }
    }
}