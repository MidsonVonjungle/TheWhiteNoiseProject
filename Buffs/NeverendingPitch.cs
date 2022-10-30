using System;
using System.Collections.Generic;
using BigDLL4221.Buffs;
using BigDLL4221.Extensions;
using TheWhiteNoiseProject.Passives;

namespace TheWhiteNoiseProject.Buffs
{
    public class BattleUnitBuf_NeverendingPitch_md5488 : BattleUnitBuf_BaseBufWithTitle_DLL4221
    {
        private readonly List<KeywordBuf> _debuffs = new List<KeywordBuf>
            { KeywordBuf.Weak, KeywordBuf.Disarm, KeywordBuf.Vulnerable, KeywordBuf.Paralysis };

        private Random _random;

        public BattleUnitBuf_NeverendingPitch_md5488()
        {
            stack = 0;
        }

        public override string BufName => "White Noise";

        public override string bufActivatedText =>
            "With 3 stacks of White Noise, a special page can be played against this character to inflict an unique ailment on them";

        protected override string keywordIconId => "WhiteNoise_md5488";
        public override int paramInBufDesc => 0;

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            _random = new Random();
        }

        public override void OnRoundEnd()
        {
            _owner.bufListDetail.RemoveBuf(this);
        }

        public override void OnStartTargetedOneSide(BattlePlayingCardDataInUnitModel attackerCard)
        {
            if (_random.Next(0, 100) <= 15)
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(RandomUtil.SelectOne(_debuffs), 1);
        }

        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            if (_random.Next(0, 100) <= 15)
                _owner.bufListDetail.AddKeywordBufThisRoundByEtc(RandomUtil.SelectOne(_debuffs), 1);
        }

        public override void BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (attacker.GetActivePassive<PassiveAbility_TheWhiteNoise_md5488>() == null) return;
            _owner.TakeDamage(RandomUtil.Range(2, 3));
        }
    }
}