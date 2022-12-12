using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using MonoMod.Utils;
using UnityEngine;

namespace TheWhiteNoiseProject
{
    public class WhiteNoiseInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(WhiteNoiseModParameters.Path + "/ArtWork"));
            ArtUtil.GetSpeedDieArtWorks(new DirectoryInfo(WhiteNoiseModParameters.Path + "/CustomDiceArtWork"));
            ArtUtil.PreLoadBufIcons();
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, WhiteNoiseModParameters.PackageId);
            KeypageUtil.ChangeKeypageItem(BookXmlList.Instance, WhiteNoiseModParameters.PackageId);
            PassiveUtil.ChangePassiveItem(WhiteNoiseModParameters.PackageId);
            LocalizeUtil.AddGlobalLocalize(WhiteNoiseModParameters.PackageId);
            ArtUtil.MakeCustomBook(WhiteNoiseModParameters.PackageId);
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
            ModParameters.Assemblies.Add(Assembly.GetExecutingAssembly());
            OnInitSprites();
            OnInitSkins();
            OnInitKeypages();
            OnInitCards();
            OnInitPassives();
            OnInitRewards();
            OnInitCredenza();
            OnInitCustomSkins();
        }
        private static void OnInitCustomSkins()
        {
            ModParameters.CustomBookSkinsOptions.Add(WhiteNoiseModParameters.PackageId, new List<CustomBookSkinsOption>
            {
                new CustomBookSkinsOption("HeadlessWhiteNoise_md5488", 10000002)
            });
        }
        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(WhiteNoiseModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "WhiteNoiseDefault_md5488"),
                new SpriteOptions(SpriteEnum.Custom, 10000002, "WhiteNoiseDefault_md5488")
            });
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(new Dictionary<LorId, int>
                {
                    { new LorId(WhiteNoiseModParameters.PackageId, 1), 0 }
                }, null,
                new List<LorId> { new LorId(WhiteNoiseModParameters.PackageId, 10000001) }
            ));
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(WhiteNoiseModParameters.PackageId, new List<CardOptions>
            {
                new CardOptions(1, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(2, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(3, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(4, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(5, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(6, CardOption.NoInventory,
                   cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(7, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(8, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(9, CardOption.NoInventory,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(10, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(11, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(12, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(13, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White)),
                new CardOptions(14, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(Color.white, iconColor: HSVColors.White))
            });
        }

        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(WhiteNoiseModParameters.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(1, false, passiveColorOptions: new PassiveColorOptions(Color.white, Color.white)),
                new PassiveOptions(2, false),
                new PassiveOptions(3, false),
                new PassiveOptions(4, cannotBeUsedWithPassives: new List<LorId> { new LorId(260004) }),
                new PassiveOptions(5, false)
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(WhiteNoiseModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001, isDeckFixed: true, everyoneCanEquip: true,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(Color.white, Color.white)),

                new KeypageOptions(10000002, isDeckFixed: true, everyoneCanEquip: true, bookCustomOptions: new BookCustomOptions())
            });
        }

        private static void OnInitSkins()
        {
            ModParameters.SkinOptions.AddRange(new Dictionary<string, SkinOptions>
            {
                {
                    "TheWhiteNoise_md5488", new SkinOptions(WhiteNoiseModParameters.PackageId,
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
                            { MotionDetail.S14, new MotionSound("StigmaDual.wav") },
                            { MotionDetail.S8, new MotionSound("Wedge_Stab.wav") },
                            { MotionDetail.S9, new MotionSound("Wedge_Stab.wav") },
                            { MotionDetail.S10, new MotionSound("Roland_ShortSword.wav") },
                            { MotionDetail.S15, new MotionSound("Roland_Duralandal_Stong", isBaseSoundWin: true) },
                        })
                },

                {
                    "HeadlessWhiteNoise_md5488", new SkinOptions(WhiteNoiseModParameters.PackageId,
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
                            { MotionDetail.S14, new MotionSound("StigmaDual.wav") },
                            { MotionDetail.S8, new MotionSound("Wedge_Stab.wav") },
                            { MotionDetail.S9, new MotionSound("Wedge_Stab.wav") },
                            { MotionDetail.S10, new MotionSound("Roland_ShortSword.wav") },
                            { MotionDetail.S15, new MotionSound("Roland_Duralandal_Stong", isBaseSoundWin: true) },
                        })
                }
            });
        }

        private static void OnInitCredenza()
        {
            ModParameters.CredenzaOptions.Add(WhiteNoiseModParameters.PackageId,
                new CredenzaOptions(customIconSpriteId: "White_Noise_Icon_md5488", credenzaName: "The White Noise",bookDataColor:new CredenzaColorOptions(Color.white,Color.white)));
        }
    }
}