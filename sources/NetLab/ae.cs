// Decompiled with JetBrains decompiler
// Type: ae
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Runtime.CompilerServices;

public class ae
{
  [CompilerGenerated]
  [SpecialName]
  public int c() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void b(int A_0) => this.a = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int b() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void a(int A_0) => this.b = A_0;

  public ae(int A_0, int A_1)
  {
    this.b(A_0);
    this.a(A_1);
  }

  public void a(int A_0, int A_1)
  {
    this.b(A_0);
    this.a(A_1);
  }

  [SpecialName]
  public int a() => new Random().Next(this.c() - this.b(), this.c() + this.b() + 1);
}
