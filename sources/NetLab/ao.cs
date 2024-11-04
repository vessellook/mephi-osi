// Decompiled with JetBrains decompiler
// Type: ao
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Windows.Forms;

#nullable disable
internal static class ao
{
  [STAThread]
  private static void a()
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run((Form) new MainWindow());
  }
}
