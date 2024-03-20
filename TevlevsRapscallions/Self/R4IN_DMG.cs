// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.R4IN_DMG
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class R4IN_DMG
  {
    public static void Add()
    {
      Connection_PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Construct (3)";
      ((BasePassiveAbilitySO) instance).passiveIcon = Passives.Construct.passiveIcon;
      ((BasePassiveAbilitySO) instance)._characterDescription = "Add 3 random item abilities at the beginning of combat.";
      ((BasePassiveAbilitySO) instance)._enemyDescription = ((BasePassiveAbilitySO) instance)._characterDescription;
      ((BasePassiveAbilitySO) instance).type = Passives.Construct.type;
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 1000
      };
      ((BasePassiveAbilitySO) instance).conditions = new EffectorConditionSO[0];
      instance.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<AddExtraAbilitiesEffect>(), 3, new IntentType?(), Slots.Self)
      });
      instance.disconnectionEffects = new EffectInfo[0];
      Character character = new Character()
      {
        name = "R4IN-DMG",
        entityID = (EntityIDs) (GilbertPassiveStuff.Gilb - 178),
        healthColor = Pigments.Yellow,
        passives = new BasePassiveAbilitySO[1]
        {
          (BasePassiveAbilitySO) instance
        },
        frontSprite = ResourceLoader.LoadSprite("RainDamageFront.png"),
        backSprite = ResourceLoader.LoadSprite("RainDamageBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("RainDamageOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        lockedSprite = ResourceLoader.LoadSprite("RainDamageMenu.png")
      };
      character.unlockedSprite = character.lockedSprite;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Doll_CH").damageSound;
      character.deathSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Doll_CH").dxSound;
      character.levels = new CharacterRankedData[1];
      character.walksInOverworld = true;
      character.isSupport = false;
      character.isSecret = false;
      character.appearsInShops = false;
      character.usesAllAbilities = true;
      character.usesBaseAbility = false;
      character.menuChar = false;
      character.AddLevel(16, new Ability[0], 0);
      character.AddCharacter();
    }
  }
}
