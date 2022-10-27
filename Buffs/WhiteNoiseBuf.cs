using BigDLL4221.Buffs;
using UnityEngine;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_WhiteNoiseBuff_md5488 : BattleUnitBuf_BaseBufWithTitle_DLL4221
    {
        public override string BufName => "White Noise";
        public override string bufActivatedText => "White Noise Effect";
        protected override string keywordId => "BlackSilenceSpecial";
        protected override string keywordIconId => "WhiteNoise_md5488";

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