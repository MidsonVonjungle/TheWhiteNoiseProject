using BigDLL4221.DiceEffects;

namespace TheWhiteNoiseProject.Sprite_Attack_Effects
{
    public class DiceAttackEffect_Trident_md5488 : DiceAttackEffect_BaseAttackEffect_DLL4221
    {
        public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
        {
            SetParameters(WhiteNoiseModParameters.Path, 1f, 0.14f, 1f);
            base.Initialize(self, target, destroyTime);
        }
    }
}