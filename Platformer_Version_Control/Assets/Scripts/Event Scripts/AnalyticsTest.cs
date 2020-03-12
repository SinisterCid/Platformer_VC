﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ReportSecretFound(1);
        }
    }

    public void ReportSecretFound(int secretID)
    {
        Analytics.CustomEvent("secret_found", new Dictionary<string, object>
    {
        { "secret_id", secretID },
        { "time_elapsed", Time.timeSinceLevelLoad }
    });
    }
}
