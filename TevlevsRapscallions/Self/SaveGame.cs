// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.SaveGame
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

#nullable disable
namespace TevlevsRapscallions
{
  public static class SaveGame
  {
    public const string ModID = "SaltTestNPC";
    public const string FileName = "GameData";
    public static Dictionary<string, bool> SaveConfigNames;

    private static string baseSave
    {
      get
      {
        return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
      }
    }

    private static string pathPlus
    {
      get
      {
        if (!Directory.Exists(SaveGame.baseSave + "Mods\\"))
          Directory.CreateDirectory(SaveGame.baseSave + "Mods\\");
        return SaveGame.baseSave + "Mods\\";
      }
    }

    public static string SavePath
    {
      get
      {
        if (!Directory.Exists(SaveGame.pathPlus + "SaltTestNPC\\"))
          Directory.CreateDirectory(SaveGame.pathPlus + "SaltTestNPC\\");
        return SaveGame.pathPlus + "SaltTestNPC\\";
      }
    }

    public static string SaveName
    {
      get
      {
        if (!File.Exists(SaveGame.SavePath + "GameData.config"))
          SaveGame.WriteConfig(SaveGame.SavePath + "GameData.config");
        return SaveGame.SavePath + "GameData.config";
      }
    }

    public static void WriteConfig(string location)
    {
      StreamWriter text = File.CreateText(location);
      XmlDocument xmlDocument = new XmlDocument();
      string str = "<config";
      foreach (string key in SaveGame.SaveConfigNames.Keys)
      {
        str += " ";
        str += key;
        str += "='";
        str += SaveGame.SaveConfigNames[key].ToString().ToLower();
        str += "'";
      }
      string xml = str + "> </config>";
      xmlDocument.LoadXml(xml);
      xmlDocument.Save((TextWriter) text);
      text.Close();
    }

    public static bool Check(string name)
    {
      if (SaveGame.SaveConfigNames == null)
        SaveGame.SaveConfigNames = new Dictionary<string, bool>();
      string saveName = SaveGame.SaveName;
      bool flag = false;
      FileStream inStream = File.Open(SaveGame.SaveName, FileMode.Open);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load((Stream) inStream);
      if (xmlDocument.GetElementsByTagName("config").Count > 0)
      {
        if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
          flag = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
        if (!SaveGame.SaveConfigNames.Keys.Contains<string>(name))
          SaveGame.SaveConfigNames.Add(name, flag);
        else
          SaveGame.SaveConfigNames[name] = flag;
      }
      inStream.Close();
      return flag;
    }

    public static void Set(string name, bool value)
    {
      if (SaveGame.Check(name) == value)
        return;
      SaveGame.SaveConfigNames[name] = value;
      SaveGame.WriteConfig(SaveGame.SaveName);
    }

    public static void Setup()
    {
    }
  }
}
