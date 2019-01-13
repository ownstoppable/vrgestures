using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VRTK;

public class RecordGesture : MonoBehaviour{
    public VRTK_ControllerEvents VrtkControllerEvents;
    public VRTK_ControllerEvents.ButtonAlias RecordingButton;
    private Coroutine _recordingCoroutine;
    private bool _recording;

    private void Start(){
        VrtkControllerEvents.SubscribeToButtonAliasEvent(RecordingButton, true, StartRecording);
        VrtkControllerEvents.SubscribeToButtonAliasEvent(RecordingButton, false, StopRecording);
    }

    private void StopRecording(object sender, ControllerInteractionEventArgs e){
        _recording = false;
    }

    private void StartRecording(object sender, ControllerInteractionEventArgs e){
        if(_recordingCoroutine != null)
            StopCoroutine(_recordingCoroutine);
        _recording = true;
        _recordingCoroutine = StartCoroutine(RecordGestureCoroutine());
    }

    private IEnumerator RecordGestureCoroutine(){
        PositionGesture newGesture = new PositionGesture();
        Transform rightHand = VRTK_DeviceFinder.GetControllerRightHand().transform;
        List<Vector3> positions = new List<Vector3>();
        float t = Time.realtimeSinceStartup;
        while (_recording){
            positions.Add(rightHand.position);
            yield return null;    
        }
        //Debug.Log(positions.Count + " positions recorded");
        //Debug.Log("In " + (Time.realtimeSinceStartup - t) + " seconds");
        newGesture.Duration = Time.realtimeSinceStartup - t;
        newGesture.Positions = positions.ToArray();
        string jsonData = JsonUtility.ToJson(newGesture);
        File.WriteAllText(Application.dataPath + "\\NewGesture.json", jsonData);
    }
}