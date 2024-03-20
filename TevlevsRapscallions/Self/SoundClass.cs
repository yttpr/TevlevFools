// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SoundClass
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using FMODUnity;
using System;
using System.IO;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class SoundClass
  {
    public static void CreateSoundBankFile(string resourceName, bool onlyIfNotExist = false)
    {
      SoundClass.CreateResourceFile(resourceName, Application.dataPath + "/StreamingAssets", resourceName + ".bank", onlyIfNotExist);
    }

    public static void CreateResourceFile(
      string resourceName,
      string path,
      string outputName,
      bool onlyIfNotExist = false)
    {
      byte[] bytes = new byte[0];
      try
      {
        bytes = ResourceLoader.ResourceBinary(resourceName);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) "YOUR FILE DOES NOT EXIST MOTHERFUCKER");
      }
      if (bytes.Length == 0 || onlyIfNotExist && File.Exists(path + "/" + outputName))
        return;
      File.WriteAllBytes(path + "/" + outputName, bytes);
    }

    public static void Setup()
    {
      SoundClass.CreateSoundBankFile("retard");
      SoundClass.CreateSoundBankFile("retard.strings");
      RuntimeManager.LoadBank("retard", true);
      RuntimeManager.LoadBank("retard.strings", true);
    }

    public static int GetGilbertAbilityIDFromName(this EnemyCombat self, string abilityName)
    {
      Debug.Log((object) abilityName);
      for (int index = self.Abilities.Count - 1; index >= 0; --index)
      {
        string abilityName1 = self.Abilities[index].ability._abilityName;
        Debug.Log((object) abilityName1);
        if (abilityName1.Contains("Liquid") && abilityName1.ToCharArray().Length > 10 && abilityName.Contains("Liquid") && abilityName.ToCharArray().Length > 10 || abilityName1.Contains("Baloooo") && abilityName1.ToCharArray().Length > 10 && abilityName.Contains("Baloooo") && abilityName.ToCharArray().Length > 10 || abilityName1 == "Schizoid Homunculus" && abilityName.Contains("Pyre") && abilityName.ToCharArray().Length > 6 || abilityName1.Contains("Slap") && abilityName1.ToCharArray().Length > 30 && abilityName == "Slap" || abilityName == abilityName1)
          return index;
      }
      return self.GetLastAbilityIDFromName(abilityName);
    }
  }
}
