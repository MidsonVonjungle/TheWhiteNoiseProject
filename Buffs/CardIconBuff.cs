namespace TheWhiteNoiseProject.Buffs
{
    public class BattleDiceCardBuf_WhiteNoiseEgoCount_md5488 : BattleDiceCardBuf
    {
        protected override string keywordIconId => "WhiteNoiseCard_md5488";
    }

    //Buff that count the used cards
    public class BattleUnitBuf_WhiteNoiseSpecialCount_md5488 : BattleUnitBuf
    {
        protected override string keywordId => "BlackSilenceSpecial";
        //We need to change this, BlackSilenceSpecial uses the wrong Description and will mention the name 'Black Silence' instead of The White Noise
        protected override string keywordIconId => "WhiteNoiseCard_md5488";
    }
}