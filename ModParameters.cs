﻿using System.Collections.Generic;
using BigDLL4221.BaseClass;
using BigDLL4221.Models;
using LOR_XML;

namespace TheWhiteNoiseProject
{
    public static class WhiteNoiseModParameters
    {
        public static string PackageId = "WhiteRoland.md588";
        public static string Path;
        public static LorId FuriosoCard = new LorId(PackageId, 10);

        public static List<int> BlackSilenceOriginalCards = new List<int>
            { 702001, 702002, 702003, 702004, 702005, 702006, 702007, 702008, 702009 };

        public static List<int> WhiteNoiseCards = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static BattleDialogCharacter WhiteNoiseDialog = new BattleDialogCharacter{dialogTypeList = new List<BattleDialogType>
        {
            new BattleDialogType{dialogType = DialogType.START_BATTLE,dialogList = new List<BattleDialog>{new BattleDialog{dialogContent = "..."}}},
            new BattleDialogType{dialogType = DialogType.KILLS_OPPONENT,dialogList = new List<BattleDialog>{new BattleDialog{dialogContent = "..."}}},
            new BattleDialogType{dialogType = DialogType.COLLEAGUE_DEATH,dialogList = new List<BattleDialog>{new BattleDialog{dialogContent = "..."}}},
            new BattleDialogType{dialogType = DialogType.BATTLE_VICTORY,dialogList = new List<BattleDialog>{new BattleDialog{dialogContent = "..."}}},
            new BattleDialogType{dialogType = DialogType.DEATH,dialogList = new List<BattleDialog>{new BattleDialog{dialogContent = "..."}}}
        }
        };
    }

    public class WhiteNoiseUtil
    {
        public MechUtilBase Util = new MechUtilBase(new MechUtilBaseModel(additionalStartDraw: 2,
            personalCards: new Dictionary<LorId, PersonalCardOptions>
            {
                { new LorId(WhiteNoiseModParameters.PackageId, 11), new PersonalCardOptions() },
                { new LorId(WhiteNoiseModParameters.PackageId, 12), new PersonalCardOptions() },
                { new LorId(WhiteNoiseModParameters.PackageId, 13), new PersonalCardOptions() },
                { new LorId(WhiteNoiseModParameters.PackageId, 14), new PersonalCardOptions() }
            }), WhiteNoiseModParameters.PackageId); 
    }
}