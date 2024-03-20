// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.BritishRoom
// Assembly: TevlevsRapscallions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ABDE8FDC-8B09-454C-BBE7-80FC67FCEE55
// Assembly location: C:\Users\windows\Downloads\TevlevsRapscallions.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace TevlevsRapscallions
{
  public static class BritishRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Brian";

    private static string Files => "Brian_CH";

    private static Character chara => Brain.Cop;

    private static int Zone => 1;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => FuckRoom.Color;

    private static string roomName => BritishRoom.Name + "Room";

    private static string convoName => BritishRoom.Name + "Convo";

    private static string encounterName => BritishRoom.Name + "Encounter";

    private static Sprite Talk => BritishRoom.chara.frontSprite;

    private static Sprite Portal => BritishRoom.chara.unlockedSprite;

    private static string Audio => BritishRoom.chara.dialogueSound;

    private static int ID => (int) BritishRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) BritishRoom.ID, BritishRoom.Portal);
      BritishRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + BritishRoom.Name + "Room.prefab");
      BritishRoom.Room = BritishRoom.Base.AddComponent<NPCRoomHandler>();
      BritishRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) BritishRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      BritishRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) BritishRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) BritishRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = BritishRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + BritishRoom.Name + ".TryHire";
      BritishRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = BritishRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = BritishRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = BritishRoom.roomName;
      instance2._freeFool = BritishRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) BritishRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) BritishRoom.ID
      };
      BritishRoom.Free = instance2;
      BritishRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = BritishRoom.Audio,
        portrait = BritishRoom.Talk,
        bundleTextColor = (BritishRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = BritishRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = BritishRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = BritishRoom.bundle;
      instance3.portraitLooksLeft = BritishRoom.Left;
      instance3.portraitLooksCenter = BritishRoom.Center;
      BritishRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + BritishRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + BritishRoom.roomName, (BaseRoomHandler) BritishRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + BritishRoom.roomName] = (BaseRoomHandler) BritishRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(BritishRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(BritishRoom.convoName, BritishRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[BritishRoom.convoName] = BritishRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(BritishRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(BritishRoom.encounterName, BritishRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[BritishRoom.encounterName] = BritishRoom.Free;
      Backrooms.AddPool(BritishRoom.encounterName, BritishRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(BritishRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(BritishRoom.speaker.speakerName, BritishRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[BritishRoom.speaker.speakerName] = BritishRoom.speaker;
    }
  }
}
