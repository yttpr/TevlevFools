// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.HasUsableItemCondition
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

#nullable disable
namespace TevlevsRapscallions
{
  public class HasUsableItemCondition : EffectConditionSO
  {
    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return caster is CharacterCombat characterCombat && characterCombat.HasUsableItem;
    }
  }
}
