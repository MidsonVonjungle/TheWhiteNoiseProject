using BigDLL4221.Buffs;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_WhiteNoiseBuff_md5488 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_WhiteNoiseBuff_md5488() : base(infinite: true)
        {
        }

        public override string BufName => "White Noise";

        //     public override string bufActivatedText =>
        //         "With 3 stacks of White Noise, a special page can be played against this character to inflict an unique ailment on them";

        protected override string keywordId => "WhiteNoiseBuff_md5488";
        protected override string keywordIconId => "WhiteNoise_md5488";
        public override int MaxStack => 3;
        public override bool DestroyedAt0Stack => true;
    }
}