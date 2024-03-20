// Decompiled with JetBrains decompiler
// Type: TevlevsRapscallions.JarRoom
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
  public static class JarRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "MeatShot";

    private static string Files => "Meatshot_CH";

    private static Character chara => Meatshot.Gun;

    private static int Zone => 2;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 167, (byte) 32, (byte) 32, byte.MaxValue);

    private static string roomName => JarRoom.Name + "Room";

    private static string convoName => JarRoom.Name + "Convo";

    private static string encounterName => JarRoom.Name + "Encounter";

    private static Sprite Talk => ResourceLoader.LoadSprite("MeatShotDialogue.png");

    private static Sprite Portal => JarRoom.chara.unlockedSprite;

    private static string Audio => JarRoom.chara.dialogueSound;

    private static int ID => (int) JarRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) JarRoom.ID, JarRoom.Portal);
      JarRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + JarRoom.Name + "Room.prefab");
      JarRoom.Room = JarRoom.Base.AddComponent<NPCRoomHandler>();
      JarRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) JarRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      JarRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) JarRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) JarRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = JarRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Tevlev." + JarRoom.Name + ".TryHire";
      JarRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = JarRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = JarRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = JarRoom.roomName;
      instance2._freeFool = JarRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) JarRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) JarRoom.ID
      };
      JarRoom.Free = instance2;
      JarRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = JarRoom.Audio,
        portrait = JarRoom.Talk,
        bundleTextColor = (JarRoom.Color)
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = JarRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = JarRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = JarRoom.bundle;
      instance3.portraitLooksLeft = JarRoom.Left;
      instance3.portraitLooksCenter = JarRoom.Center;
      JarRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + JarRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + JarRoom.roomName, (BaseRoomHandler) JarRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + JarRoom.roomName] = (BaseRoomHandler) JarRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(JarRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(JarRoom.convoName, JarRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[JarRoom.convoName] = JarRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(JarRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(JarRoom.encounterName, JarRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[JarRoom.encounterName] = JarRoom.Free;
      Backrooms.AddPool(JarRoom.encounterName, JarRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(JarRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(JarRoom.speaker.speakerName, JarRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[JarRoom.speaker.speakerName] = JarRoom.speaker;
    }
  }
}
