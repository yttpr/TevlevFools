// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.Backrooms
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class Backrooms
  {
    public static AssetBundle Assets;
    public static YarnProgram Yarn;
    public static Material Mat;
    public const string Path = "Assets/Rooms/";
    public static string[] Hard = new string[3]
    {
      "ZoneDB_Hard_01",
      "ZoneDB_Hard_02",
      "ZoneDB_Hard_03"
    };
    public static string[] Easy = new string[3]
    {
      "ZoneDB_01",
      "ZoneDB_02",
      "ZoneDB_03"
    };

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("LoadOldRun", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      Backrooms.Assets = PYMNHere.Assets;
      Backrooms.Yarn = Backrooms.Assets.LoadAsset<YarnProgram>("Assets/Rooms/tevlev.yarn");
      Backrooms.Mat = ((Renderer) ((BaseRoomItem) ((LoadedAssetsHandler.GetRoomPrefab((CardType) 300, LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour").encounterRoom) as NPCRoomHandler)._npcSelectable as BasicRoomItem))._renderers[0]).material;
      Backrooms.Calibrate();
      Backrooms.Add();
    }

    public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      Backrooms.Add();
    }

    public static void Calibrate()
    {
      FuckRoom.Setup();
      JesusRoom.Setup();
      JarRoom.Setup();
      BritishRoom.Setup();
      NerdRoom.Setup();
      AutismRoom.Setup();
      LobotomyRoom.Setup();
      HemmerhoidRoom.Setup();
    }

    public static void Add()
    {
      FuckRoom.Add();
      JesusRoom.Add();
      JarRoom.Add();
      BritishRoom.Add();
      NerdRoom.Add();
      AutismRoom.Add();
      LobotomyRoom.Add();
      HemmerhoidRoom.Add();
    }

    public static void AddPool(string name, int zone)
    {
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB(Backrooms.Easy[zone]) as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB(Backrooms.Hard[zone]) as ZoneBGDataBaseSO;
      if (!((IEnumerable<string>) zoneDb2._FreeFoolsPool).Contains<string>(name))
        zoneDb2._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb2._FreeFoolsPool)
        {
          name
        }.ToArray();
      if (((IEnumerable<string>) zoneDb1._FreeFoolsPool).Contains<string>(name))
        return;
      zoneDb1._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb1._FreeFoolsPool)
      {
        name
      }.ToArray();
    }

    public static void MoreFool(string zone)
    {
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 204,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo._minimumAmount = 40;
      cardTypeInfo._maximumAmount = 40;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
      List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards)
      {
        cardTypeInfo
      };
      zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
    }
  }
}
