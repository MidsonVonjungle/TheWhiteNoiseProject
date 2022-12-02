namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_Ranga_Workshop_md5488 : DiceCardSelfAbility_WhiteNoiseBaseCard_md5488
    {
      //  public static string Desc = "[On Use] Gain 2 Haste the next scene";

        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 2, owner);
            base.OnUseCard();
        }
    }
}