using UnityEngine;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_WhiteNoiseBuff_md5488 : BattleUnitBuf
    {
        protected override string keywordId => "BlackSilenceSpecial";
        protected override string keywordIconId => "BlackSilenceSpecialCard";

        public override void OnAddBuf(int addedStack)
        {
            stack += addedStack;
            stack = Mathf.Clamp(stack, 0, 3);
        }

        public override void OnRoundStartAfter()
        {
            if (stack == 0) _owner.bufListDetail.RemoveBuf(this);
        }
    }
}