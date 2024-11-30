// Decompiled with JetBrains decompiler
// Type: af
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Runtime.CompilerServices;

public class af
{
  private object a;
  private ac b;
  private bool c;

  [SpecialName]
  public ac h() => this.b;

  [SpecialName]
  public void a(ac A_0) => this.b = A_0;

  [SpecialName]
  public bool g() => this.c;

  [CompilerGenerated]
  [SpecialName]
  public string f() => this.d;

  [CompilerGenerated]
  [SpecialName]
  public void b(string A_0) => this.d = A_0;

  public af()
  {
    this.c = false;
    this.b("Internal");
  }

  public af(string A_0, object A_1, ac A_2)
  {
    this.a = A_1;
    this.b(A_0);
    this.b = A_2;
    this.c = true;
  }

  [SpecialName]
  public int e()
  {
    if (!this.g())
      throw new InvalidOperationException("Переменная %s - не установленно значение".Replace("%s", this.f()));
    if (this.h() != ac.a)
      throw new InvalidOperationException("Переменная %s - не верный тип".Replace("%s", this.f()));
    return (int) this.a;
  }

  [SpecialName]
  public void a(int A_0)
  {
    if (this.h() != ac.a)
      throw new InvalidOperationException("Переменная %s - не верный тип".Replace("%s", this.f()));
    this.a = (object) A_0;
    this.c = true;
    this.b = ac.a;
  }

  [SpecialName]
  public bool d() => this.e() != 0;

  [SpecialName]
  public void a(bool A_0)
  {
    if (this.h() != ac.a)
      throw new InvalidOperationException("Переменная %s - не верный тип".Replace("%s", this.f()));
    if (A_0)
      this.a(1);
    else
      this.a(0);
  }

  [SpecialName]
  public string c()
  {
    if (!this.g())
      throw new InvalidOperationException("Переменная %s - не установленно значение".Replace("%s", this.f()));
    if (this.h() != ac.b)
      throw new InvalidOperationException("Переменная %s - не верный тип".Replace("%s", this.f()));
    return (string) this.a;
  }

  [SpecialName]
  public void a(string A_0)
  {
    if (this.h() != ac.b)
      throw new InvalidOperationException("Переменная %s - не верный тип".Replace("%s", this.f()));
    this.a = (object) A_0;
    this.c = true;
    this.b = ac.b;
  }

  [SpecialName]
  public int[] b()
  {
    if (!this.g())
      throw new InvalidOperationException("Переменная %s - не установленно значение".Replace("%s", this.f()));
    if (this.h() != ac.c)
      throw new InvalidOperationException("Переменная %s - не верный тип".Replace("%s", this.f()));
    return (int[]) this.a;
  }

  [SpecialName]
  public void a(int[] A_0)
  {
    if (this.h() != ac.c)
      throw new InvalidOperationException("Переменная %s - не верный тип".Replace("%s", this.f()));
    this.a = (object) A_0;
    this.c = true;
    this.b = ac.c;
  }

  public af a() => new af(this.f(), this.a, this.h());
}
