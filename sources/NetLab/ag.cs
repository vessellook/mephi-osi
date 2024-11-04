// Decompiled with JetBrains decompiler
// Type: ag
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

#nullable disable
public class ag
{
  private Queue a;

  [CompilerGenerated]
  [SpecialName]
  public string e() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void b(string A_0) => this.b = A_0;

  public ag()
  {
    this.a = new Queue();
    this.b("Internal");
  }

  public ag(string A_0)
  {
    this.a = new Queue();
    this.b(A_0);
  }

  public void d()
  {
    this.a.Clear();
    this.a.TrimToSize();
  }

  public af c()
  {
    return this.a.Count > 0 ? (af) this.a.Dequeue() : throw new InvalidOperationException("Очередь %s пуста".Replace("%s", this.e()));
  }

  public ag a(string A_0)
  {
    ag ag = new ag(A_0);
    foreach (object A_0_1 in this.a.ToArray())
      ag.a(A_0_1 as af);
    return ag;
  }

  public void a(af A_0) => this.a.Enqueue((object) A_0);

  public af b()
  {
    return this.a.Count > 0 ? (af) this.a.Peek() : throw new InvalidOperationException("Очередь %s пуста".Replace("%s", this.e()));
  }

  [SpecialName]
  public int a() => this.a.Count;
}
