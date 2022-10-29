using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;

namespace TheWhiteNoiseProject
{
    public class WhiteNoiseInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(WhiteNoiseModParameters.Path + "/ArtWork"));
            ArtUtil.PreLoadBufIcons();
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, WhiteNoiseModParameters.PackageId);
            KeypageUtil.ChangeKeypageItem(BookXmlList.Instance, WhiteNoiseModParameters.PackageId);
            PassiveUtil.ChangePassiveItem(WhiteNoiseModParameters.PackageId);
            LocalizeUtil.AddGlobalLocalize(WhiteNoiseModParameters.PackageId);
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
            CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());
        }

        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(WhiteNoiseModParameters.PackageId);
            WhiteNoiseModParameters.Path = Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(WhiteNoiseModParameters.PackageId, WhiteNoiseModParameters.Path);
            OnInitSprites();
            OnInitKeypages();
            OnInitCards();
            OnInitPassives();
            OnInitRewards();
            OnInitCredenza();
        }

        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(WhiteNoiseModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "WhiteNoiseDefault_md5488")
            });
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(null, null,
                new List<LorId> { new LorId(WhiteNoiseModParameters.PackageId, 10000001) }));
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(WhiteNoiseModParameters.PackageId, new List<CardOptions>
            {
                new CardOptions(10, CardOption.Personal)
            });
        }

        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(WhiteNoiseModParameters.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(1, true)
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(WhiteNoiseModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001, isDeckFixed: true, everyoneCanEquip: true,
                    bookCustomOptions: new BookCustomOptions("Roland", originalSkin: "TheWhiteNoise_md5488",
                        motionSounds: new Dictionary<MotionDetail, MotionSound>
                        {
                            { MotionDetail.S1, new MotionSound("Chainsaw1.wav") },
                            { MotionDetail.S2, new MotionSound("Chainsaw2.wav") },
                            { MotionDetail.S3, new MotionSound("ChainsawBlock.wav") },
                            { MotionDetail.Z, new MotionSound("Roland_DuelSword_Strong", isBaseSoundWin: true) },
                            { MotionDetail.G, new MotionSound("Roland_Guard", isBaseSoundWin: true) },
                            { MotionDetail.H, new MotionSound("Roland_Mace", isBaseSoundWin: true) },
                            { MotionDetail.S4, new MotionSound("RevolverShot.ogg") },
                            { MotionDetail.S5, new MotionSound("RevolverShot.ogg") },
                            { MotionDetail.F, new MotionSound("SniperShot.ogg") },
                            { MotionDetail.S6, new MotionSound("Roland_Duralandal_Down", isBaseSoundWin: true) },
                            { MotionDetail.S7, new MotionSound("Roland_Duralandal_Up", isBaseSoundWin: true) },
                            { MotionDetail.S11, new MotionSound("Blue_Argalria_Strong_Atk1", isBaseSoundWin: true) },
                            { MotionDetail.S12, new MotionSound("Blue_Argalria_Strong_Atk2", isBaseSoundWin: true) },
                            { MotionDetail.S13, new MotionSound("StigmaMace.wav") },
                            { MotionDetail.J, new MotionSound("StigmaAxe.wav") },
                            { MotionDetail.S14, new MotionSound("StigmaDual.wav") }
                        }))
            });
        }

        private static void OnInitCredenza()
        {
            ModParameters.CredenzaOptions.Add(WhiteNoiseModParameters.PackageId,
                new CredenzaOptions(baseIconSpriteId: "Chapter1", credenzaName: "The White Noise"));
        }
    }
}