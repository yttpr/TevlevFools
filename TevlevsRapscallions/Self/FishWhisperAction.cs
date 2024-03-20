// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.FishWhisperAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class FishWhisperAction : CombatAction
  {
    public static Effect[] effects;

    public static void Setup()
    {
      CopyAndSpawnCustomCharacterAnywhereEffect instance = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
      instance._permanentSpawn = true;
      instance._characterCopy = "Mung_CH";
      instance._rank = 0;
      instance._extraModifiers = new WearableStaticModifierSetterSO[0];
      FishWhisperAction.effects = new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
      };
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      if (FishWhisperAction.effects == null)
        FishWhisperAction.Setup();
      bool isWhisper = false;
      List<int> ids = new List<int>();
      List<bool> isChar = new List<bool>();
      List<string> names = new List<string>();
      List<Sprite> sprites = new List<Sprite>();
      foreach (CharacterCombat chara in stats.CharactersOnField.Values)
      {
        if (chara.ContainsPassiveAbility((PassiveAbilityTypes) 89261) && chara.GetStoredValue((UnitStoredValueNames) 89261) <= 0)
        {
          isWhisper = true;
          ids.Add(chara.ID);
          isChar.Add(true);
          names.Add("Fish Whisperer");
          sprites.Add(Carpy.fishySprite);
          chara.SetStoredValue((UnitStoredValueNames) 89261, 1);
        }
      }
      if (isWhisper)
      {
        bool isMung = false;
        List<EnemyCombat> mungs = new List<EnemyCombat>();
        foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
        {
          if (( enemy.Enemy == LoadedAssetsHandler.GetEnemy("Mung_EN")))
          {
            isMung = true;
            mungs.Add(enemy);
          }
        }
        if (isMung)
        {
          CombatManager.Instance.AddUIAction((CombatAction) new ShowMultiplePassiveInformationUIAction(ids.ToArray(), isChar.ToArray(), names.ToArray(), sprites.ToArray()));
          EnemyCombat[] enemyCombatArray = mungs.ToArray();
          for (int index = 0; index < enemyCombatArray.Length; ++index)
          {
            EnemyCombat unit = enemyCombatArray[index];
            CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(FishWhisperAction.effects), (IUnit) unit, 0));
            unit = (EnemyCombat) null;
          }
          enemyCombatArray = (EnemyCombat[]) null;
        }
        mungs = (List<EnemyCombat>) null;
      }
      yield return (object) null;
    }
  }
}
