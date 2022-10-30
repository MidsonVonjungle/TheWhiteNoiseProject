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

        public override string BufName => "Neverending Pitch";

        public override string bufActivatedText =>
            "Inflict one of these ailments (Feeble, Disarm, Fragile or Paralysis) on a hit against this character at a 15% chance.";

        protected override string keywordIconId => "WhiteNoise2_md5488";
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