using BigDLL4221.DiceEffects;

namespace TheWhiteNoiseProject.Dice_Attack_Effects
{
    public class DiceAttackEffect_ChainsawUp_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(WhiteNoiseModParameters.Path, 0.65f, 0.26f);
            base.Initialize(self, target, destroyTime);
        }
    }
}