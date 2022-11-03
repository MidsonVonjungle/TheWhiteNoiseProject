using BigDLL4221.Passives;

namespace TheWhiteNoiseProject.Passives
{
    public class PassiveAbility_Roland_From_Another_World_md5488 : PassiveAbility_PlayerMechBase_DLL4221
    {
        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            SetUtil(new WhiteNoiseUtil().Util);
        }
    }
}