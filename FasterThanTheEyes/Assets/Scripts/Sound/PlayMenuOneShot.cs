using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuOneShot : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string ConfirmSoundEvent;
    FMOD.Studio.EventInstance ConfirmSound;
    [FMODUnity.EventRef]
    public string EnterSoundEvent;
    FMOD.Studio.EventInstance EnterSound;

    public void playMenuSound(int sound)
    {
        switch(sound)
        {
            case 1:
                if (SceneManagerFTTE.fmodEnable)
                {
                    ConfirmSound = FMODUnity.RuntimeManager.CreateInstance(ConfirmSoundEvent);
                    ConfirmSound.start();
                    ConfirmSound.release();
                }

                break;
            case 2:
                if (SceneManagerFTTE.fmodEnable)
                {
                    EnterSound = FMODUnity.RuntimeManager.CreateInstance(EnterSoundEvent);
                    EnterSound.start();
                    EnterSound.release();
                }

                break;
        }
    }
}
