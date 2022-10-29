using BigDLL4221.DiceEffects;

namespace TheWhiteNoiseProject.Dice_Attack_Effects
{
    public class DiceAttackEffect_BlockEffect_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(WhiteNoiseModParameters.Path, 0.54f, 0.23f, 1f, overSelf: true);
            base.Initialize(self, target, destroyTime);
        }
    }
}