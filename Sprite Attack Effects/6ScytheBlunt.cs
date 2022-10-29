using BigDLL4221.DiceEffects;

namespace TheWhiteNoiseProject.Sprite_Attack_Effects
{
    public class DiceAttackEffect_ScytheBlunt_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(WhiteNoiseModParameters.Path, 0.6f, 0.3f);
            base.Initialize(self, target, destroyTime);
        }
    }
}