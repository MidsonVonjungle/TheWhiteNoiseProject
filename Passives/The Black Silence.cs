using System.Linq;
using HarmonyLib;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Passives
{
    public class PassiveAbility_The_Black_Silence_md5488 : PassiveAbilityBase
    {
        public override void OnRoundStartAfter()
        {
            var cardNumber = RandomUtil.SelectOne(WhiteNoiseModParameters.BlackSilenceOriginalCards);
            var card = owner.allyCardDetail.AddNewCard(cardNumber);
            card.AddBuf(new BattleDiceCardBuf_TempCard_md5488());
        }

        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.HasBuf<BattleDiceCardBuf_TempCard_md5488>())
                owner.allyCardDetail.ExhaustACardAnywhere(curCard.card);
        }

        public override void OnRoundEndTheLast()
        {
            owner.allyCardDetail.GetAllDeck()
                .Where(x => x.HasBuf<BattleDiceCardBuf_TempCard_md5488>())
                .Do(x => owner.allyCardDetail.ExhaustACardAnywhere(x));
        }
    }
}