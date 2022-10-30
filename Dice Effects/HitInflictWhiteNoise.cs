using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Dice_Effects
{
    public class DiceCardAbility_HitInflictNoise_md5488 : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 1 White Noise";

        public override void OnSucceedAttack()
        {
            if (behavior.card.target?.bufListDetail.GetActivatedBufList()
                    .Find(x => x is BattleUnitBuf_WhiteNoiseBuff_md5488) is BattleUnitBuf_WhiteNoiseBuff_md5488 buf)
                buf.OnAddBuf(1);
            else
                behavior.card.target?.bufListDetail.AddBuf(new BattleUnitBuf_WhiteNoiseBuff_md5488 { stack = 1 });
        }
    }
}