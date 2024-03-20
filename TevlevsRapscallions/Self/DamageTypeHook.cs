using System;
using System.Reflection;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using MonoMod.RuntimeDetour;
using TMPro;
using UnityEngine;

namespace TevlevsRapscallions
{
    // Token: 0x02000020 RID: 32
    public static class DamageTypeHook
    {
        // Token: 0x06000067 RID: 103 RVA: 0x00007484 File Offset: 0x00005684
        public static Sequence DamageTypeSetter(Func<DamageTextOptions, CombatText, string, int, Sequence> orig, DamageTextOptions self, CombatText textHolder, string text, int type)
        {
            bool flag = type == 866795;
            Sequence result;
            if (flag)
            {
                TMP_ColorGradient tmp_ColorGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                tmp_ColorGradient.bottomLeft = DamageTypeHook.yellow;
                tmp_ColorGradient.bottomRight = DamageTypeHook.red;
                tmp_ColorGradient.topLeft = DamageTypeHook.blue;
                tmp_ColorGradient.topRight = DamageTypeHook.purple;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = tmp_ColorGradient;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<Sequence>(ShortcutExtensions.DOLocalJump(transform, transform.position, self._jumpForce * textHolder.Scale, 1, self._jumpTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence, tween);
                result = sequence;
            }
            else
            {
                result = orig(self, textHolder, text, type);
            }
            return result;
        }

        // Token: 0x06000068 RID: 104 RVA: 0x0000755C File Offset: 0x0000575C
        public static string CustomDamageSound(Func<UnitSoundHandlerSO, DamageType, string> orig, UnitSoundHandlerSO self, DamageType damageType)
        {
            bool flag = damageType == (DamageType)866795;
            string result;
            if (flag)
            {
                result = "event:/BubblePop";
            }
            else
            {
                result = orig(self, damageType);
            }
            return result;
        }

        // Token: 0x06000069 RID: 105 RVA: 0x0000758C File Offset: 0x0000578C
        public static Sequence HealTypeSetter(Func<HealTextOptions, CombatText, string, int, Sequence> orig, HealTextOptions self, CombatText textHolder, string text, int type)
        {
            bool flag = type == 866795;
            Sequence result;
            if (flag)
            {
                TMP_ColorGradient tmp_ColorGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                tmp_ColorGradient.bottomLeft = DamageTypeHook.yellow;
                tmp_ColorGradient.bottomRight = DamageTypeHook.red;
                tmp_ColorGradient.topLeft = DamageTypeHook.blue;
                tmp_ColorGradient.topRight = DamageTypeHook.purple;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = tmp_ColorGradient;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMove(transform, transform.localPosition + transform.up * self._healYEnd * textHolder.Scale, self._moveTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence, tween);
                result = sequence;
            }
            else
            {
                result = orig(self, textHolder, text, type);
            }
            return result;
        }

        // Token: 0x0600006A RID: 106 RVA: 0x00007674 File Offset: 0x00005874
        public static string CustomHealSound(Func<UnitSoundHandlerSO, HealType, string> orig, UnitSoundHandlerSO self, HealType healType)
        {
            bool flag = healType == (HealType)866795;
            string result;
            if (flag)
            {
                result = "event:/BubblePop";
            }
            else
            {
                result = orig(self, healType);
            }
            return result;
        }

        // Token: 0x0600006B RID: 107 RVA: 0x000076A4 File Offset: 0x000058A4
        public static void Add()
        {
            IDetour detour = new Hook(typeof(DamageTextOptions).GetMethod("PrepareTextOptions", (BindingFlags)(-1)), typeof(DamageTypeHook).GetMethod("DamageTypeSetter", (BindingFlags)(-1)));
            IDetour detour2 = new Hook(typeof(UnitSoundHandlerSO).GetMethod("TryGetDamageEventName", (BindingFlags)(-1)), typeof(DamageTypeHook).GetMethod("CustomDamageSound", (BindingFlags)(-1)));
            IDetour detour3 = new Hook(typeof(HealTextOptions).GetMethod("PrepareTextOptions", (BindingFlags)(-1)), typeof(DamageTypeHook).GetMethod("HealTypeSetter", (BindingFlags)(-1)));
            IDetour detour4 = new Hook(typeof(UnitSoundHandlerSO).GetMethod("TryGetHealEventName", (BindingFlags)(-1)), typeof(DamageTypeHook).GetMethod("CustomHealSound", (BindingFlags)(-1)));
            DamageTypeHook.yellow = new Color32(238, 195, 51, byte.MaxValue);
            DamageTypeHook.red = new Color32(217, 45, 54, byte.MaxValue);
            DamageTypeHook.blue = new Color32(63, 103, 143, byte.MaxValue);
            DamageTypeHook.purple = new Color32(139, 72, 164, byte.MaxValue);
        }

        // Token: 0x04000050 RID: 80
        public static Color32 yellow;

        // Token: 0x04000051 RID: 81
        public static Color32 red;

        // Token: 0x04000052 RID: 82
        public static Color32 blue;

        // Token: 0x04000053 RID: 83
        public static Color32 purple;
    }
}
