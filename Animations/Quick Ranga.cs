using System.Collections.Generic;
using UnityEngine;

namespace TheWhiteNoiseProject.Animations
{
    public class BehaviourAction_WhiteNoise_Ranga_md5488 : BehaviourActionBase
    {
        private bool _bMovedGauntlet1;
        private bool _bMovedShortSword;
        private bool _bMoveGauntler2;
        private BattleUnitModel _target;

        public override bool IsMovable()
        {
            return false;
        }

        public override bool IsOpponentMovable()
        {
            return false;
        }

        public override List<RencounterManager.MovingAction> GetMovingAction(
            ref RencounterManager.ActionAfterBehaviour self,
            ref RencounterManager.ActionAfterBehaviour opponent)
        {
            var flag = false;
            if (opponent.behaviourResultData != null)
                flag = opponent.behaviourResultData.IsFarAtk();
            if (self.result != Result.Win || flag)
                return base.GetMovingAction(ref self, ref opponent);
            _self = self.view.model;
            _target = opponent.view.model;
            var self1 = new List<RencounterManager.MovingAction>();
            var oppo = new List<RencounterManager.MovingAction>();
            if (opponent.infoList.Count > 0)
                opponent.infoList.Clear();
            SetGauntlet(self1, oppo);
            SetShortSword(self1, oppo);
            opponent.infoList = oppo;
            return self1;
        }

        private void SetGauntlet(
            ICollection<RencounterManager.MovingAction> self,
            ICollection<RencounterManager.MovingAction> oppo)
        {
            var movingAction1 = new RencounterManager.MovingAction(ActionDetail.S8, CharMoveState.Custom,
                updateDir: false, delay: 0.2f);
            movingAction1.SetCustomMoving(MoveGauntlet1);
            movingAction1.customEffectRes = "BlackSilence_Gauntlet1";
            movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
            var movingAction2 = new RencounterManager.MovingAction(ActionDetail.S9, CharMoveState.Custom,
                updateDir: false, delay: 0.2f);
            movingAction2.SetCustomMoving(MoveGauntlet2);
            movingAction2.customEffectRes = "BlackSilence_Gauntlet2";
            movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
            self.Add(movingAction1);
            self.Add(movingAction2);
            var movingAction3 =
                new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.2f);
            oppo.Add(movingAction3);
            var movingAction4 =
                new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.2f);
            oppo.Add(movingAction4);
        }

        private void SetShortSword(
            ICollection<RencounterManager.MovingAction> self,
            ICollection<RencounterManager.MovingAction> oppo)
        {
            var movingAction1 = new RencounterManager.MovingAction(ActionDetail.S10, CharMoveState.Custom,
                updateDir: false, delay: 0.5f);
            movingAction1.SetCustomMoving(MoveShortSword);
            movingAction1.customEffectRes = "FX_PC_RolRang_Dagger";
            movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
            self.Add(movingAction1);
            var movingAction2 =
                new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.5f);
            oppo.Add(movingAction2);
        }

        private bool MoveGauntlet1(float deltaTime)
        {
            if (_target == null)
                return true;
            var flag = false;
            if (!_bMovedGauntlet1)
            {
                var worldPosition = _target.view.WorldPosition;
                var num1 = (float)(SingletonBehavior<HexagonalMapManager>.Instance.tileSize *
                    (double)_target.view.transform.localScale.x + 6.0);
                var num2 = 1;
                if (_self.view.WorldPosition.x < (double)_target.view.WorldPosition.x)
                    num2 = -1;
                var vector3 = new Vector3(num2 * num1, 0.0f, 0.0f);
                _self.moveDetail.Move(worldPosition - vector3, 250f, false);
                _bMovedGauntlet1 = true;
            }
            else if (_self.moveDetail.isArrived)
            {
                flag = true;
            }

            return flag;
        }

        private bool MoveGauntlet2(float deltaTime)
        {
            if (_target == null)
                return true;
            var flag = false;
            if (!_bMoveGauntler2)
            {
                var worldPosition = _target.view.WorldPosition;
                var num1 = (float)(SingletonBehavior<HexagonalMapManager>.Instance.tileSize *
                    (double)_target.view.transform.localScale.x + 6.0);
                var num2 = 1;
                if (_self.view.WorldPosition.x < (double)_target.view.WorldPosition.x)
                    num2 = -1;
                var vector3 = new Vector3(num2 * num1, 0.0f, 0.0f);
                _self.moveDetail.Move(worldPosition - vector3, 250f, false);
                _bMoveGauntler2 = true;
            }
            else if (_self.moveDetail.isArrived)
            {
                flag = true;
            }

            return flag;
        }

        private bool MoveShortSword(float deltaTime)
        {
            if (_target == null)
                return true;
            var flag = false;
            if (!_bMovedShortSword)
            {
                var worldPosition = _target.view.WorldPosition;
                var num1 = (float)(SingletonBehavior<HexagonalMapManager>.Instance.tileSize *
                    (double)_target.view.transform.localScale.x + 6.0);
                var num2 = 1;
                if (_self.view.WorldPosition.x < (double)_target.view.WorldPosition.x)
                    num2 = -1;
                var vector3 = new Vector3(num2 * num1, 0.0f, 0.0f);
                _self.moveDetail.Move(worldPosition - vector3, 250f, false);
                _bMovedShortSword = true;
            }
            else if (_self.moveDetail.isArrived)
            {
                flag = true;
            }

            return flag;
        }
    }
}