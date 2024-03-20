// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Gilfects
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
    public static class Gilfects
    {
        private static DamageEffect _damage;
        private static HealEffect _healNorm;
        private static PreviousEffectCondition _didThat;
        private static HealEffect _healExit;
        private static HalveMaxHealthEffect _halveMax;
        private static ConsumeRandomManaEffect _consumePig;
        private static TargettingByGilbert _gilbAlly;
        private static TargettingByGilbert _gilbEny;
        private static MultiTargetting _allGilb;
        private static ReverseTargetting _faceOtrGilb;
        private static ExtraVariableForNextEffect _empty;
        private static IsFrontCondition _isFront;
        private static IsFrontCondition _isntFront;
        private static AnimationVisualsEffect _bash;
        private static AnimationVisualsEffect _huff;

        public static DamageEffect Damage
        {
            get
            {
                if ((Object)Gilfects._damage == (Object)null)
                    Gilfects._damage = ScriptableObject.CreateInstance<DamageEffect>();
                return Gilfects._damage;
            }
        }

        public static HealEffect HealNorm
        {
            get
            {
                if ((Object)Gilfects._healNorm == (Object)null)
                    Gilfects._healNorm = ScriptableObject.CreateInstance<HealEffect>();
                return Gilfects._healNorm;
            }
        }

        public static PreviousEffectCondition DidThat
        {
            get
            {
                if ((Object)Gilfects._didThat == (Object)null)
                {
                    Gilfects._didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
                    Gilfects._didThat.wasSuccessful = true;
                }
                return Gilfects._didThat;
            }
        }

        public static HealEffect HealExit
        {
            get
            {
                if ((Object)Gilfects._healExit == (Object)null)
                {
                    Gilfects._healExit = ScriptableObject.CreateInstance<HealEffect>();
                    Gilfects._healExit.usePreviousExitValue = true;
                }
                return Gilfects._healExit;
            }
        }

        public static HalveMaxHealthEffect HalveMax
        {
            get
            {
                if ((Object)Gilfects._halveMax == (Object)null)
                    Gilfects._halveMax = ScriptableObject.CreateInstance<HalveMaxHealthEffect>();
                return Gilfects._halveMax;
            }
        }

        public static ConsumeRandomManaEffect ConsumePig
        {
            get
            {
                if ((Object)Gilfects._consumePig == (Object)null)
                    Gilfects._consumePig = ScriptableObject.CreateInstance<ConsumeRandomManaEffect>();
                return Gilfects._consumePig;
            }
        }

        public static TargettingByGilbert GilbAlly
        {
            get
            {
                if ((Object)Gilfects._gilbAlly == (Object)null)
                {
                    Gilfects._gilbAlly = ScriptableObject.CreateInstance<TargettingByGilbert>();
                    Gilfects._gilbAlly.getAllUnitSlots = false;
                    Gilfects._gilbAlly.getAllies = true;
                }
                return Gilfects._gilbAlly;
            }
        }

        public static TargettingByGilbert GilbEny
        {
            get
            {
                if ((Object)Gilfects._gilbEny == (Object)null)
                {
                    Gilfects._gilbEny = ScriptableObject.CreateInstance<TargettingByGilbert>();
                    Gilfects._gilbEny.getAllUnitSlots = false;
                    Gilfects._gilbEny.getAllies = false;
                }
                return Gilfects._gilbEny;
            }
        }

        public static MultiTargetting AllGilb
        {
            get
            {
                if ((Object)Gilfects._allGilb == (Object)null)
                    Gilfects._allGilb = MultiTargetting.Create((BaseCombatTargettingSO)Gilfects.GilbAlly, (BaseCombatTargettingSO)Gilfects.GilbEny);
                return Gilfects._allGilb;
            }
        }

        public static ReverseTargetting FaceOtrGilb
        {
            get
            {
                if ((Object)Gilfects._faceOtrGilb == (Object)null)
                {
                    Gilfects._faceOtrGilb = ScriptableObject.CreateInstance<ReverseTargetting>();
                    Gilfects._faceOtrGilb.source = (BaseCombatTargettingSO)Gilfects.GilbEny;
                    Gilfects._faceOtrGilb.secondary = Slots.FrontLeftRight;
                }
                return Gilfects._faceOtrGilb;
            }
        }

        public static ExtraVariableForNextEffect Empty
        {
            get
            {
                if ((Object)Gilfects._empty == (Object)null)
                    Gilfects._empty = ScriptableObject.CreateInstance<ExtraVariableForNextEffect>();
                return Gilfects._empty;
            }
        }

        public static IsFrontCondition IsFront
        {
            get
            {
                if ((Object)Gilfects._isFront == (Object)null)
                {
                    Gilfects._isFront = ScriptableObject.CreateInstance<IsFrontCondition>();
                    Gilfects._isFront.HasUnit = true;
                }
                return Gilfects._isFront;
            }
        }

        public static IsFrontCondition IsntFront
        {
            get
            {
                if ((Object)Gilfects._isntFront == (Object)null)
                {
                    Gilfects._isntFront = ScriptableObject.CreateInstance<IsFrontCondition>();
                    Gilfects._isntFront.HasUnit = false;
                }
                return Gilfects._isntFront;
            }
        }

        public static AnimationVisualsEffect Bash
        {
            get
            {
                if ((Object)Gilfects._bash == (Object)null)
                {
                    Gilfects._bash = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                    Gilfects._bash._visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
                    Gilfects._bash._animationTarget = (BaseCombatTargettingSO)Gilfects.FaceOtrGilb;
                }
                return Gilfects._bash;
            }
        }

        public static AnimationVisualsEffect Huff
        {
            get
            {
                if ((Object)Gilfects._huff == (Object)null)
                {
                    Gilfects._huff = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                    Gilfects._huff._visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;
                    Gilfects._huff._animationTarget = Slots.Front;
                }
                return Gilfects._huff;
            }
        }
    }
}
