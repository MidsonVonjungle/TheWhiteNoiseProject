using System.Collections.Generic;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Passives
{
    public class PassiveAbility_TheWhiteNoise_md5488 : PassiveAbilityBase
    {
        private readonly List<LorId> _usedCount = new List<LorId>();

        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            var lorId = curCard.card.GetID();
            if (lorId.packageId != WhiteNoiseModParameters.PackageId) return;
            if (!_usedCount.Contains(lorId) && WhiteNoiseModParameters.WhiteNoiseCards.Contains(lorId.id))
                _usedCount.Add(lorId);
        }

        public override void OnWaveStart()
        {
            owner.personalEgoDetail.AddCard(WhiteNoiseModParameters.FuriosoCard);
        }

        public override void OnRoundStart()
        {
            foreach (var battleDiceCardModel in owner.allyCardDetail.GetAllDeck())
            {
                battleDiceCardModel.RemoveBuf<BattleDiceCardBuf_WhiteNoiseEgoCount_md5488>();
                var lorId = battleDiceCardModel.GetID();
                if (lorId.packageId != WhiteNoiseModParameters.PackageId) continue;
                if (!_usedCount.Contains(id) && WhiteNoiseModParameters.WhiteNoiseCards.Contains(lorId.id))
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
}