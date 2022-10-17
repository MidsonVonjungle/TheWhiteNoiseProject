using System.Linq;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Passives
{
    public class PassiveAbility_The_Black_Silence_md5488 : PassiveAbilityBase
    {
        public override void OnRoundStartAfter()
        {
            var cardNumber = RandomUtil.SelectOne(ModParameters.BlackSilenceOriginalCards);
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
            foreach (var card in owner.allyCardDetail.GetAllDeck()
                         .Where(x => x.HasBuf<BattleDiceCardBuf_TempCard_md5488>()))
                owner.allyCardDetail.ExhaustACardAnywhere(card);
        }
    }
}