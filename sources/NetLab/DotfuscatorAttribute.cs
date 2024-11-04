// Decompiled with JetBrains decompiler
// Type: DotfuscatorAttribute
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
[ComVisible(false)]
[AttributeUsage(AttributeTargets.Assembly)]
public sealed class DotfuscatorAttribute : Attribute
{
  private string a;
  private int c;

  public DotfuscatorAttribute(string a, int c)
  {
    DotfuscatorAttribute dotfuscatorAttribute = this;
    // ISSUE: explicit constructor call
    dotfuscatorAttribute.\u002Ector();
    dotfuscatorAttribute.a = a;
    this.c = c;
  }

  public string A => this.a;

  public string a() => this.a;

  public int C => this.c;

  public int c() => this.c;
}
