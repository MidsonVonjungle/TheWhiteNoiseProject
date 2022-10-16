using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhiteNoiseProject.Passives
{
    //Passive that handle the count of the 9 Cards
    public class PassiveAbility_TheWhiteNoise_md5488 : PassiveAbilityBase
    {
        private readonly List<LorId> _usedCount = new List<LorId>();
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            var lorId = curCard.card.GetID();
            if (lorId.packageId != ModParameters.PackageId) return;
            if (!_usedCount.Contains(lorId) && Enum.IsDefined(typeof(TheWhiteNoiseCardsEnum), lorId.id))
                _usedCount.Add(lorId);
        }

        public override void OnWaveStart()
        {
            owner.personalEgoDetail.AddCard(ModParameters.FuriosoCard);
        }

        public override void OnRoundStart()
        {
            foreach (var battleDiceCardModel in owner.allyCardDetail.GetAllDeck())
            {
                battleDiceCardModel.RemoveBuf<BattleDiceCardBuf_WhiteNoiseEgoCount_md5488>();
                var lorId = battleDiceCardModel.GetID();
                if (lorId.packageId != ModParameters.PackageId) continue;
                if (!_usedCount.Contains(id) && Enum.IsDefined(typeof(TheWhiteNoiseCardsEnum), lorId.id))
                    battleDiceCardModel.AddBuf(new BattleDiceCardBuf_WhiteNoiseEgoCount_md5488());
            }
            owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_WhiteNoiseSpecialCount_md5488));
            owner.bufListDetail.AddBuf(new BattleUnitBuf_WhiteNoiseSpecialCount_md5488
            {
                stack = _usedCount.Count
            });
        }
        public bool IsActivatedSpecialCard()
        {
            return _usedCount.Count >= 9;
        }

        public void ResetUsedCount()
        {
            _usedCount.Clear();
        }
    }

    //Card Icon
    public class BattleDiceCardBuf_WhiteNoiseEgoCount_md5488 : BattleDiceCardBuf
    {
        protected override string keywordIconId => "BlackSilenceSpecialCard";
    }
    //Buff that count the used cards
    public class BattleUnitBuf_WhiteNoiseSpecialCount_md5488 : BattleUnitBuf
    {
        protected override string keywordId => "BlackSilenceSpecial";
        protected override string keywordIconId => "BlackSilenceSpecialCard";
    }

    //Card Ids
    public enum TheWhiteNoiseCardsEnum
    {
        AtelierLogic = 1,
        AllasWorkshop = 2,
        MookWorkshop = 3,
        OldBoysWorkshop = 4,
        ZelkovaWorkshop = 5,
        Durandal = 6,
        CrystalAtelier = 7,
        RangaWorkshop = 8,
        WheelsIndustries = 9
    }

    //Base Card Class TODO need to change the buff (BattleUnitBuf) with the one that you want to add
    public class DiceCardSelfAbility_WhiteNoiseBaseCard_md5488 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            var target = card.target;
            if (card.card.HasBuf<BattleDiceCardBuf_WhiteNoiseEgoCount_md5488>() && target != null)
            {
                if (target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf) is BattleUnitBuf buf)
                    buf.OnAddBuf(1);
                else
                    target.bufListDetail.AddBuf(new BattleUnitBuf { stack = 1 });
            }
        }
    }
    //Card Exemple
    public class DiceCardSelfAbility_WhiteNoiseCard1 : DiceCardSelfAbility_WhiteNoiseBaseCard_md5488
    {
        public override void OnUseCard()
        {
            base.OnUseCard();
            //Your stuff
        }
    }
    //Furioso Card
    public class DiceCardSelfAbility_WhiteNoiseFuriosoCard : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_TheWhiteNoise_md5488) is PassiveAbility_TheWhiteNoise_md5488 passiveAbility)
                return passiveAbility.IsActivatedSpecialCard();
            return false;
        }
        public override void OnUseCard()
        {
            if (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_TheWhiteNoise_md5488) is PassiveAbility_TheWhiteNoise_md5488 passiveAbility)
                passiveAbility.ResetUsedCount();
        }
    }
    public static class ModParameters
    {
        public static string PackageId { get; set; }
        public static LorId FuriosoCard { get; set; }
    }
}
