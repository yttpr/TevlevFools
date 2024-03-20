// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Config
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BepInEx;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

#nullable disable
namespace TevlevsRapscallions
{
  public static class Config
  {
    public const string FolderName = "SaltTestNPC";
    public const string FileName = "GameData";
    public const bool Default = true;
    public static Dictionary<string, bool> SaveConfigNames;

    public static void TryWriteConfig() => Config.WriteConfig(Config.SaveName);

    public static void ExampleAwake()
    {
      if (!Config.Check("AddMisterOne"))
        ;
      if (!Config.Check("AddMisterTwo"))
        ;
      if (!Config.Check("AddMisterThree"))
        ;
      Config.TryWriteConfig();
    }

    public static void WriteConfig(string location)
    {
      StreamWriter text = File.CreateText(location);
      XmlDocument xmlDocument = new XmlDocument();
      string str = "<config";
      foreach (string key in Config.SaveConfigNames.Keys)
      {
        str += " ";
        str += key;
        str += "='";
        str += Config.SaveConfigNames[key].ToString().ToLower();
        str += "'";
      }
      string xml = str + "> </config>";
      xmlDocument.LoadXml(xml);
      xmlDocument.Save((TextWriter) text);
      text.Close();
    }

    public static bool Check(string name)
    {
      if (Config.SaveConfigNames == null)
        Config.SaveConfigNames = new Dictionary<string, bool>();
      string saveName = Config.SaveName;
      bool flag = true;
      FileStream inStream = File.Open(Config.SaveName, FileMode.Open);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load((Stream) inStream);
      if (xmlDocument.GetElementsByTagName("config").Count > 0)
      {
        if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
          flag = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
        if (!Config.SaveConfigNames.Keys.Contains<string>(name))
          Config.SaveConfigNames.Add(name, flag);
        else
          Config.SaveConfigNames[name] = flag;
      }
      inStream.Close();
      return flag;
    }

    public static void Set(string name, bool value)
    {
      if (Config.Check(name) == value)
        return;
      Config.SaveConfigNames[name] = value;
      Config.WriteConfig(Config.SaveName);
    }

    private static string pathPlus => Paths.BepInExRootPath + "\\Plugins\\";

    public static string SavePath
    {
      get
      {
        if (!Directory.Exists(Config.pathPlus + "SaltTestNPC\\"))
          Directory.CreateDirectory(Config.pathPlus + "SaltTestNPC\\");
        return Config.pathPlus + "SaltTestNPC\\";
      }
    }

    public static string SaveName
    {
      get
      {
        if (!File.Exists(Config.SavePath + "GameData.config"))
          Config.WriteConfig(Config.SavePath + "GameData.config");
        return Config.SavePath + "GameData.config";
      }
    }
  }
}
