using BigDLL4221.Buffs;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleDiceCardBuf_WhiteNoiseEgoCount_md5488 : BattleDiceCardBuf
    {
        protected override string keywordIconId => "WhiteNoiseCard_md5488";
    }

    //Buff that count the used cards
    public class BattleUnitBuf_WhiteNoiseSpecialCount_md5488 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_WhiteNoiseSpecialCount_md5488() : base(infinite: true, lastOneScene: false)
        {
        }

      //  public override string BufName => "Furioso";
      //  public override string bufActivatedText => $"Number of the White Noise's Combat Pages used : {stack}";
        protected override string keywordIconId => "WhiteNoiseCard_md5488";
    }
}