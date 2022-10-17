using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_WhiteNoiseFuriosoCard_md5488 : DiceCardSelfAbilityBase
    {
        public static string Desc =
            "This page can be used after using all 9 Combat Pages of the [White Noise]. [On Use] : Restore 5 Light and Draw 3 Cards";

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_TheWhiteNoise_md5488) is
                PassiveAbility_TheWhiteNoise_md5488 passiveAbility)
                return passiveAbility.IsActivatedSpecialCard();
            return false;
        }

        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(3);
            owner.cardSlotDetail.RecoverPlayPointByCard(5);
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_TheWhiteNoise_md5488) is
                PassiveAbility_TheWhiteNoise_md5488 passiveAbility)
                passiveAbility.ResetUsedCount();
        }
    }
}