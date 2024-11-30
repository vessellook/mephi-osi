// Decompiled with JetBrains decompiler
// Type: ab
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System.Collections;

public static class LayersTraceSettings
{
  public static bool a;
  public static SortedList layers = new SortedList(7);

  static LayersTraceSettings()
  {
    LayersTraceSettings.layers.Add((object) "Network", (object) false);
    LayersTraceSettings.layers.Add((object) "Transport", (object) false);
    LayersTraceSettings.layers.Add((object) "Session", (object) false);
    LayersTraceSettings.layers.Add((object) "Presentation", (object) false);
    LayersTraceSettings.layers.Add((object) "Application", (object) false);
    LayersTraceSettings.layers.Add((object) "UE", (object) false);
    LayersTraceSettings.layers.Add((object) "Process", (object) false);
  }
}
