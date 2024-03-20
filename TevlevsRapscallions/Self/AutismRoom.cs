// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.AutismRoom
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
  public static class AutismRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "LoveBug";

    private static string Files => "LoveBug_CH";

    private static Character chara => LoveBug.Bug;

    private static int Zone => 1;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 206, (byte) 142, (byte) 207, byte.MaxValue);

    private static string roomName => AutismRoom.Name + "Room";

    private static string convoName => AutismRoom.Name + "Convo";

    private static string encounterName => AutismRoom.Name + "Encounter";

    private static Sprite Talk => AutismRoom.chara.frontSprite;

    private static Sprite Portal => AutismRoom.chara.unlockedSprite;

    private static string Audio => AutismRoom.chara.dialogueSound;

    private static int ID => (int) AutismRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) AutismRoom.ID, AutismRoom.Portal);
      AutismRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + AutismRoom.Name + "Room.prefab");
      AutismRoom.Room = AutismRoom.Base.AddComponent<NPCRoomHandler>();
      AutismRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) AutismRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      AutismRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) AutismRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) AutismRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = AutismRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + AutismRoom.Name + ".TryHire";
      AutismRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = AutismRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = AutismRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = AutismRoom.roomName;
      instance2._freeFool = AutismRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) AutismRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) AutismRoom.ID
      };
      AutismRoom.Free = instance2;
      AutismRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = AutismRoom.Audio,
        portrait = AutismRoom.Talk,
        bundleTextColor = (AutismRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = AutismRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = AutismRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = AutismRoom.bundle;
      instance3.portraitLooksLeft = AutismRoom.Left;
      instance3.portraitLooksCenter = AutismRoom.Center;
      AutismRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + AutismRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + AutismRoom.roomName, (BaseRoomHandler) AutismRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + AutismRoom.roomName] = (BaseRoomHandler) AutismRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(AutismRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(AutismRoom.convoName, AutismRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[AutismRoom.convoName] = AutismRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(AutismRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(AutismRoom.encounterName, AutismRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[AutismRoom.encounterName] = AutismRoom.Free;
      Backrooms.AddPool(AutismRoom.encounterName, AutismRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(AutismRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(AutismRoom.speaker.speakerName, AutismRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[AutismRoom.speaker.speakerName] = AutismRoom.speaker;
    }
  }
}
