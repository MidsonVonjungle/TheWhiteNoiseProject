﻿using System.Collections.Generic;

public class BehaviourAction_BlackSilence_ShortSword_md5488 : BehaviourActionBase
{
    public override List<RencounterManager.MovingAction> GetMovingAction(
        ref RencounterManager.ActionAfterBehaviour self,
        ref RencounterManager.ActionAfterBehaviour opponent)
    {
        var flag = false;
        if (opponent.behaviourResultData != null)
            flag = opponent.behaviourResultData.IsFarAtk();
        if (self.result != Result.Win || self.data.actionType != ActionType.Atk || flag)
            return base.GetMovingAction(ref self, ref opponent);
        var movingAction1 = new List<RencounterManager.MovingAction>();
        var movingAction2 =
            new RencounterManager.MovingAction(ActionDetail.S10, CharMoveState.MoveForward, 30f, false, 0.9f);
        movingAction2.customEffectRes = "FX_PC_RolRang_Dagger";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
        new RencounterManager.MovingAction(ActionDetail.S7, CharMoveState.Stop, 0.0f, delay: 0.1f).SetEffectTiming(
            EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        movingAction1.Add(movingAction2);
        opponent.infoList.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop,
            updateDir: false, delay: 0.5f));
        return movingAction1;
    }
}