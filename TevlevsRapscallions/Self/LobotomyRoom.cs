// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.LobotomyRoom
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
  public static class LobotomyRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "BubbleBlower";

    private static string Files => "BubbleBlower_CH";

    private static Character chara => BubbleBlower.Retard;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 77, (byte) 124, (byte) 207, byte.MaxValue);

    private static string roomName => LobotomyRoom.Name + "Room";

    private static string convoName => LobotomyRoom.Name + "Convo";

    private static string encounterName => LobotomyRoom.Name + "Encounter";

    private static Sprite Talk => LobotomyRoom.chara.frontSprite;

    private static Sprite Portal => LobotomyRoom.chara.unlockedSprite;

    private static string Audio => LobotomyRoom.chara.dialogueSound;

    private static int ID => (int) LobotomyRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) LobotomyRoom.ID, LobotomyRoom.Portal);
      LobotomyRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + LobotomyRoom.Name + "Room.prefab");
      LobotomyRoom.Room = LobotomyRoom.Base.AddComponent<NPCRoomHandler>();
      LobotomyRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) LobotomyRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      LobotomyRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) LobotomyRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) LobotomyRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = LobotomyRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + LobotomyRoom.Name + ".TryHire";
      LobotomyRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = LobotomyRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = LobotomyRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = LobotomyRoom.roomName;
      instance2._freeFool = LobotomyRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) LobotomyRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) LobotomyRoom.ID
      };
      LobotomyRoom.Free = instance2;
      LobotomyRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = LobotomyRoom.Audio,
        portrait = LobotomyRoom.Talk,
        bundleTextColor = (LobotomyRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = LobotomyRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = LobotomyRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = LobotomyRoom.bundle;
      instance3.portraitLooksLeft = LobotomyRoom.Left;
      instance3.portraitLooksCenter = LobotomyRoom.Center;
      LobotomyRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + LobotomyRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + LobotomyRoom.roomName, (BaseRoomHandler) LobotomyRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + LobotomyRoom.roomName] = (BaseRoomHandler) LobotomyRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(LobotomyRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(LobotomyRoom.convoName, LobotomyRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[LobotomyRoom.convoName] = LobotomyRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(LobotomyRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(LobotomyRoom.encounterName, LobotomyRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[LobotomyRoom.encounterName] = LobotomyRoom.Free;
      Backrooms.AddPool(LobotomyRoom.encounterName, LobotomyRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(LobotomyRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(LobotomyRoom.speaker.speakerName, LobotomyRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[LobotomyRoom.speaker.speakerName] = LobotomyRoom.speaker;
    }
  }
}
