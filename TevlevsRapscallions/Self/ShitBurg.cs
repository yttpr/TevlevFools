// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.ShitBurg
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class ShitBurg
  {
    public static string[] Gilberts = new string[4]
    {
      "Shitfuck_EN",
      "Shatterfuck_EN",
      "Shitterfucker_EN",
      "SuperMarioInRealLife_EN"
    };
    public static Character ItHim;
    private static BasePassiveAbilitySO _gilby;
    private static Ability _fakeSlap;
    private static EnemyInFieldLayout _bilbert;
    private static ParticleSystem _giblert;
    private static Ability _schizoid;
    private static Sprite _liquid;
    private static Sprite _baloo;
    private static Sprite _pyre;
    private static Effect _refreshDid;
    private static bool _rdMade = false;

    public static void Lev1()
    {
      Enemy enemy = new Enemy()
      {
        name = "Gilbert",
        health = Random.Range(1, 100),
        size = 1,
        entityID = (EntityIDs) 3936108,
        healthColor = Pigments.Red,
        priority = 0,
        prefab = ShitBurg.Bilbert
      };
      enemy.prefab._gibs = ShitBurg.Giblert;
      enemy.prefab.SetDefaultParams();
      enemy.enemyID = ShitBurg.Gilberts[0];
      enemy.combatSprite = ResourceLoader.LoadSprite("GilbertIcon.png");
      enemy.overworldAliveSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.overworldDeadSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      enemy.deathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;
      enemy.abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
      enemy.passives = new BasePassiveAbilitySO[2]
      {
        ShitBurg.Gilby,
        Passives.Withering
      };
      enemy.exitEffects = new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<GilbertExitEffect>(), 1, new IntentType?(), Slots.Self)
      };
      Ability ability1 = new Ability();
      ability1.name = "Liquid Pummel";
      ability1.description = "Deal a Painful amount of damage to the Left and Right enemies.";
      ability1.rarity = 5;
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ShitBurg.Liquid;
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
      ability1.animationTarget = Slots.Sides;
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect( Gilfects.Damage, 6, new IntentType?((IntentType) 1), Slots.Sides);
      Ability ability2 = new Ability();
      ability2.name = "Baloooo Bibidy";
      ability2.description = "Consume 6 random Pigment from the Pigment tray. Deal a Painful amount of damage to the enemies to the Left, Right, and Opposition of Gilbert.";
      ability2.rarity = 5;
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability2.sprite = ShitBurg.Baloo;
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;
      ability2.animationTarget = (BaseCombatTargettingSO) Gilfects.AllGilb;
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect( Gilfects.ConsumePig, 6, new IntentType?((IntentType) 61), Slots.Self);
      ability2.effects[2] = new Effect( Gilfects.Damage, 4, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) Gilfects.FaceOtrGilb);
      ability2.effects[1] = new Effect( Gilfects.Bash, 1, new IntentType?((IntentType) 100), (BaseCombatTargettingSO) Gilfects.GilbEny);
      enemy.abilities = new Ability[4]
      {
        ShitBurg.FakeSlap,
        ability1,
        ability2,
        ShitBurg.Schizoid
      };
      enemy.AddEnemy();
    }

    public static void Lev2()
    {
      Enemy enemy = new Enemy()
      {
        name = "Gilbert",
        health = Random.Range(1, 100),
        size = 1,
        entityID = (EntityIDs) 3936148,
        healthColor = Pigments.Red,
        priority = 0,
        prefab = ShitBurg.Bilbert
      };
      enemy.prefab._gibs = ShitBurg.Giblert;
      enemy.prefab.SetDefaultParams();
      enemy.enemyID = ShitBurg.Gilberts[1];
      enemy.combatSprite = ResourceLoader.LoadSprite("GilbertIcon.png");
      enemy.overworldAliveSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.overworldDeadSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      enemy.deathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;
      enemy.abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
      enemy.passives = new BasePassiveAbilitySO[2]
      {
        ShitBurg.Gilby,
        Passives.Withering
      };
      enemy.exitEffects = new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<GilbertExitEffect>(), 1, new IntentType?(), Slots.Self)
      };
      Ability ability1 = new Ability();
      ability1.name = "Liquid Fists";
      ability1.description = "Deal a Agonizing amount of damage to the Left and Right enemies.";
      ability1.rarity = 5;
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ShitBurg.Liquid;
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
      ability1.animationTarget = Slots.Sides;
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect( Gilfects.Damage, 8, new IntentType?((IntentType) 2), Slots.Sides);
      Ability ability2 = new Ability();
      ability2.name = "Baloooo Vavedour";
      ability2.description = "Consume 6 random Pigment from the Pigment tray. Deal a Painful amount of damage to the enemies to the Left, Right, and Opposition of Gilbert.";
      ability2.rarity = 5;
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability2.sprite = ShitBurg.Baloo;
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;
      ability2.animationTarget = (BaseCombatTargettingSO) Gilfects.AllGilb;
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect( Gilfects.ConsumePig, 6, new IntentType?((IntentType) 61), Slots.Self);
      ability2.effects[2] = new Effect( Gilfects.Damage, 5, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) Gilfects.FaceOtrGilb);
      ability2.effects[1] = new Effect( Gilfects.Bash, 1, new IntentType?((IntentType) 100), (BaseCombatTargettingSO) Gilfects.GilbEny);
      enemy.abilities = new Ability[4]
      {
        ShitBurg.FakeSlap,
        ability1,
        ability2,
        ShitBurg.Schizoid
      };
      enemy.AddEnemy();
    }

    public static void Lev3()
    {
      Enemy enemy = new Enemy()
      {
        name = "Gilbert",
        health = Random.Range(1, 100),
        size = 1,
        entityID = (EntityIDs) 3936748,
        healthColor = Pigments.Red,
        priority = 0,
        prefab = ShitBurg.Bilbert
      };
      enemy.prefab._gibs = ShitBurg.Giblert;
      enemy.prefab.SetDefaultParams();
      enemy.enemyID = ShitBurg.Gilberts[2];
      enemy.combatSprite = ResourceLoader.LoadSprite("GilbertIcon.png");
      enemy.overworldAliveSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.overworldDeadSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      enemy.deathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;
      enemy.abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
      enemy.passives = new BasePassiveAbilitySO[2]
      {
        ShitBurg.Gilby,
        Passives.Withering
      };
      enemy.exitEffects = new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<GilbertExitEffect>(), 1, new IntentType?(), Slots.Self)
      };
      Ability ability1 = new Ability();
      ability1.name = "Liquid Strike";
      ability1.description = "Deal a Agonizing amount of damage to the Left and Right enemies.";
      ability1.rarity = 5;
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ShitBurg.Liquid;
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
      ability1.animationTarget = Slots.Sides;
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect( Gilfects.Damage, 10, new IntentType?((IntentType) 2), Slots.Sides);
      Ability ability2 = new Ability();
      ability2.name = "Baloooo Elemas";
      ability2.description = "Consume 6 random Pigment from the Pigment tray. Deal a Painful amount of damage to the enemies to the Left, Right, and Opposition of Gilbert.";
      ability2.rarity = 5;
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability2.sprite = ShitBurg.Baloo;
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;
      ability2.animationTarget = (BaseCombatTargettingSO) Gilfects.AllGilb;
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect( Gilfects.ConsumePig, 6, new IntentType?((IntentType) 61), Slots.Self);
      ability2.effects[2] = new Effect( Gilfects.Damage, 6, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) Gilfects.FaceOtrGilb);
      ability2.effects[1] = new Effect( Gilfects.Bash, 1, new IntentType?((IntentType) 100), (BaseCombatTargettingSO) Gilfects.GilbEny);
      enemy.abilities = new Ability[4]
      {
        ShitBurg.FakeSlap,
        ability1,
        ability2,
        ShitBurg.Schizoid
      };
      enemy.AddEnemy();
    }

    public static void Lev4()
    {
      Enemy enemy = new Enemy()
      {
        name = "Gilbert",
        health = Random.Range(1, 100),
        size = 1,
        entityID = (EntityIDs) 3932748,
        healthColor = Pigments.Red,
        priority = 0,
        prefab = ShitBurg.Bilbert
      };
      enemy.prefab._gibs = ShitBurg.Giblert;
      enemy.prefab.SetDefaultParams();
      enemy.enemyID = ShitBurg.Gilberts[3];
      enemy.combatSprite = ResourceLoader.LoadSprite("GilbertIcon.png");
      enemy.overworldAliveSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.overworldDeadSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      enemy.deathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;
      enemy.abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
      enemy.passives = new BasePassiveAbilitySO[2]
      {
        ShitBurg.Gilby,
        Passives.Withering
      };
      enemy.exitEffects = new Effect[1]
      {
        new Effect( ScriptableObject.CreateInstance<GilbertExitEffect>(), 1, new IntentType?(), Slots.Self)
      };
      Ability ability1 = new Ability();
      ability1.name = "Liquid Beatwodn";
      ability1.description = "Deal a Deadly amount of damage to the Left and Right enemies.";
      ability1.rarity = 5;
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ShitBurg.Liquid;
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
      ability1.animationTarget = Slots.Sides;
      ability1.effects = new Effect[1];
      ability1.effects[0] = new Effect( Gilfects.Damage, 12, new IntentType?((IntentType) 3), Slots.Sides);
      Ability ability2 = new Ability();
      ability2.name = "Baloooo Bephelement";
      ability2.description = "Consume 6 random Pigment from the Pigment tray. Deal a Agonizing amount of damage to the enemies to the Left, Right, and Opposition of Gilbert.";
      ability2.rarity = 5;
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability2.sprite = ShitBurg.Baloo;
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;
      ability2.animationTarget = (BaseCombatTargettingSO) Gilfects.AllGilb;
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect( Gilfects.ConsumePig, 6, new IntentType?((IntentType) 61), Slots.Self);
      ability2.effects[2] = new Effect( Gilfects.Damage, 8, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) Gilfects.FaceOtrGilb);
      ability2.effects[1] = new Effect( Gilfects.Bash, 1, new IntentType?((IntentType) 100), (BaseCombatTargettingSO) Gilfects.GilbEny);
      enemy.abilities = new Ability[4]
      {
        ShitBurg.FakeSlap,
        ability1,
        ability2,
        ShitBurg.Schizoid
      };
      enemy.AddEnemy();
    }

    public static void Add()
    {
      PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Gilbert";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ShitBurg.Gilby.passiveIcon;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = ShitBurg.Gilby._enemyDescription;
      ((BasePassiveAbilitySO) instance1)._characterDescription = "This party member is Gilbert. When this party member performs an action, Gilbert will attempt to copy it. \nGilbert deals 50% less damage to Gilbert. \nWhen Gilbert dies, their max health will be returned to this party member.";
      ((BasePassiveAbilitySO) instance1).type = GilbertPassiveStuff.Gilb;
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[2]
      {
        (TriggerCalls) 30,
        GilbertPassiveStuff.extra
      };
      ((BasePassiveAbilitySO) instance1).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<GilbertCondition>()
      };
      instance1.effects = new EffectInfo[0];
      Character character = new Character()
      {
        name = "Gilbert",
        entityID = (EntityIDs) (GilbertPassiveStuff.Gilb - 1331),
        healthColor = Pigments.Red,
        passives = new BasePassiveAbilitySO[1]
        {
          (BasePassiveAbilitySO) instance1
        },
        frontSprite = ResourceLoader.LoadSprite("GilbertFront.png"),
        backSprite = ResourceLoader.LoadSprite("GilbertBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("GilbertOverworld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        lockedSprite = ResourceLoader.LoadSprite("GilbertMenu.png")
      };
      character.unlockedSprite = character.lockedSprite;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;
      character.dialogueSound = character.hurtSound;
      character.walksInOverworld = true;
      character.isSupport = false;
      character.isSecret = false;
      character.appearsInShops = true;
      character.usesAllAbilities = false;
      character.usesBaseAbility = true;
      character.menuChar = true;
      PreviousEffectCondition instance2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance2.wasSuccessful = false;
      PreviousEffectCondition instance3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance3.wasSuccessful = true;
      instance3.previousAmount = 2;
      MultiCondition condition1 = MultiCondition.Create(new EffectConditionSO[2]
      {
         instance3,
         Conditions.Chance(40)
      });
      MultiCondition condition2 = MultiCondition.Create(new EffectConditionSO[2]
      {
         instance3,
         Conditions.Chance(50)
      });
      MultiCondition condition3 = MultiCondition.Create(new EffectConditionSO[2]
      {
         instance3,
         Conditions.Chance(60)
      });
      MultiCondition condition4 = MultiCondition.Create(new EffectConditionSO[2]
      {
         instance3,
         Conditions.Chance(65)
      });
      RestoreSwapUseEffect instance4 = ScriptableObject.CreateInstance<RestoreSwapUseEffect>();
      Effect effect1 = new Effect( instance4, 1, new IntentType?((IntentType) 40), Slots.Self,  condition1);
      Effect effect2 = new Effect( instance4, 1, new IntentType?((IntentType) 40), Slots.Self,  condition2);
      Effect effect3 = new Effect( instance4, 1, new IntentType?((IntentType) 40), Slots.Self,  condition3);
      Effect effect4 = new Effect( instance4, 1, new IntentType?((IntentType) 40), Slots.Self,  condition4);
      Ability ability1 = new Ability(); 
      ability1.name = "Liquid Pummel";
      ability1.description = "If there is an Opposing enemy, deal 6 damage to them. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability1.rarity = 5;
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ShitBurg.Liquid;
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
      ability1.animationTarget = Slots.Front;
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect( Gilfects.Damage, 6, new IntentType?((IntentType) 1), Slots.Front,  Gilfects.IsFront);
      ability1.effects[1] = new Effect( Gilfects.HalveMax, 1, new IntentType?((IntentType) 82), Slots.Self,  MultiCondition.Create(new EffectConditionSO[2]
      {
         instance2,
         Gilfects.IsntFront
      }));
      ability1.effects[2] = new Effect( ScriptableObject.CreateInstance<SpawnGilbertEnemyInSlotFromEntryEffect>(), 0, new IntentType?((IntentType) 83), Slots.Front,  Gilfects.DidThat);
      ability1.effects[3] = ShitBurg.RefreshDid;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Liquid Fists";
      ability2.description = "If there is an Opposing enemy, deal 8 damage to them. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability2.effects[0]._entryVariable = 8;
      ability2.effects[0]._intent = new IntentType?((IntentType) 2);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Liquid Strike";
      ability3.description = "If there is an Opposing enemy, deal 10 damage to them. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability3.effects[0]._entryVariable = 10;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Liquid Beatwodn";
      ability4.description = "If there is an Opposing enemy, deal 12 damage to them. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability4.effects[0]._entryVariable = 12;
      ability4.effects[0]._intent = new IntentType?((IntentType) 3);
      Ability ability5 = new Ability();
      ability5.name = "Baloooo Bibidy";
      ability5.description = "If there is an Opposing enemy, deal 3 damage to them and heal this character the amount of damage dealt. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability5.rarity = 5;
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Yellow
      };
      ability5.sprite = ShitBurg.Baloo;
      ability5.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
      ability5.animationTarget = Slots.Front;
      ability5.effects = new Effect[5];
      ability5.effects[0] = new Effect( Gilfects.Huff, 1, new IntentType?((IntentType) 20), Slots.Self);
      ability5.effects[1] = new Effect( ScriptableObject.CreateInstance<LeechDamageEffect>(), 3, new IntentType?((IntentType) 1), Slots.Front,  Gilfects.IsFront);
      ability5.effects[2] = new Effect( Gilfects.HalveMax, 1, new IntentType?((IntentType) 82), Slots.Self,  MultiCondition.Create(new EffectConditionSO[2]
      {
         instance2,
         Gilfects.IsntFront
      }));
      ability5.effects[3] = new Effect( ScriptableObject.CreateInstance<SpawnGilbertEnemyInSlotFromEntryEffect>(), 0, new IntentType?((IntentType) 83), Slots.Front,  Gilfects.DidThat);
      ability5.effects[4] = ShitBurg.RefreshDid;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Baloooo Vavedour";
      ability6.description = "If there is an Opposing enemy, deal 4 damage to them and heal this character the amount of damage dealt. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow)
      };
      ability6.effects[1]._entryVariable = 4;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Baloooo Elemas";
      ability7.description = "If there is an Opposing enemy, deal 5 damage to them and heal this character the amount of damage dealt. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability7.effects[1]._entryVariable = 5;
      ability7.effects[0]._intent = new IntentType?((IntentType) 21);
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Baloooo Bephelement";
      ability8.description = "If there is an Opposing enemy, deal 6 damage to them and heal this character the amount of damage dealt. \nOtherwise, halve this party member's maximum health and summon a Gilbert, refreshing this party member's ability usage if successful.";
      ability8.effects[1]._entryVariable = 6;
      Ability ability9 = new Ability();
      ability9.name = "Corpse Pyre";
      ability9.description = "Increase this party member's maximum health by 1. \nIf the Opposing enemy is not Gilbert, destroy all Gilberts and deal damage to the Opposing enemy equivalent to the combined maximum health of all Gilberts destroyed. \nHeal this party member 4 health.";
      ability9.rarity = 5;
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability9.sprite = ShitBurg.Pyre;
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Amalgam_1_A").visuals;
      ability9.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create(Slots.Self, (BaseCombatTargettingSO) ScriptableObject.CreateInstance<ConditionTargettingByGilbert>());
      ability9.effects = new Effect[5];
      ability9.effects[0] = new Effect( ScriptableObject.CreateInstance<ChangeMaxHealthEffect>(), 1, new IntentType?((IntentType) 81), Slots.Self);
      ability9.effects[1] = new Effect( Gilfects.Empty, 0, new IntentType?((IntentType) 100), Slots.Front);
      ability9.effects[2] = new Effect( Gilfects.Empty, 0, new IntentType?((IntentType) 6), (BaseCombatTargettingSO) Gilfects.GilbEny);
      ability9.effects[3] = new Effect( ScriptableObject.CreateInstance<DamageByGilbertEffect>(), 1, new IntentType?((IntentType) 4), Slots.Front);
      ability9.effects[4] = new Effect( CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect( Gilfects.HealNorm, 4, new IntentType?(), Slots.Self)
      }), 1, new IntentType?((IntentType) 20), Slots.Self);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Fluids Pyre";
      ability10.description = "Increase this party member's maximum health by 1. \nIf the Opposing enemy is not Gilbert, destroy all Gilberts and deal damage to the Opposing enemy equivalent to the combined maximum health of all Gilberts destroyed. \nHeal this party member 5 health.";
      ability10.effects[4]._effect =  CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect( Gilfects.HealNorm, 5, new IntentType?(), Slots.Self)
      });
      ability10.effects[4]._intent = new IntentType?((IntentType) 21);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Gore Pyre";
      ability11.description = "Increase this party member's maximum health by 2. \nIf the Opposing enemy is not Gilbert, destroy all Gilberts and deal damage to the Opposing enemy equivalent to the combined maximum health of all Gilberts destroyed. \nHeal this party member 6 health.";
      ability11.effects[0]._entryVariable = 2;
      ability11.effects[3]._intent = new IntentType?((IntentType) 5);
      ability11.effects[4]._effect =  CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect( Gilfects.HealNorm, 6, new IntentType?(), Slots.Self)
      });
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Funeral Pyre";
      ability12.description = "Increase this party member's maximum health by 3. \nIf the Opposing enemy is not Gilbert, destroy all Gilberts and deal damage to the Opposing enemy equivalent to the combined maximum health of all Gilberts destroyed. \nHeal this party member 7 health.";
      ability12.effects[0]._entryVariable = 3;
      ability12.effects[4]._effect =  CasterRootActionEffect.Create(new Effect[1]
      {
        new Effect( Gilfects.HealNorm, 7, new IntentType?(), Slots.Self)
      });
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
      character.AddLevel(24, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      ShitBurg.ItHim = character;
    }

    public static BasePassiveAbilitySO Gilby
    {
      get
      {
        if (_gilby == null)
        {
          ShitBurg._gilby = Object.Instantiate<BasePassiveAbilitySO>(Passives.Multiattack);
          ShitBurg._gilby._passiveName = "Gilbert";
          ShitBurg._gilby._enemyDescription = "This enemy is Gilbert. This enemy will attempt to copy Gilbert's actions. \nGilbert deals 50% less damage to Gilbert. \nOn death, return this enemy's maximum health back to Gilbert.";
          ShitBurg._gilby.passiveIcon = ResourceLoader.LoadSprite("GilbertPassive.png");
          ShitBurg._gilby.type = GilbertPassiveStuff.Gilb;
          ((IntegerSetterPassiveAbility) ShitBurg._gilby).integerValue = -1;
        }
        return ShitBurg._gilby;
      }
    }

    public static Ability FakeSlap
    {
      get
      {
        if (ShitBurg._fakeSlap == null)
        {
          ShitBurg._fakeSlap = new Ability();
          ShitBurg._fakeSlap.name = "Unintelligible Slap-Like Activities";
          ShitBurg._fakeSlap.description = "Perform a random ability from this enemy's moveset.";
          ShitBurg._fakeSlap.rarity = 5;
          ShitBurg._fakeSlap.cost = new ManaColorSO[1]
          {
            Pigments.Yellow
          };
          ShitBurg._fakeSlap.sprite = LoadedAssetsHandler.GetCharacterAbility("Slap_A").abilitySprite;
          ShitBurg._fakeSlap.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
          ShitBurg._fakeSlap.animationTarget = Slots.Self;
          ShitBurg._fakeSlap.effects = new Effect[2];
          ShitBurg._fakeSlap.effects[0] = new Effect( ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self);
          ShitBurg._fakeSlap.effects[1] = new Effect( ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?(), Slots.Self);
        }
        return ShitBurg._fakeSlap;
      }
    }

    public static EnemyInFieldLayout Bilbert
    {
      get
      {
        if (_bilbert == null)
          ShitBurg._bilbert = PYMNHere.Assets.LoadAsset<GameObject>("Assets/Shitburg/Shitburg_Enemy.prefab").AddComponent<EnemyInFieldLayout>();
        return ShitBurg._bilbert;
      }
    }

    public static ParticleSystem Giblert
    {
      get
      {
        if (_giblert == null)
          ShitBurg._giblert = PYMNHere.Assets.LoadAsset<GameObject>("Assets/Shitburg/Shitburg_Gibs.prefab").GetComponent<ParticleSystem>();
        return ShitBurg._giblert;
      }
    }

    public static Ability Schizoid
    {
      get
      {
        if (ShitBurg._schizoid == null)
        {
          ShitBurg._schizoid = new Ability();
          ShitBurg._schizoid.name = "Schizoid Homunculus";
          ShitBurg._schizoid.description = "This enemy gains Focused and increases its maximum health by 1-2. If there is an available space, halve this enemy's maximum health and summon a Gilbert with an equal amount of health.";
          ShitBurg._schizoid.rarity = 5;
          ShitBurg._schizoid.cost = new ManaColorSO[3]
          {
            Pigments.Red,
            Pigments.Red,
            Pigments.Red
          };
          ShitBurg._schizoid.sprite = ShitBurg.Pyre;
          ShitBurg._schizoid.visuals = LoadedAssetsHandler.GetCharacterAbility("Amalgam_1_A").visuals;
          ShitBurg._schizoid.animationTarget = Slots.Self;
          ShitBurg._schizoid.effects = new Effect[5];
          ShitBurg._schizoid.effects[0] = new Effect( ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?((IntentType) 156), Slots.Self);
          ShitBurg._schizoid.effects[3] = new Effect( Gilfects.HalveMax, 1, new IntentType?((IntentType) 82), Slots.Self,  ScriptableObject.CreateInstance<IsEnemySpaceCondition>());
          ShitBurg._schizoid.effects[4] = new Effect( ScriptableObject.CreateInstance<SpawnSelfGilbertEnemyAnywhereEffect>(), 1, new IntentType?((IntentType) 83), Slots.Self,  Gilfects.DidThat);
          ShitBurg._schizoid.effects[1] = new Effect( ScriptableObject.CreateInstance<ChangeMaxHealthEffect>(), 1, new IntentType?((IntentType) 81), Slots.Self);
          ShitBurg._schizoid.effects[2] = new Effect( ScriptableObject.CreateInstance<ChangeMaxHealthEffect>(), 1, new IntentType?(), Slots.Self,  Conditions.Chance(50));
        }
        return ShitBurg._schizoid;
      }
    }

    public static Sprite Liquid
    {
      get
      {
        if (_liquid == null)
          ShitBurg._liquid = ResourceLoader.LoadSprite("GilbertLiquidSkill.png");
        return ShitBurg._liquid;
      }
    }

    public static Sprite Baloo
    {
      get
      {
        if (_baloo == null)
          ShitBurg._baloo = ResourceLoader.LoadSprite("GilbertBalooSkill.png");
        return ShitBurg._baloo;
      }
    }

    public static Sprite Pyre
    {
      get
      {
        if (_pyre == null)
          ShitBurg._pyre = ResourceLoader.LoadSprite("GilbertPyreSkill.png");
        return ShitBurg._pyre;
      }
    }

    public static Effect RefreshDid
    {
      get
      {
        if (!ShitBurg._rdMade)
        {
          ShitBurg._refreshDid = new Effect( ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self,  Gilfects.DidThat);
          ShitBurg._rdMade = true;
        }
        return ShitBurg._refreshDid;
      }
    }
  }
}
