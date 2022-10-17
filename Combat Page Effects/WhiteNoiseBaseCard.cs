using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_WhiteNoiseBaseCard_md5488 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            var target = card.target;
            if (!card.card.HasBuf<BattleDiceCardBuf_WhiteNoiseEgoCount_md5488>() || target == null) return;
            if (target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_WhiteNoiseBuff_md5488) is
                BattleUnitBuf_WhiteNoiseBuff_md5488 buf)
                buf.OnAddBuf(1);
            else
                target.bufListDetail.AddBuf(new BattleUnitBuf_WhiteNoiseBuff_md5488 { stack = 1 });
        }
    }
}