using System.Collections.Generic;
using UnityEngine;

public class BehaviourAction_WhiteNoise_TresFurioso_md5488 : BehaviourActionBase
{
    private BattleUnitModel _target;

    private bool _bMoveStigmaDual;
    private bool _bMovedWolv1;
    private bool _bMovedWolv2;
    private bool _bMovedWolvLast;
    private bool _bMoveReencounterAA;
    private bool _bMoveChainsaw2;
    private bool _bMoveReencounterAA2;
    private bool _bMoveReencounterAA3;
    private bool _bMovedTrident;
    private bool _bMoveWhiteDurandal1;
    private bool _bMoveWhiteDurandal2;

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
        this.SetStigmaMace(self1, oppo);
        this.SetStigmaAxe(self1, oppo);
        this.SetStigmaDual(self1, oppo);
        this.SetPunchGauntlet(self1, oppo);
        this.SetCylinder(self1, oppo);
        this.SetWolv(self1, oppo);
        this.SetWolvLast(self1, oppo);
        this.SetChainsaw1(self1, oppo);
        this.SetChainsaw2(self1, oppo);
        this.SetSniper(self1, oppo);
        this.SetTrident(self1, oppo);
        this.SetWhiteDurandal(self1, oppo);
        opponent.infoList = oppo;
        return self1;
    }

    private void SetStigmaMace(
     List<RencounterManager.MovingAction> self,
     List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S13, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "FireMace_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 6f, delay: 0.1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveReencounterAA));
        self.Add(movingAction1);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.5f)
        {
            knockbackPower = 2f
        });
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction3);
    }
    private void SetStigmaAxe(
     List<RencounterManager.MovingAction> self,
     List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "FireAxe_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.5f)
        {
            knockbackPower = 2f
        });
    }

    private void SetStigmaDual(
    List<RencounterManager.MovingAction> self,
    List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S14, CharMoveState.Custom, 0.0f, false, 0.01f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveStigmaDualWield));
        movingAction1.customEffectRes = "FireDual_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S14, CharMoveState.Stop, 0.0f, false, 0.5f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Default, CharMoveState.Stop, 0.0f, delay: 0.01f);
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 6f, delay: 0.1f);
        movingAction4.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveReencounterAA3));
        self.Add(movingAction1);
        self.Add(movingAction2);
        self.Add(movingAction3);
        self.Add(movingAction4);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.01f);
        oppo.Add(movingAction5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.5f);
        oppo.Add(movingAction6);
        RencounterManager.MovingAction movingAction7 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.01f);
        oppo.Add(movingAction7);
        RencounterManager.MovingAction movingAction8 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction7);
    }
    private void SetPunchGauntlet(
   List<RencounterManager.MovingAction> self,
   List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Hit, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "GauntletPunch_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.5f)
        {
            knockbackPower = 2f
        });
    }

    private void SetCylinder(
    List<RencounterManager.MovingAction> self,
    List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "Gunshot_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Stop, delay: 0.5f);
        movingAction2.customEffectRes = "Gunshot_md5488";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.1f)
        {
            knockbackPower = 5f
        });
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.1f)
        {
            knockbackPower = 5f
        });
    }
    private void SetWolv(
    List<RencounterManager.MovingAction> self,
    List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S8, CharMoveState.Custom, updateDir: false, delay: 0.2f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveWolv1));
        movingAction1.customEffectRes = "WolvSlash1_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S9, CharMoveState.Custom, updateDir: false, delay: 0.2f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveWolv2));
        movingAction2.customEffectRes = "WolvSlash2_md5488";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        self.Add(movingAction2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.2f);
        oppo.Add(movingAction3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.2f);
        oppo.Add(movingAction4);
    }
    private void SetWolvLast(
    List<RencounterManager.MovingAction> self,
    List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S10, CharMoveState.Custom, updateDir: false, delay: 0.5f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveWolvLast));
        movingAction1.customEffectRes = "FX_PC_RolRang_Dagger";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.5f);
        oppo.Add(movingAction2);
    }
    private void SetChainsaw1(
     List<RencounterManager.MovingAction> self,
     List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S1, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "ChainsawDown_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 12f, delay: 0.1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveReencounterAA2));
        self.Add(movingAction1);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.5f)
        {
            knockbackPower = 2f
        });
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction3);
    }
    private void SetChainsaw2(
     List<RencounterManager.MovingAction> self,
     List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S2, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "ChainsawUp_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.5f)
        {
            knockbackPower = 2f
        });
    }
    private void SetSniper(
   List<RencounterManager.MovingAction> self,
   List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Fire, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "Gunshot_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.1f)
        {
            knockbackPower = 5f
        });
    }
    private void SetTrident(
    List<RencounterManager.MovingAction> self,
    List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.Custom, updateDir: false, delay: 0.0f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveTrident));
        movingAction1.customEffectRes = "Trident_md5488";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.Stop, 0.0f, false, 0.3f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction1);
        self.Add(movingAction2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction4);
    }

    private void SetWhiteDurandal(
    List<RencounterManager.MovingAction> self,
    List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 0.0f, delay: 0.01f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveWhiteDurandal1));
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S7, CharMoveState.Stop, 0.0f, delay: 0.5f);
        movingAction2.customEffectRes = "FX_PC_RolRang_Slash_Down";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S6, CharMoveState.Custom, 0.0f, false, 0.01f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveWhiteDurandal2));
        movingAction3.customEffectRes = "FX_PC_RolRang_Slash_UP";
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S7, CharMoveState.Stop, 0.0f, false, 0.5f);
        movingAction4.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0.0f, delay: 1f);
        movingAction5.customEffectRes = "FX_PC_RolRang_Slash_Last";
        movingAction5.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
        self.Add(movingAction1);
        self.Add(movingAction2);
        self.Add(movingAction3);
        self.Add(movingAction4);
        self.Add(movingAction5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.01f);
        oppo.Add(movingAction6);
        RencounterManager.MovingAction movingAction7 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.5f);
        oppo.Add(movingAction7);
        RencounterManager.MovingAction movingAction8 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.01f);
        oppo.Add(movingAction8);
        RencounterManager.MovingAction movingAction9 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.5f);
        oppo.Add(movingAction9);
        RencounterManager.MovingAction movingAction10 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 1f);
        oppo.Add(movingAction10);
    }

    private bool MoveStigmaDualWield(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMoveStigmaDual)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 12.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMoveStigmaDual = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveWolv1(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMovedWolv1)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMovedWolv1 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveWolv2(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMovedWolv2)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMovedWolv2 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveWolvLast(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMovedWolvLast)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMovedWolvLast = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveReencounterAA(float deltaTime)
    {
        bool flag = false;
        if (!this._bMoveReencounterAA)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition + vector3, 150f);
            this._bMoveReencounterAA = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveReencounterAA2(float deltaTime)
    {
        bool flag = false;
        if (!this._bMoveReencounterAA2)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition + vector3, 150f);
            this._bMoveReencounterAA2 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }

    private bool MoveReencounterAA3(float deltaTime)
    {
        bool flag = false;
        if (!this._bMoveReencounterAA3)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition + vector3, 150f);
            this._bMoveReencounterAA3 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveChainsaw2(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMoveChainsaw2)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMoveChainsaw2 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveTrident(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMovedTrident)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 400f, false, true);
            this._bMovedTrident = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
    private bool MoveWhiteDurandal1(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMoveWhiteDurandal1)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition + vector3, 250f, false);
            this._bMoveWhiteDurandal1 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }

    private bool MoveWhiteDurandal2(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMoveWhiteDurandal2)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMoveWhiteDurandal2 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
}