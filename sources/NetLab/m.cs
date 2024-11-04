// Decompiled with JetBrains decompiler
// Type: m
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
public class m
{
  public const int a = 1024;
  public const int b = 15;
  public const int c = 256;
  public const int d = 257;
  public const int e = 258;
  public const int f = 1245;
  public const int g = 1246;
  public const int h = 17;
  public const int i = 38;
  public const int j = 40;
  public const int k = 144;
  public const short l = 1;
  public const short m = 128;
  public const int n = 0;
  public const int o = 1;

  private m()
  {
  }

  [DllImport("user32")]
  public static extern int SendMessage(IntPtr A_0, int A_1, int A_2, IntPtr A_3);

  [DllImport("user32")]
  public static extern int PostMessage(IntPtr A_0, int A_1, int A_2, int A_3);

  [DllImport("user32")]
  public static extern short GetKeyState(int A_0);

  [DllImport("user32")]
  public static extern int LockWindowUpdate(IntPtr A_0);

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  public static extern int GetScrollPos(IntPtr A_0, int A_1);

  [DllImport("user32.dll")]
  public static extern int SetScrollPos(IntPtr A_0, int A_1, int A_2, bool A_3);

  public struct a
  {
    public int a;
    public int b;
  }
}
