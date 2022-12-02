using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Dice_Effects
{
    public class DiceCardAbility_WhiteFurioso_md5488 : DiceCardAbilityBase
    {
        //public static string Desc = "[On Clash Win] Destroy all of opponent's dice and inflict 3 White Noise.";

        public override void OnSucceedAttack()
        {
            if (behavior.card.target?.bufListDetail.GetActivatedBufList()
                    .Find(x => x is BattleUnitBuf_WhiteNoiseBuff_md5488) is BattleUnitBuf_WhiteNoiseBuff_md5488 buf)
                buf.OnAddBuf(3);
            else
                behavior.card.target?.bufListDetail.AddBuf(new BattleUnitBuf_WhiteNoiseBuff_md5488 { stack = 3 });
        }

        public override void OnWinParrying()
        {
            if (card?.target?.currentDiceAction?.cardBehaviorQueue.Count > 0)
                card?.target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice);
        }
    }
}