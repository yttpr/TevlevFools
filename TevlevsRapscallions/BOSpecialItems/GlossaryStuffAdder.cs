// Decompiled with JetBrains decompiler
// Type: BOSpecialItems.GlossaryStuffAdder
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using TevlevsRapscallions;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace BOSpecialItems
{
    [HarmonyPatch]
    public static class GlossaryStuffAdder
    {
        public static GlossaryDataBase glossaryDB;
        private static readonly List<StatusEffectInfoSO> queuedStatus = new List<StatusEffectInfoSO>();
        private static readonly List<SlotStatusEffectInfoSO> queuedField = new List<SlotStatusEffectInfoSO>();
        private static readonly List<GlossaryPassives> queuedPassives = new List<GlossaryPassives>();
        private static readonly List<GlossaryKeywords> queuedKeywords = new List<GlossaryKeywords>();

        [HarmonyPatch]
        [HarmonyPatch]
        [HarmonyPatch]
        [HarmonyPatch]
        [HarmonyPrefix]
        private static void CatchUp(GlossaryDataBase __instance)
        {
            if (!((Object)GlossaryStuffAdder.glossaryDB == (Object)null))
                return;
            GlossaryStuffAdder.glossaryDB = __instance;
            List<StatusEffectInfoSO> second1 = new List<StatusEffectInfoSO>();
            List<SlotStatusEffectInfoSO> second2 = new List<SlotStatusEffectInfoSO>();
            foreach (StatusEffectInfoSO queuedStatu in GlossaryStuffAdder.queuedStatus)
            {
                bool flag = true;
                foreach (StatusEffectInfoSO statu in GlossaryStuffAdder.glossaryDB._status)
                {
                    if (statu.statusEffectType == queuedStatu.statusEffectType)
                        flag = false;
                }
                if (flag)
                    second1.Add(queuedStatu);
            }
            foreach (SlotStatusEffectInfoSO statusEffectInfoSo in GlossaryStuffAdder.queuedField)
            {
                bool flag = true;
                foreach (SlotStatusEffectInfoSO field in GlossaryStuffAdder.glossaryDB._fields)
                {
                    if (field.slotStatusEffectType == statusEffectInfoSo.slotStatusEffectType)
                        flag = false;
                }
                if (flag)
                    second2.Add(statusEffectInfoSo);
            }
            GlossaryStuffAdder.glossaryDB._status = ((IEnumerable<StatusEffectInfoSO>)GlossaryStuffAdder.glossaryDB._status).Concat<StatusEffectInfoSO>((IEnumerable<StatusEffectInfoSO>)second1).ToArray<StatusEffectInfoSO>();
            GlossaryStuffAdder.glossaryDB._fields = ((IEnumerable<SlotStatusEffectInfoSO>)GlossaryStuffAdder.glossaryDB._fields).Concat<SlotStatusEffectInfoSO>((IEnumerable<SlotStatusEffectInfoSO>)second2).ToArray<SlotStatusEffectInfoSO>();
            GlossaryStuffAdder.glossaryDB._passives = ((IEnumerable<GlossaryPassives>)GlossaryStuffAdder.glossaryDB._passives).Concat<GlossaryPassives>((IEnumerable<GlossaryPassives>)GlossaryStuffAdder.queuedPassives).ToArray<GlossaryPassives>();
            GlossaryStuffAdder.glossaryDB._keywords = ((IEnumerable<GlossaryKeywords>)GlossaryStuffAdder.glossaryDB._keywords).Concat<GlossaryKeywords>((IEnumerable<GlossaryKeywords>)GlossaryStuffAdder.queuedKeywords).ToArray<GlossaryKeywords>();
            GlossaryStuffAdder.queuedStatus.Clear();
            GlossaryStuffAdder.queuedField.Clear();
            GlossaryStuffAdder.queuedPassives.Clear();
            GlossaryStuffAdder.queuedKeywords.Clear();
        }

        [HarmonyPatch(typeof(GlossaryListUIPanel), "TryInitializeStatus")]
        [HarmonyPrefix]
        private static void AddExtraStatusIconsIfNeeded(
          GlossaryListUIPanel __instance,
          StatusEffectInfoSO[] status)
        {
            if (__instance._initialized)
                return;
            if (status.Length > __instance._icons.Length)
            {
                List<GlossaryIconUILayout> list = ((IEnumerable<GlossaryIconUILayout>)__instance._icons).ToList<GlossaryIconUILayout>();
                int num = status.Length - __instance._icons.Length;
                for (int index = 0; index < num; ++index)
                    list.Add(Object.Instantiate<GlossaryIconUILayout>(list[0], ((Component)list[0]).transform.parent));
                __instance._icons = list.ToArray();
                (((Component)__instance).transform as RectTransform).sizeDelta = new Vector2(0.0f, (float)(284.0 + 105.0 * (double)Mathf.Max(Mathf.CeilToInt((float)list.Count / 8f) - 3, 0)));
            }
            if ((Object)((Component)__instance).GetComponent<HorizontalLayoutGroup>() != (Object)null)
            {
                Object.DestroyImmediate((Object)((Component)__instance).GetComponent<HorizontalLayoutGroup>());
                ((Component)__instance).gameObject.AddComponent<GridLayoutGroup>().cellSize = new Vector2(118.5f, 105f);
            }
            if ((Object)((Component)__instance).transform.parent != (Object)null && ((Object)((Component)__instance).transform.parent.parent == (Object)null || (Object)((Component)__instance).transform.parent.parent.GetComponent<ScrollRect>() == (Object)null))
            {
                float y = 410f;
                ((Component)__instance).transform.parent.Find("StatusTitleText (TMP)").localPosition = new Vector3(25f, y);
                GameObject gameObject1 = new GameObject("Scroll View");
                gameObject1.AddComponent<RectTransform>();
                gameObject1.transform.SetParent(((Component)__instance).transform.parent, false);
                GameObject gameObject2 = new GameObject("Viewport");
                RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
                gameObject2.transform.SetParent(gameObject1.transform, false);
                gameObject2.AddComponent<Image>();
                gameObject2.AddComponent<Mask>().showMaskGraphic = false;
                rectTransform.sizeDelta = new Vector2(1000f, 315f);
                ((Component)__instance).transform.SetParent(gameObject2.transform, false);
                Image image = gameObject1.AddComponent<Image>();
                Texture2D texture = ResourceLoader.LoadTexture("UINineSliceTest_3");
                image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float)texture.width, (float)texture.height), new Vector2(0.5f, 0.5f), 100f, 0U, SpriteMeshType.Tight, new Vector4(9f, 9f, 9f, 9f));
                image.pixelsPerUnitMultiplier = 0.05f;
                image.type = (Image.Type)1;
                ScrollRect scrollRect = gameObject1.AddComponent<ScrollRect>();
                scrollRect.content = ((Component)__instance).transform as RectTransform;
                scrollRect.viewport = gameObject2.transform as RectTransform;
                scrollRect.horizontal = false;
                scrollRect.vertical = true;
                scrollRect.movementType = (ScrollRect.MovementType)1;
                ((Component)scrollRect).transform.localPosition = new Vector3(-28f, y - 50f);
                (((Component)scrollRect).transform as RectTransform).sizeDelta = new Vector2(1025f, 340f);
                (((Component)scrollRect).transform as RectTransform).pivot = new Vector2(0.5f, 1f);
                scrollRect.scrollSensitivity = 10f;
                scrollRect.movementType = (ScrollRect.MovementType)2;
                (((Component)__instance).transform as RectTransform).pivot = new Vector2(0.5f, 1f);
            }
        }

        [HarmonyPatch(typeof(GlossaryListUIPanel), "TryInitializeField")]
        [HarmonyPrefix]
        private static void AddExtraFieldIconsIfNeeded(
          GlossaryListUIPanel __instance,
          SlotStatusEffectInfoSO[] fields)
        {
            if (__instance._initialized)
                return;
            if (fields.Length > __instance._icons.Length)
            {
                List<GlossaryIconUILayout> list = ((IEnumerable<GlossaryIconUILayout>)__instance._icons).ToList<GlossaryIconUILayout>();
                int num = fields.Length - __instance._icons.Length;
                for (int index = 0; index < num; ++index)
                    list.Add(Object.Instantiate<GlossaryIconUILayout>(list[0], ((Component)list[0]).transform.parent));
                __instance._icons = list.ToArray();
                (((Component)__instance).transform as RectTransform).sizeDelta = new Vector2(0.0f, (float)(284.0 + 105.0 * (double)Mathf.Max(Mathf.CeilToInt((float)list.Count / 8f) - 3, 0)));
            }
            if ((Object)((Component)__instance).GetComponent<HorizontalLayoutGroup>() != (Object)null)
            {
                Object.DestroyImmediate((Object)((Component)__instance).GetComponent<HorizontalLayoutGroup>());
                ((Component)__instance).gameObject.AddComponent<GridLayoutGroup>().cellSize = new Vector2(118.5f, 105f);
            }
            if ((Object)((Component)__instance).transform.parent != (Object)null && ((Object)((Component)__instance).transform.parent.parent == (Object)null || (Object)((Component)__instance).transform.parent.parent.GetComponent<ScrollRect>() == (Object)null))
            {
                float y = -50f;
                ((Component)__instance).transform.parent.Find("FieldTitleText (TMP)").localPosition = new Vector3(25f, y);
                GameObject gameObject1 = new GameObject("Scroll View");
                gameObject1.AddComponent<RectTransform>();
                gameObject1.transform.SetParent(((Component)__instance).transform.parent, false);
                GameObject gameObject2 = new GameObject("Viewport");
                RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
                gameObject2.transform.SetParent(gameObject1.transform, false);
                gameObject2.AddComponent<Image>();
                gameObject2.AddComponent<Mask>().showMaskGraphic = false;
                rectTransform.sizeDelta = new Vector2(1000f, 315f);
                ((Component)__instance).transform.SetParent(gameObject2.transform, false);
                Image image = gameObject1.AddComponent<Image>();
                Texture2D texture = ResourceLoader.LoadTexture("UINineSliceTest_3");
                image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float)texture.width, (float)texture.height), new Vector2(0.5f, 0.5f), 100f, 0U, SpriteMeshType.Tight, new Vector4(9f, 9f, 9f, 9f));
                image.pixelsPerUnitMultiplier = 0.05f;
                image.type = (Image.Type)1;
                ScrollRect scrollRect = gameObject1.AddComponent<ScrollRect>();
                scrollRect.content = ((Component)__instance).transform as RectTransform;
                scrollRect.viewport = gameObject2.transform as RectTransform;
                scrollRect.horizontal = false;
                scrollRect.vertical = true;
                scrollRect.movementType = (ScrollRect.MovementType)1;
                ((Component)scrollRect).transform.localPosition = new Vector3(-28f, y - 50f);
                (((Component)scrollRect).transform as RectTransform).sizeDelta = new Vector2(1025f, 340f);
                (((Component)scrollRect).transform as RectTransform).pivot = new Vector2(0.5f, 1f);
                scrollRect.scrollSensitivity = 10f;
                scrollRect.movementType = (ScrollRect.MovementType)2;
                (((Component)__instance).transform as RectTransform).pivot = new Vector2(0.5f, 1f);
            }
        }

        [HarmonyPatch(typeof(GlossaryListUIPanel), "TryInitializePassive")]
        [HarmonyPrefix]
        private static void AddExtraPassiveIconsIfNeeded(
          GlossaryListUIPanel __instance,
          GlossaryPassives[] passives)
        {
            if (!__instance._initialized && passives.Length > __instance._icons.Length)
            {
                List<GlossaryIconUILayout> list = ((IEnumerable<GlossaryIconUILayout>)__instance._icons).ToList<GlossaryIconUILayout>();
                int num = passives.Length - __instance._icons.Length;
                for (int index = 0; index < num; ++index)
                    list.Add(Object.Instantiate<GlossaryIconUILayout>(list[list.Count - 1], ((Component)list[list.Count - 1]).transform.parent));
                __instance._icons = list.ToArray();
                (!((Object)((Component)__instance).transform.Find("Scroll View") == (Object)null) ? ((Component)__instance).transform.transform.Find("Scroll View").Find("Viewport").Find("IconZone") as RectTransform : ((Component)__instance).transform.Find("IconZone") as RectTransform).sizeDelta = new Vector2(0.0f, (float)(515.0 + 81.5 * (double)Mathf.Max(Mathf.CeilToInt((float)list.Count / 9f) - 10, 0)));
            }
            if (!((Object)((Component)__instance).transform.Find("Scroll View") == (Object)null))
                return;
            float y = 410f;
            ((Component)__instance).transform.Find("TitleText (TMP)").localPosition = new Vector3(25f, y);
            Transform parent = ((Component)__instance).transform.Find("IconZone");
            GameObject gameObject1 = new GameObject("Scroll View");
            gameObject1.AddComponent<RectTransform>();
            gameObject1.transform.SetParent(((Component)__instance).transform, false);
            GameObject gameObject2 = new GameObject("Viewport");
            RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
            gameObject2.transform.SetParent(gameObject1.transform, false);
            gameObject2.AddComponent<Image>();
            gameObject2.AddComponent<Mask>().showMaskGraphic = false;
            rectTransform.sizeDelta = new Vector2(1000f, 750f);
            parent.SetParent(gameObject2.transform, false);
            Image image = gameObject1.AddComponent<Image>();
            Texture2D texture = ResourceLoader.LoadTexture("UINineSliceTest_3");
            image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float)texture.width, (float)texture.height), new Vector2(0.5f, 0.5f), 100f, 0U, SpriteMeshType.Tight, new Vector4(9f, 9f, 9f, 9f));
            image.pixelsPerUnitMultiplier = 0.05f;
            image.type = (Image.Type)1;
            ScrollRect scrollRect = gameObject1.AddComponent<ScrollRect>();
            scrollRect.content = parent as RectTransform;
            scrollRect.viewport = gameObject2.transform as RectTransform;
            scrollRect.horizontal = false;
            scrollRect.vertical = true;
            scrollRect.movementType = (ScrollRect.MovementType)1;
            ((Component)scrollRect).transform.localPosition = new Vector3(-28f, y - 50f);
            (((Component)scrollRect).transform as RectTransform).sizeDelta = new Vector2(1025f, 800f);
            (((Component)scrollRect).transform as RectTransform).pivot = new Vector2(0.5f, 1f);
            scrollRect.scrollSensitivity = 10f;
            scrollRect.movementType = (ScrollRect.MovementType)2;
            (parent as RectTransform).pivot = new Vector2(0.5f, 1f);
            Object.DestroyImmediate((Object)parent.GetComponent<VerticalLayoutGroup>());
            GridLayoutGroup gridLayoutGroup = parent.gameObject.AddComponent<GridLayoutGroup>();
            gridLayoutGroup.cellSize = new Vector2(81.5f, 81.5f);
            gridLayoutGroup.spacing = new Vector2(25.2f, 0.0f);
            List<Transform> transformList1 = new List<Transform>();
            List<Transform> transformList2 = new List<Transform>();
            for (int index1 = 0; index1 < parent.childCount; ++index1)
            {
                for (int index2 = 0; index2 < parent.GetChild(index1).childCount; ++index2)
                    transformList1.Add(parent.GetChild(index1).GetChild(index2));
                transformList2.Add(parent.GetChild(index1));
            }
            foreach (Component component in transformList1)
                component.transform.SetParent(parent, false);
            foreach (Component component in transformList2)
                Object.Destroy((Object)component.gameObject);
        }

        [HarmonyPatch(typeof(GlossaryListUIPanel), "TryInitializeKeyword")]
        [HarmonyPrefix]
        private static void AddExtraKeywordIconsIfNeeded(
          GlossaryListUIPanel __instance,
          GlossaryKeywords[] keywords)
        {
            if (!__instance._initialized && keywords.Length > __instance._icons.Length)
            {
                List<GlossaryIconUILayout> list = ((IEnumerable<GlossaryIconUILayout>)__instance._icons).ToList<GlossaryIconUILayout>();
                int num = keywords.Length - __instance._icons.Length;
                for (int index = 0; index < num; ++index)
                    list.Add(Object.Instantiate<GlossaryIconUILayout>(list[0], ((Component)list[0]).transform.parent));
                __instance._icons = list.ToArray();
                (!((Object)((Component)__instance).transform.Find("Scroll View") == (Object)null) ? ((Component)__instance).transform.transform.Find("Scroll View").Find("Viewport").Find("IconZone") as RectTransform : ((Component)__instance).transform.Find("IconZone") as RectTransform).sizeDelta = new Vector2(0.0f, (float)(372.0 + 56.099998474121094 * (double)Mathf.Max(list.Count - 14, 0)));
            }
            if (!((Object)((Component)__instance).transform.Find("Scroll View") == (Object)null))
                return;
            float y = 410f;
            ((Component)__instance).transform.Find("TitleText (TMP)").localPosition = new Vector3(25f, y);
            Transform transform = ((Component)__instance).transform.Find("IconZone");
            GameObject gameObject1 = new GameObject("Scroll View");
            gameObject1.AddComponent<RectTransform>();
            gameObject1.transform.SetParent(((Component)__instance).transform, false);
            GameObject gameObject2 = new GameObject("Viewport");
            RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
            gameObject2.transform.SetParent(gameObject1.transform, false);
            gameObject2.AddComponent<Image>();
            gameObject2.AddComponent<Mask>().showMaskGraphic = false;
            rectTransform.sizeDelta = new Vector2(1000f, 750f);
            transform.SetParent(gameObject2.transform, false);
            Image image = gameObject1.AddComponent<Image>();
            Texture2D texture = ResourceLoader.LoadTexture("UINineSliceTest_3");
            image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float)texture.width, (float)texture.height), new Vector2(0.5f, 0.5f), 100f, 0U, SpriteMeshType.Tight, new Vector4(9f, 9f, 9f, 9f));
            image.pixelsPerUnitMultiplier = 0.05f;
            image.type = (Image.Type)1;
            ScrollRect scrollRect = gameObject1.AddComponent<ScrollRect>();
            scrollRect.content = transform as RectTransform;
            scrollRect.viewport = gameObject2.transform as RectTransform;
            scrollRect.horizontal = false;
            scrollRect.vertical = true;
            scrollRect.movementType = (ScrollRect.MovementType)1;
            ((Component)scrollRect).transform.localPosition = new Vector3(-28f, y - 50f);
            (((Component)scrollRect).transform as RectTransform).sizeDelta = new Vector2(1025f, 800f);
            (((Component)scrollRect).transform as RectTransform).pivot = new Vector2(0.5f, 1f);
            scrollRect.scrollSensitivity = 10f;
            scrollRect.movementType = (ScrollRect.MovementType)2;
            (transform as RectTransform).pivot = new Vector2(0.5f, 1f);
            ((HorizontalOrVerticalLayoutGroup)transform.GetComponent<VerticalLayoutGroup>()).childControlHeight = false;
            ((HorizontalOrVerticalLayoutGroup)transform.GetComponent<VerticalLayoutGroup>()).childForceExpandHeight = false;
            ((HorizontalOrVerticalLayoutGroup)transform.GetComponent<VerticalLayoutGroup>()).childScaleHeight = false;
            for (int index = 0; index < transform.childCount; ++index)
                (transform.GetChild(index) as RectTransform).sizeDelta = new Vector2(0.0f, 56.1f);
        }

        public static void AddStatus(StatusEffectInfoSO info)
        {
            if ((Object)GlossaryStuffAdder.glossaryDB != (Object)null)
            {
                bool flag = true;
                foreach (StatusEffectInfoSO statu in GlossaryStuffAdder.glossaryDB._status)
                {
                    if (statu.statusEffectType == info.statusEffectType)
                        flag = false;
                }
                if (!flag)
                    return;
                GlossaryStuffAdder.glossaryDB._status = CollectionExtensions.AddToArray<StatusEffectInfoSO>(GlossaryStuffAdder.glossaryDB._status, info);
            }
            else
                GlossaryStuffAdder.queuedStatus.Add(info);
        }

        public static void AddField(SlotStatusEffectInfoSO info)
        {
            if ((Object)GlossaryStuffAdder.glossaryDB != (Object)null)
            {
                bool flag = true;
                foreach (SlotStatusEffectInfoSO field in GlossaryStuffAdder.glossaryDB._fields)
                {
                    if (field.slotStatusEffectType == info.slotStatusEffectType)
                        flag = false;
                }
                if (!flag)
                    return;
                GlossaryStuffAdder.glossaryDB._fields = CollectionExtensions.AddToArray<SlotStatusEffectInfoSO>(GlossaryStuffAdder.glossaryDB._fields, info);
            }
            else
                GlossaryStuffAdder.queuedField.Add(info);
        }

        public static void AddKeyword(string kwName, string description)
        {
            GlossaryKeywords glossaryKeywords = new GlossaryKeywords()
            {
                _keyword = kwName,
                _description = description,
                glossaryID = (GlossaryLocID) (- 1)
            };
            if ((Object)GlossaryStuffAdder.glossaryDB != (Object)null)
                GlossaryStuffAdder.glossaryDB._keywords = CollectionExtensions.AddToArray<GlossaryKeywords>(GlossaryStuffAdder.glossaryDB._keywords, glossaryKeywords);
            else
                GlossaryStuffAdder.queuedKeywords.Add(glossaryKeywords);
        }

        public static void AddPassive(string name, string description, string sprite)
        {
            GlossaryPassives glossaryPassives = new GlossaryPassives()
            {
                _name = name,
                _description = description,
                sprite = ResourceLoader.LoadSprite(sprite),
                glossaryID = (GlossaryLocID) (- 1)
            };
            if ((Object)GlossaryStuffAdder.glossaryDB != (Object)null)
                GlossaryStuffAdder.glossaryDB._passives = CollectionExtensions.AddToArray<GlossaryPassives>(GlossaryStuffAdder.glossaryDB._passives, glossaryPassives);
            else
                GlossaryStuffAdder.queuedPassives.Add(glossaryPassives);
        }
    }
}
