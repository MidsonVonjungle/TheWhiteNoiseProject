using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheWhiteNoiseProject.Animations
{
    public class BehaviourAction_WhiteNoise_Ranga_md5488 : BehaviourActionBase
    {
        public override bool IsMovable() => false;
        public override bool IsOpponentMovable() => false;

        private bool _bMovedGauntlet1;
        private bool _bMoveGauntler2;
        private bool _bMovedShortSword;
        private BattleUnitModel _target;

        public override List<RencounterManager.MovingAction> GetMovingAction(
    ref RencounterManager.ActionAfterBehaviour self,
    ref RencounterManager.ActionAfterBehaviour opponent)
        {
            bool flag = false;
            if (opponent.behaviourResultData != null)
                flag = opponent.behaviourResultData.IsFarAtk();
            if (self.result != Result.Win || flag)
                return base.GetMovingAction(ref self, ref opponent);
            this._self = self.view.model;
            this._target = opponent.view.model;
            List<RencounterManager.MovingAction> self1 = new List<RencounterManager.MovingAction>();
            List<RencounterManager.MovingAction> oppo = new List<RencounterManager.MovingAction>();
            if (opponent.infoList.Count > 0)
                opponent.infoList.Clear();
            this.SetGauntlet(self1, oppo);
            this.SetShortSword(self1, oppo);
            opponent.infoList = oppo;
            return self1;
        }

        private void SetGauntlet(
        List<RencounterManager.MovingAction> self,
        List<RencounterManager.MovingAction> oppo)
        {
            RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Custom, updateDir: false, delay: 0.2f);
            movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveGauntlet1));
            movingAction1.customEffectRes = "BlackSilence_Gauntlet1";
            movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
            RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S6, CharMoveState.Custom, updateDir: false, delay: 0.2f);
            movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveGauntlet2));
            movingAction2.customEffectRes = "BlackSilence_Gauntlet2";
            movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
            self.Add(movingAction1);
            self.Add(movingAction2);
            RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.2f);
            oppo.Add(movingAction3);
            RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.2f);
            oppo.Add(movingAction4);
        }
        private void SetShortSword(
        List<RencounterManager.MovingAction> self,
        List<RencounterManager.MovingAction> oppo)
        {
            RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S7, CharMoveState.Custom, updateDir: false, delay: 0.5f);
            movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveShortSword));
            movingAction1.customEffectRes = "FX_PC_RolRang_Dagger";
            movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
            self.Add(movingAction1);
            RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.5f);
            oppo.Add(movingAction2);
        }
        private bool MoveGauntlet1(float deltaTime)
        {
            if (this._target == null)
                return true;
            bool flag = false;
            if (!this._bMovedGauntlet1)
            {
                Vector3 worldPosition = this._target.view.WorldPosition;
                float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
                int num2 = 1;
                if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                    num2 = -1;
                Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
                this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
                this._bMovedGauntlet1 = true;
            }
            else if (this._self.moveDetail.isArrived)
                flag = true;
            return flag;
        }

        private bool MoveGauntlet2(float deltaTime)
        {
            if (this._target == null)
                return true;
            bool flag = false;
            if (!this._bMoveGauntler2)
            {
                Vector3 worldPosition = this._target.view.WorldPosition;
                float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
                int num2 = 1;
                if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                    num2 = -1;
                Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
                this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
                this._bMoveGauntler2 = true;
            }
            else if (this._self.moveDetail.isArrived)
                flag = true;
            return flag;
        }
        private bool MoveShortSword(float deltaTime)
        {
            if (this._target == null)
                return true;
            bool flag = false;
            if (!this._bMovedShortSword)
            {
                Vector3 worldPosition = this._target.view.WorldPosition;
                float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
                int num2 = 1;
                if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                    num2 = -1;
                Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
                this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
                this._bMovedShortSword = true;
            }
            else if (this._self.moveDetail.isArrived)
                flag = true;
            return flag;
        }
    }
}
