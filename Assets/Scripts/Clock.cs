using System;
using UnityEngine;

public class Clock : MonoBehaviour {
    public Transform HoursTransform;
    public Transform MinutesTransform;
    public Transform SecondsTransform;
    public bool Continuous;

    const float
        DegreesPerHour = 30f,
        DegreesPerMinute = 6f,
        DegreesPerSecond = 6f;

    void Awake() {
        UpdateDiscrete();
    }

    void Update() {
        if (Continuous) {
            UpdateContinuous();
        }
        else {
            UpdateDiscrete();
        }
    }

    void UpdateDiscrete() {
        var time = DateTime.Now;
        HoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * DegreesPerHour, 0f);
        MinutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * DegreesPerMinute, 0f);
        SecondsTransform.localRotation = Quaternion.Euler(0f, time.Second * DegreesPerSecond, 0f);
    }

    void UpdateContinuous() {
        var time = DateTime.Now.TimeOfDay;
        HoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * DegreesPerHour, 0f);
        MinutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * DegreesPerMinute, 0f);
        SecondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * DegreesPerSecond, 0f);
    }
}