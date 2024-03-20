// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.HemmerhoidRoom
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
  public static class HemmerhoidRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Gilbert";

    private static string Files => "Gilbert_CH";

    private static Character chara => ShitBurg.ItHim;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 220, (byte) 71, (byte) 103, byte.MaxValue);

    private static string roomName => HemmerhoidRoom.Name + "Room";

    private static string convoName => HemmerhoidRoom.Name + "Convo";

    private static string encounterName => HemmerhoidRoom.Name + "Encounter";

    private static Sprite Talk => HemmerhoidRoom.chara.frontSprite;

    private static Sprite Portal => HemmerhoidRoom.chara.unlockedSprite;

    private static string Audio => HemmerhoidRoom.chara.dialogueSound;

    private static int ID => (int) HemmerhoidRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) HemmerhoidRoom.ID, HemmerhoidRoom.Portal);
      HemmerhoidRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + HemmerhoidRoom.Name + "Room.prefab");
      HemmerhoidRoom.Room = HemmerhoidRoom.Base.AddComponent<NPCRoomHandler>();
      HemmerhoidRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) HemmerhoidRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      HemmerhoidRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) HemmerhoidRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) HemmerhoidRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = HemmerhoidRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + HemmerhoidRoom.Name + ".TryHire";
      HemmerhoidRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = HemmerhoidRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = HemmerhoidRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = HemmerhoidRoom.roomName;
      instance2._freeFool = HemmerhoidRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) HemmerhoidRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) HemmerhoidRoom.ID
      };
      HemmerhoidRoom.Free = instance2;
      HemmerhoidRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = HemmerhoidRoom.Audio,
        portrait = HemmerhoidRoom.Talk,
        bundleTextColor = (HemmerhoidRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = HemmerhoidRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = HemmerhoidRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = HemmerhoidRoom.bundle;
      instance3.portraitLooksLeft = HemmerhoidRoom.Left;
      instance3.portraitLooksCenter = HemmerhoidRoom.Center;
      HemmerhoidRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + HemmerhoidRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + HemmerhoidRoom.roomName, (BaseRoomHandler) HemmerhoidRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + HemmerhoidRoom.roomName] = (BaseRoomHandler) HemmerhoidRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(HemmerhoidRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(HemmerhoidRoom.convoName, HemmerhoidRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[HemmerhoidRoom.convoName] = HemmerhoidRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(HemmerhoidRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(HemmerhoidRoom.encounterName, HemmerhoidRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[HemmerhoidRoom.encounterName] = HemmerhoidRoom.Free;
      Backrooms.AddPool(HemmerhoidRoom.encounterName, HemmerhoidRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(HemmerhoidRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(HemmerhoidRoom.speaker.speakerName, HemmerhoidRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[HemmerhoidRoom.speaker.speakerName] = HemmerhoidRoom.speaker;
    }
  }
}
