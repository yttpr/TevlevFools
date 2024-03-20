// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CopyAndSpawnCustomCharacterSameSlotEffect
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using Tools;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class CopyAndSpawnCustomCharacterSameSlotEffect : EffectSO
  {
    [Header("Rank Data")]
    [CharacterRef]
    [SerializeField]
    public string _characterCopy = "";
    [SerializeField]
    public int _rank;
    [SerializeField]
    public NameAdditionLocID _nameAddition;
    [SerializeField]
    public bool _permanentSpawn;
    [SerializeField]
    public bool _usePreviousAsHealth;
    [SerializeField]
    public WearableStaticModifierSetterSO[] _extraModifiers = new WearableStaticModifierSetterSO[0];

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      CharacterSO charcater = LoadedAssetsHandler.GetCharcater(this._characterCopy);
      if (( charcater == null) || charcater.Equals((object) null))
        return false;
      int num1 = this._usePreviousAsHealth ? Mathf.Max(1, this.PreviousExitValue) : charcater.GetMaxHealth(this._rank);
      int num2;
      int num3;
      charcater.GenerateAbilities(out num2, out num3);
      WearableStaticModifiers wearableStaticModifiers = new WearableStaticModifiers();
      foreach (WearableStaticModifierSetterSO extraModifier in this._extraModifiers)
        extraModifier.OnAttachedToCharacter(wearableStaticModifiers, charcater, this._rank);
      string nameAdditionData = LocUtils.LocDB.GetNameAdditionData(this._nameAddition);
      for (int index = 0; index < entryVariable; ++index)
        CombatManager.Instance.AddSubAction((CombatAction) new SpawnCharacterAction(charcater, caster.SlotID, true, nameAdditionData, this._permanentSpawn, this._rank, num2, num3, num1, wearableStaticModifiers));
      exitAmount = entryVariable;
      return true;
    }
  }
}
