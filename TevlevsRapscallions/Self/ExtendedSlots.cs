// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ExtendedSlots
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class ExtendedSlots
  {
    public static BaseCombatTargettingSO FarLeftRight;
    public static BaseCombatTargettingSO FarRight;
    public static BaseCombatTargettingSO FarLeft;
    public static BaseCombatTargettingSO FarFarLeftRight;
    public static BaseCombatTargettingSO FarFarRight;
    public static BaseCombatTargettingSO FarFarLeft;
    public static BaseCombatTargettingSO SuperFarLeftRight;
    public static BaseCombatTargettingSO SuperFarRight;
    public static BaseCombatTargettingSO SuperFarLeft;
    public static BaseCombatTargettingSO leftSides;
    public static BaseCombatTargettingSO RightSides;
    public static BaseCombatTargettingSO AllEnemies;

    public static void Setup()
    {
      Targetting_BySlot_Index instance1 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance1.slotPointerDirections = new int[2]{ -2, 2 };
      ExtendedSlots.FarLeftRight = (BaseCombatTargettingSO) instance1;
      Targetting_BySlot_Index instance2 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance2.slotPointerDirections = new int[1]{ -2 };
      ExtendedSlots.FarLeft = (BaseCombatTargettingSO) instance2;
      Targetting_BySlot_Index instance3 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance3.slotPointerDirections = new int[1]{ 2 };
      ExtendedSlots.FarRight = (BaseCombatTargettingSO) instance3;
      Targetting_BySlot_Index instance4 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance4.slotPointerDirections = new int[2]{ -3, 3 };
      ExtendedSlots.FarFarLeftRight = (BaseCombatTargettingSO) instance4;
      Targetting_BySlot_Index instance5 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance5.slotPointerDirections = new int[1]{ -3 };
      ExtendedSlots.FarFarLeft = (BaseCombatTargettingSO) instance5;
      Targetting_BySlot_Index instance6 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance6.slotPointerDirections = new int[1]{ 3 };
      ExtendedSlots.FarFarRight = (BaseCombatTargettingSO) instance6;
      Targetting_BySlot_Index instance7 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance7.slotPointerDirections = new int[2]{ -4, 4 };
      ExtendedSlots.SuperFarLeftRight = (BaseCombatTargettingSO) instance7;
      Targetting_BySlot_Index instance8 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance8.slotPointerDirections = new int[1]{ -4 };
      ExtendedSlots.SuperFarLeft = (BaseCombatTargettingSO) instance8;
      Targetting_BySlot_Index instance9 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance9.slotPointerDirections = new int[1]{ 4 };
      ExtendedSlots.SuperFarRight = (BaseCombatTargettingSO) instance9;
      Targetting_BySlot_Index instance10 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance10.slotPointerDirections = new int[4]
      {
        4,
        3,
        2,
        1
      };
      ExtendedSlots.RightSides = (BaseCombatTargettingSO) instance10;
      Targetting_BySlot_Index instance11 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance11.slotPointerDirections = new int[4]
      {
        -4,
        -3,
        -2,
        -1
      };
      ExtendedSlots.leftSides = (BaseCombatTargettingSO) instance11;
      Targetting_BySlot_Index instance12 = ScriptableObject.CreateInstance(typeof (Targetting_BySlot_Index)) as Targetting_BySlot_Index;
      instance12.slotPointerDirections = new int[9]
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
      ExtendedSlots.AllEnemies = (BaseCombatTargettingSO) instance12;
    }
  }
}
