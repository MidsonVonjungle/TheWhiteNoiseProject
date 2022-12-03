using System.Linq;
using TheWhiteNoiseProject.Buffs;

namespace TheWhiteNoiseProject.Combat_Page_Effects
{
    public class DiceCardSelfAbility_Reverse_Crystal_Atelier_md5488 : DiceCardSelfAbility_WhiteNoiseBaseCard_md5488
    {
        private const int Check = 2;

        //   public static string Desc =
        //     "[On Use] If [White Noise] stacks on the opponent is 2 or higher, all dice on this page gain +2 Power";

        public override void OnUseCard()
        {
            var enemybuff = card.target?.bufListDetail.GetActivatedBufList()
                .FirstOrDefault(x => x is BattleUnitBuf_WhiteNoiseBuff_md5488);
            if (enemybuff != null && enemybuff.stack >= Check)
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 2
                });
            base.OnUseCard();
        }
        public override string[] Keywords
        {
            get
            {
                return new[]
                {
                    "WhiteNoiseBuff2_md5488"
                };
            }
        }
    }
}