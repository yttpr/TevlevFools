// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.JesusRoom
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
  public static class JesusRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Nails";

    private static string Files => "Nails_CH";

    private static Character chara => Nails.Nail;

    private static int Zone => 1;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 167, (byte) 167, (byte) 162, byte.MaxValue);

    private static string roomName => JesusRoom.Name + "Room";

    private static string convoName => JesusRoom.Name + "Convo";

    private static string encounterName => JesusRoom.Name + "Encounter";

    private static Sprite Talk => JesusRoom.chara.frontSprite;

    private static Sprite Portal => JesusRoom.chara.unlockedSprite;

    private static string Audio => JesusRoom.chara.dialogueSound;

    private static int ID => (int) JesusRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) JesusRoom.ID, JesusRoom.Portal);
      JesusRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + JesusRoom.Name + "Room.prefab");
      JesusRoom.Room = JesusRoom.Base.AddComponent<NPCRoomHandler>();
      JesusRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) JesusRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      JesusRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) JesusRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) JesusRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = JesusRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + JesusRoom.Name + ".TryHire";
      JesusRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = JesusRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = JesusRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = JesusRoom.roomName;
      instance2._freeFool = JesusRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) JesusRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) JesusRoom.ID
      };
      JesusRoom.Free = instance2;
      JesusRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = JesusRoom.Audio,
        portrait = JesusRoom.Talk,
        bundleTextColor = (JesusRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = JesusRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = JesusRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = JesusRoom.bundle;
      instance3.portraitLooksLeft = JesusRoom.Left;
      instance3.portraitLooksCenter = JesusRoom.Center;
      JesusRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + JesusRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + JesusRoom.roomName, (BaseRoomHandler) JesusRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + JesusRoom.roomName] = (BaseRoomHandler) JesusRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(JesusRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(JesusRoom.convoName, JesusRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[JesusRoom.convoName] = JesusRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(JesusRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(JesusRoom.encounterName, JesusRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[JesusRoom.encounterName] = JesusRoom.Free;
      Backrooms.AddPool(JesusRoom.encounterName, JesusRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(JesusRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(JesusRoom.speaker.speakerName, JesusRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[JesusRoom.speaker.speakerName] = JesusRoom.speaker;
    }
  }
}
