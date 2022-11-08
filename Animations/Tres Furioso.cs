using System.Collections.Generic;
using UnityEngine;

public class BehaviourAction_WhiteNoise_SpecialDurandal : BehaviourActionBase
{
    private BattleUnitModel _target;
    private bool _bMovedLance;
    private bool _bMoveAfterHammer;
    private bool _bMovedGauntlet1;
    private bool _bMoveGauntler2;
    private bool _bMovedShortSword;
    private bool _bMoveDualWield;
    private bool _bMoveDurandal1;
    private bool _bMoveDurandal2;

    public override bool IsMovable() => false;

    public override bool IsOpponentMovable() => false;

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
        this.SetRevolver(self1, oppo);
        this.SetLance(self1, oppo);
        this.SetHammer(self1, oppo);
        this.SetLongSword(self1, oppo);
        this.SetGauntlet(self1, oppo);
        this.SetShortSword(self1, oppo);
        this.SetAxe(self1, oppo);
        this.SetMace(self1, oppo);
        this.SetGreatSword(self1, oppo);
        this.SetDualWield(self1, oppo);
        this.SetShotgun(self1, oppo);
        this.SetDurandal(self1, oppo);
        opponent.infoList = oppo;
        return self1;
    }

    private void SetRevolver(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S1, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "BlackSilence_Revolver";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S2, CharMoveState.Stop, delay: 0.5f);
        movingAction2.customEffectRes = "BlackSilence_Revolver";
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

    private void SetLance(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.Custom, updateDir: false, delay: 0.0f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveLance));
        movingAction1.customEffectRes = "BlackSilence_Z";
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

    private void SetHammer(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Hit, CharMoveState.MoveForward, delay: 0.6f);
        movingAction1.customEffectRes = "BlackSilence_H";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 6f, delay: 0.1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfterHammer));
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction1);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.6f)
        {
            knockbackPower = 5f
        });
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction3);
    }

    private void SetLongSword(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Stop, 0.0f, delay: 0.2f);
        movingAction1.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.Stop, 0.0f, delay: 0.3f);
        movingAction2.customEffectRes = "FX_PC_RolRang_ShadowSlsah";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Stop, 0.0f, delay: 0.4f);
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction1);
        self.Add(movingAction2);
        self.Add(movingAction3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.2f);
        oppo.Add(movingAction4);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.3f);
        oppo.Add(movingAction5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.4f);
        oppo.Add(movingAction6);
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

    private void SetAxe(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S8, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "BlackSilence_Axe";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction2);
    }

    private void SetMace(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S9, CharMoveState.Stop, delay: 0.5f);
        movingAction1.customEffectRes = "BlackSilence_Mace";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction2);
    }

    private void SetGreatSword(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.S10, CharMoveState.Stop, delay: 1f);
        movingAction1.customEffectRes = "FX_PC_RolRang_Greatsword";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction1);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.1f);
        oppo.Add(movingAction2);
    }

    private void SetDualWield(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Custom, 0.0f, false, 0.01f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveDualWield));
        movingAction1.customEffectRes = "FX_PC_RolRang_XSlash_Main";
        movingAction1.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Stop, 0.0f, false, 0.5f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Default, CharMoveState.Stop, 0.0f, delay: 0.01f);
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction1);
        self.Add(movingAction2);
        self.Add(movingAction3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.01f);
        oppo.Add(movingAction4);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.5f);
        oppo.Add(movingAction5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, delay: 0.01f);
        oppo.Add(movingAction6);
    }

    private void SetShotgun(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S11, CharMoveState.MoveBack, 3f, delay: 0.3f);
        movingAction.customEffectRes = "BlackSilence_Shotgun";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, delay: 0.3f)
        {
            knockbackPower = 15f
        });
    }

    private void SetDurandal(
      List<RencounterManager.MovingAction> self,
      List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction1 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 0.0f, delay: 0.01f);
        movingAction1.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveDurandal1));
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S12, CharMoveState.Stop, 0.0f, delay: 0.5f);
        movingAction2.customEffectRes = "FX_PC_RolRang_Slash_Down";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S13, CharMoveState.Custom, 0.0f, false, 0.01f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveDurandal2));
        movingAction3.customEffectRes = "FX_PC_RolRang_Slash_UP";
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S13, CharMoveState.Stop, 0.0f, false, 0.5f);
        movingAction4.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S14, CharMoveState.Stop, 0.0f, delay: 1f);
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

    private bool MoveLance(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMovedLance)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 400f, false, true);
            this._bMovedLance = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }

    private bool MoveAfterHammer(float deltaTime)
    {
        bool flag = false;
        if (!this._bMoveAfterHammer)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition + vector3, 150f);
            this._bMoveAfterHammer = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
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

    private bool MoveDualWield(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMoveDualWield)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 12.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMoveDualWield = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }

    private bool MoveDurandal1(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMoveDurandal1)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition + vector3, 250f, false);
            this._bMoveDurandal1 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }

    private bool MoveDurandal2(float deltaTime)
    {
        if (this._target == null)
            return true;
        bool flag = false;
        if (!this._bMoveDurandal2)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float num1 = (float)((double)SingletonBehavior<HexagonalMapManager>.Instance.tileSize * (double)this._target.view.transform.localScale.x + 6.0);
            int num2 = 1;
            if ((double)this._self.view.WorldPosition.x < (double)this._target.view.WorldPosition.x)
                num2 = -1;
            Vector3 vector3 = new Vector3((float)num2 * num1, 0.0f, 0.0f);
            this._self.moveDetail.Move(worldPosition - vector3, 250f, false);
            this._bMoveDurandal2 = true;
        }
        else if (this._self.moveDetail.isArrived)
            flag = true;
        return flag;
    }
}
