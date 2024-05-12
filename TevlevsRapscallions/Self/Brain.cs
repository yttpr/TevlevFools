// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Brain
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class Brain
  {
    public static Character Cop;

    public static void Add()
    {
      Character character = new Character();
      character.name = "Brian";
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 879045;
      character.levels = new CharacterRankedData[4];
      character.frontSprite = ResourceLoader.LoadSprite("BrianFront.png");
      character.backSprite = ResourceLoader.LoadSprite("BrianBack.png");
      character.overworldSprite = ResourceLoader.LoadSprite("BrianOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.lockedSprite = ResourceLoader.LoadSprite("BrianMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("BrianMenu");
      character.menuChar = true;
      character.usesBaseAbility = true;
      character.isSupport = false;
      character.usesAllAbilities = false;
      character.appearsInShops = true;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("Mobius_BOSS").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("Mobius_BOSS").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetEnemy("Mobius_BOSS").damageSound;

            ExtraCCSprites_ArraySO brian = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            brian._useDefault = ExtraSpriteType.None;
            brian._useSpecial = (ExtraSpriteType)8384012;
            brian._frontSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("BrianFrontDamaged2.png"),
                ResourceLoader.LoadSprite("BrianFrontDamaged3.png")
            };
            brian._doesLoop = false;
            brian._backSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("BrianBackDamaged2.png"),
                ResourceLoader.LoadSprite("BrianBackDamaged3.png"),
            };
            character.extraSprites = brian;
            SetCasterExtraSpritesEffect hitt = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            hitt._spriteType = (ExtraSpriteType)8384012;

            Ability ability1 = new Ability();
      ability1.sprite = ResourceLoader.LoadSprite("SkillWhack", 1);
      ability1.name = "Cheeky Whack";
      ability1.description = "Deal 3 damage to the Opposing enemy twice.\nApply 2 constricted to the Opposing enemy position.\nDeals 50% more damage against constricted enemies";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 3, new IntentType?((IntentType) 1), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 3, new IntentType?((IntentType) 1), Slots.Front);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, new IntentType?((IntentType) 170), Slots.Front);
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[1].ability.visuals;
      ScriptableObject.CreateInstance<AppyConstrictedSlotRandomRangeEffect>().minrange = 2;
      Ability ability2 = new Ability();
      ability2.sprite = ResourceLoader.LoadSprite("SkillWhack", 1);
      ability2.name = "Miffed Whack";
      ability2.description = "Deal 4 damage to the Opposing enemy twice.\nApply 2 constricted to the Opposing enemy position.\nDeals 50% more damage against constricted enemies";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 4, new IntentType?((IntentType) 1), Slots.Front);
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 4, new IntentType?((IntentType) 1), Slots.Front);
      ability2.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, new IntentType?((IntentType) 170), Slots.Front);
      ability2.animationTarget = Slots.Front;
      ability2.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability3 = new Ability();
      ability3.sprite = ResourceLoader.LoadSprite("SkillWhack", 1);
      ability3.name = "Bloody Whack";
      ability3.description = "Deal 5 damage to the Opposing enemy twice.\nApply 3 constricted to the Opposing enemy position.\nDeals 50% more damage against constricted enemies";
      ability3.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability3.effects = new Effect[3];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front);
      ability3.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 5, new IntentType?((IntentType) 1), Slots.Front);
      ability3.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 3, new IntentType?((IntentType) 170), Slots.Front);
      ability3.animationTarget = Slots.Front;
      ability3.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[1].ability.visuals;
      ScriptableObject.CreateInstance<AppyConstrictedSlotRandomRangeEffect>().minrange = 3;
      Ability ability4 = new Ability();
      ability4.sprite = ResourceLoader.LoadSprite("SkillWhack", 1);
      ability4.name = "Bonkers Whack";
      ability4.description = "Deal 6 damage to the Opposing enemy twice.\nApply 3 constricted to the Opposing enemy position.\nDeals 50% more damage against constricted enemies";
      ability4.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability4.effects = new Effect[3];
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front);
      ability4.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoreDamageIfConstrictedEffect>(), 6, new IntentType?((IntentType) 1), Slots.Front);
      ability4.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 3, new IntentType?((IntentType) 170), Slots.Front);
      ability4.animationTarget = Slots.Front;
      ability4.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[1].ability.visuals;
      Ability ability5 = new Ability();
      ability5.sprite = ResourceLoader.LoadSprite("SkillCannonball", 1);
      ability5.name = "Scant Cannonball";
      ability5.description = "Deal an amount of damage equal to half of this party members current health to the Opposing enemy.\nIf the Opposing enemy is constricted instead deal damage equal to this party member's current health.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageBasedOnHealthIfConstrictedEffect>(), 0, new IntentType?((IntentType) 5), Slots.Front);
            ability5.effects[1] = new Effect(hitt, 1, null, Slots.Front);
      ability5.animationTarget = Slots.Front;
      ability5.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[2].ability.visuals;
      Ability ability6 = new Ability();
      ability6.sprite = ResourceLoader.LoadSprite("SkillCannonball", 1);
      ability6.name = "Chuffed Cannonball";
      ability6.description = "Deal an amount of damage equal to half of this party members current health to the Opposing enemy.\nIf the Opposing enemy is constricted instead deal damage equal to this party member's current health.";
      ability6.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability6.effects = new Effect[2];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageBasedOnHealthIfConstrictedEffect>(), 0, new IntentType?((IntentType) 5), Slots.Front);
            ability6.effects[1] = new Effect(hitt, 1, null, Slots.Front);
            ability6.animationTarget = Slots.Front;
      ability6.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[2].ability.visuals;
      Ability ability7 = new Ability();
      ability7.sprite = ResourceLoader.LoadSprite("SkillCannonball", 1);
      ability7.name = "Peng Cannonball";
      ability7.description = "Deal an amount of damage equal to half of this party members current health to the Opposing enemy.\nIf the Opposing enemy is constricted instead deal damage equal to this party member's current health.";
      ability7.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability7.effects = new Effect[2];
      ability7.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageBasedOnHealthIfConstrictedEffect>(), 0, new IntentType?((IntentType) 5), Slots.Front);
            ability7.effects[1] = new Effect(hitt, 1, null, Slots.Front);
            ability7.animationTarget = Slots.Front;
      ability7.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[2].ability.visuals;
      Ability ability8 = new Ability();
      ability8.sprite = ResourceLoader.LoadSprite("SkillCannonball", 1);
      ability8.name = "Barmy Cannonball";
      ability8.description = "Deal an amount of damage equal to half of this party members current health to the Opposing enemy.\nIf the Opposing enemy is constricted instead deal damage equal to this party member's current health.";
      ability8.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Blue,
        Pigments.Yellow
      };
      ability8.effects = new Effect[2];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageBasedOnHealthIfConstrictedEffect>(), 0, new IntentType?((IntentType) 5), Slots.Front);
            ability8.effects[1] = new Effect(hitt, 1, null, Slots.Front);
            ability8.animationTarget = Slots.Front;
      ability8.visuals = LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN").abilities[2].ability.visuals;
      ApplyConstrictedByHealthEffect instance1 = ScriptableObject.CreateInstance<ApplyConstrictedByHealthEffect>();
      instance1._applyWeakest = false;
      ApplyShieldByHealthEffect instance2 = ScriptableObject.CreateInstance<ApplyShieldByHealthEffect>();
      instance2._applyWeakest = true;
      RandomizeAllManaEffect instance3 = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
      instance3.manaRandomOptions = new ManaColorSO[4]
      {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Red,
        Pigments.Purple
      };
      Ability ability9 = new Ability();
      ability9.sprite = ResourceLoader.LoadSprite("SkillWhistle", 1);
      ability9.name = "Knackered Whistle";
      ability9.description = "Randomize all stored pigment.\nApply 6 shield to the lowest health party member.\nInflict 2 constricted to the highest health enemy's position.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability9.effects = new Effect[3];
      ability9.effects[0] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 62), Slots.Self);
      ability9.effects[1] = new Effect((EffectSO) instance2, 6, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }, true));
      ability9.effects[2] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 170), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }));
      ability9.animationTarget = Slots.Front;
      ability9.visuals = LoadedAssetsHandler.GetCharcater("Agon_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability10 = new Ability();
      ability10.sprite = ResourceLoader.LoadSprite("SkillWhistle", 1);
      ability10.name = "Antwackie Whistle";
      ability10.description = "Randomize all stored pigment.\nApply 8 shield to the lowest health party member.\nInflict 2 constricted to the highest health enemy's position.";
      ability10.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability10.effects = new Effect[3];
      ability10.effects[0] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 62), Slots.Self);
      ability10.effects[1] = new Effect((EffectSO) instance2, 8, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }, true));
      ability10.effects[2] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 170), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }));
      ability10.animationTarget = Slots.Front;
      ability10.visuals = LoadedAssetsHandler.GetCharcater("Agon_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability11 = new Ability();
      ability11.sprite = ResourceLoader.LoadSprite("SkillWhistle", 1);
      ability11.name = "Ace Whistle";
      ability11.description = "Randomize all stored pigment.\nApply 10 shield to the lowest health party member.\nInflict 2 constricted to the highest health enemy's position.";
      ability11.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability11.effects = new Effect[3];
      ability11.effects[0] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 62), Slots.Self);
      ability11.effects[1] = new Effect((EffectSO) instance2, 10, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }, true));
      ability11.effects[2] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 170), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }));
      ability11.animationTarget = Slots.Front;
      ability11.visuals = LoadedAssetsHandler.GetCharcater("Agon_CH").rankedData[0].rankAbilities[0].ability.visuals;
      Ability ability12 = new Ability();
      ability12.sprite = ResourceLoader.LoadSprite("SkillWhistle", 1);
      ability12.name = "Gobby Whistle";
      ability12.description = "Randomize all stored pigment.\nApply 12 shield to the lowest health party member.\nInflict 3 constricted to the highest health enemy's position.";
      ability12.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability12.effects = new Effect[3];
      ability12.effects[0] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 62), Slots.Self);
      ability12.effects[1] = new Effect((EffectSO) instance2, 12, new IntentType?((IntentType) 171), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }, true));
      ability12.effects[2] = new Effect((EffectSO) instance1, 3, new IntentType?((IntentType) 170), Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      }));
      ability12.animationTarget = Slots.Front;
      ability12.visuals = LoadedAssetsHandler.GetCharcater("Agon_CH").rankedData[0].rankAbilities[0].ability.visuals;
      character.AddLevel(16, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(20, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(22, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(26, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Brain.Cop = character;
    }
  }
}
