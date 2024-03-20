// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.GilbertAction
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class GilbertAction : CombatAction
  {
    public IUnit caster;
    public string ability;
    public EnemyCombat[] enemies;

    public GilbertAction(IUnit caster, string ability, EnemyCombat[] enemies)
    {
      this.caster = caster;
      this.ability = ability;
      this.enemies = enemies;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      List<int> ids = new List<int>();
      List<bool> chara = new List<bool>();
      List<string> text = new List<string>();
      List<Sprite> images = new List<Sprite>();
      ids.Add(this.caster.ID);
      chara.Add(this.caster.IsUnitCharacter);
      text.Add(ShitBurg.Gilby._passiveName);
      images.Add(ShitBurg.Gilby.passiveIcon);
      EnemyCombat[] enemyCombatArray1 = this.enemies;
      for (int index = 0; index < enemyCombatArray1.Length; ++index)
      {
        EnemyCombat enemy = enemyCombatArray1[index];
        if (enemy.ContainsPassiveAbility(GilbertPassiveStuff.Gilb) && enemy.CurrentHealth > 0)
        {
          ids.Add(enemy.ID);
          chara.Add(enemy.IsUnitCharacter);
          text.Add(ShitBurg.Gilby._passiveName);
          images.Add(ShitBurg.Gilby.passiveIcon);
        }
        enemy = (EnemyCombat) null;
      }
      enemyCombatArray1 = (EnemyCombat[]) null;
      if (ids.Count > 0)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowMultiplePassiveInformationUIAction(ids.ToArray(), chara.ToArray(), text.ToArray(), images.ToArray()));
      EnemyCombat[] enemyCombatArray2 = this.enemies;
      for (int index = 0; index < enemyCombatArray2.Length; ++index)
      {
        EnemyCombat enemy = enemyCombatArray2[index];
        if (enemy.ContainsPassiveAbility(GilbertPassiveStuff.Gilb) && enemy.CurrentHealth > 0)
          CombatManager.Instance.AddSubAction((CombatAction) new AddGilbertSpecificAbilityEnemyTimelineAction(enemy, this.ability));
        enemy = (EnemyCombat) null;
      }
      enemyCombatArray2 = (EnemyCombat[]) null;
      yield return (object) null;
    }
  }
}
