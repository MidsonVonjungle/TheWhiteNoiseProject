using BigDLL4221.DiceEffects;

namespace TheWhiteNoiseProject.Dice_Attack_Effects
{
    public class DiceAttackEffect_FireAxe_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(WhiteNoiseModParameters.Path, 0.81f, 0.02f, overSelf: true);
            base.Initialize(self, target, destroyTime);
        }
    }
}
