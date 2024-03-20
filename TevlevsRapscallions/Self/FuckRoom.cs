// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.FuckRoom
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
  public static class FuckRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Carpy";

    private static string Files => "Carpy_CH";

    private static Character chara => Carpy.Fish;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 77, (byte) 124, (byte) 207, byte.MaxValue);

    private static string roomName => FuckRoom.Name + "Room";

    private static string convoName => FuckRoom.Name + "Convo";

    private static string encounterName => FuckRoom.Name + "Encounter";

    private static Sprite Talk => FuckRoom.chara.frontSprite;

    private static Sprite Portal => FuckRoom.chara.unlockedSprite;

    private static string Audio => FuckRoom.chara.dialogueSound;

    private static int ID => (int) FuckRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) FuckRoom.ID, FuckRoom.Portal);
      FuckRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + FuckRoom.Name + "Room.prefab");
      FuckRoom.Room = FuckRoom.Base.AddComponent<NPCRoomHandler>();
      FuckRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) FuckRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      FuckRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) FuckRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) FuckRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = FuckRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + FuckRoom.Name + ".TryHire";
      FuckRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = FuckRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = FuckRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = FuckRoom.roomName;
      instance2._freeFool = FuckRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) FuckRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) FuckRoom.ID
      };
      FuckRoom.Free = instance2;
      FuckRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = FuckRoom.Audio,
        portrait = FuckRoom.Talk,
        bundleTextColor = (FuckRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = FuckRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = FuckRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = FuckRoom.bundle;
      instance3.portraitLooksLeft = FuckRoom.Left;
      instance3.portraitLooksCenter = FuckRoom.Center;
      FuckRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + FuckRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + FuckRoom.roomName, (BaseRoomHandler) FuckRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + FuckRoom.roomName] = (BaseRoomHandler) FuckRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(FuckRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(FuckRoom.convoName, FuckRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[FuckRoom.convoName] = FuckRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(FuckRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(FuckRoom.encounterName, FuckRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[FuckRoom.encounterName] = FuckRoom.Free;
      Backrooms.AddPool(FuckRoom.encounterName, FuckRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(FuckRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(FuckRoom.speaker.speakerName, FuckRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[FuckRoom.speaker.speakerName] = FuckRoom.speaker;
    }
  }
}
