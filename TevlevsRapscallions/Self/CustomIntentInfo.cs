﻿// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.CustomIntentInfo
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public class CustomIntentInfo : IntentInfo
  {
    public string Name;
    public IntentType GetSoundFrom;
    public bool useDamageColors;

    public CustomIntentInfo(string name, IntentType type, Sprite sprite, IntentType SoundSouce)
    {
      this.Name = name;
      this._type = type;
      this._sprite = sprite;
      this._color = Color.white;
      this.GetSoundFrom = SoundSouce;
      this.SetupInternal();
    }

    public CustomIntentInfo(
      string name,
      IntentType type,
      Sprite sprite,
      IntentType SoundSouce,
      Color color)
    {
      this.Name = name;
      this._type = type;
      this._sprite = sprite;
      this._color = color;
      this.GetSoundFrom = SoundSouce;
      this.SetupInternal();
    }

    public CustomIntentInfo(
      string name,
      IntentType type,
      Sprite sprite,
      IntentType SoundSouce,
      bool useDamageColors)
    {
      this.Name = name;
      this._type = type;
      this._sprite = sprite;
      this._color = Color.white;
      this.GetSoundFrom = SoundSouce;
      this.useDamageColors = useDamageColors;
      this.SetupInternal();
    }

    public void SetupInternal()
    {
      CustomIntentIconSystem.Setup();
      CustomIntentIconSystem.TryAddIntent(this.Name, (IntentInfo) this);
    }

    public override Sprite GetSprite(bool isTargetCharacter) => this._sprite;

    public override Color GetColor(bool isTargetCharacter)
    {
      if (!this.useDamageColors || !CustomIntentIconSystem.CanUseDamageColors)
        return this._color;
      return !isTargetCharacter ? CustomIntentIconSystem.DamageRed : CustomIntentIconSystem.DamagePurple;
    }
  }
}
