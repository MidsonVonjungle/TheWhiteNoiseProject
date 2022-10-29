using BigDLL4221.DiceEffects;

namespace TheWhiteNoiseProject.Sprite_Attack_Effects
{
    public class DiceAttackEffect_FireMace_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(WhiteNoiseModParameters.Path, 0.76f, 0.38f);
            base.Initialize(self, target, destroyTime);
        }
    }
}