// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AllySlots
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class AllySlots
  {
    public static BaseCombatTargettingSO Self;
    public static BaseCombatTargettingSO SelfLeftRight;
    public static BaseCombatTargettingSO LeftRight;
    public static BaseCombatTargettingSO Right;
    public static BaseCombatTargettingSO Left;
    public static BaseCombatTargettingSO SelfLeft;
    public static BaseCombatTargettingSO SelfRight;
    public static BaseCombatTargettingSO AllPartyMembers;

    public static void Setup()
    {
      AllySlots.Self = LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[1].ability.animationTarget;
      Targetting_BySlot_Index instance1 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance1.slotPointerDirections = new int[2]{ -1, 1 };
      instance1.getAllies = true;
      AllySlots.LeftRight = (BaseCombatTargettingSO) instance1;
      Targetting_BySlot_Index instance2 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance2.slotPointerDirections = new int[3]
      {
        -1,
        0,
        1
      };
      instance2.getAllies = true;
      AllySlots.SelfLeftRight = (BaseCombatTargettingSO) instance2;
      Targetting_BySlot_Index instance3 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance3.slotPointerDirections = new int[1]{ -1 };
      instance3.getAllies = true;
      AllySlots.Left = (BaseCombatTargettingSO) instance3;
      Targetting_BySlot_Index instance4 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance4.slotPointerDirections = new int[1]{ 1 };
      instance4.getAllies = true;
      AllySlots.Right = (BaseCombatTargettingSO) instance4;
      Targetting_BySlot_Index instance5 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance5.slotPointerDirections = new int[2]{ -1, 0 };
      instance5.getAllies = true;
      AllySlots.SelfLeft = (BaseCombatTargettingSO) instance5;
      Targetting_BySlot_Index instance6 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance6.slotPointerDirections = new int[2]{ 1, 0 };
      instance6.getAllies = true;
      AllySlots.SelfRight = (BaseCombatTargettingSO) instance6;
      Targetting_BySlot_Index instance7 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance7.slotPointerDirections = new int[9]
      {
        4,
        3,
        2,
        1,
        0,
        -1,
        -2,
        -3,
        -4
      };
      instance7.getAllies = true;
      AllySlots.AllPartyMembers = (BaseCombatTargettingSO) instance7;
    }
  }
}
