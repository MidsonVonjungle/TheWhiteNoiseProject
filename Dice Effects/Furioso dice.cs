namespace TheWhiteNoiseProject.Dice_Effects
{
    public class DiceCardAbility_WhiteFurioso_md5488 : DiceCardAbilityBase
    {
        public override void OnSucceedAttack()
        {
            owner.allyCardDetail.DrawCards(3);
            owner.cardSlotDetail.RecoverPlayPointByCard(5);
        }
    }
}