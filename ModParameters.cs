using System.Collections.Generic;
using BigDLL4221.BaseClass;
using BigDLL4221.Models;

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

        public static MechUtilBase WhiteNoiseUtil = new MechUtilBase(new MechUtilBaseModel(
            personalCards: new Dictionary<LorId, PersonalCardOptions>
            {
                { new LorId(PackageId, 11), new PersonalCardOptions(onPlayCard: true) },
                { new LorId(PackageId, 12), new PersonalCardOptions(onPlayCard: true) },
                { new LorId(PackageId, 13), new PersonalCardOptions(onPlayCard: true) },
                { new LorId(PackageId, 14), new PersonalCardOptions(onPlayCard: true) }
            }));
    }
}