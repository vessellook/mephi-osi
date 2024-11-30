// Decompiled with JetBrains decompiler
// Type: ak
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

public class LayerParticipant
{
  private MainWindow parent;
    public aa d;
  public SortedList e;
  public SortedList f;

  [CompilerGenerated]
  [SpecialName]
  public string k() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void a(string A_0) => this.b = A_0;

  [CompilerGenerated]
  [SpecialName]
  public byte j() => this.c;

  [CompilerGenerated]
  [SpecialName]
  public void b(byte A_0) => this.c = A_0;

  [SpecialName]
  public byte i() => this.h() == this.g() ? (byte) 0 : (byte) 1;

  [SpecialName]
  public void a(byte A_0)
  {
    if (A_0 == (byte) 0)
      this.c(this.g());
    else
      this.c(this.c());
  }

  [CompilerGenerated]
  [SpecialName]
  public SortedList h() => this.g;

  [CompilerGenerated]
  [SpecialName]
  public void c(SortedList A_0) => this.g = A_0;

  [CompilerGenerated]
  [SpecialName]
  public SortedList g() => this.h;

  [CompilerGenerated]
  [SpecialName]
  public void b(SortedList A_0) => this.h = A_0;

  [CompilerGenerated]
  [SpecialName]
  public SortedList c() => this.i;

  [CompilerGenerated]
  [SpecialName]
  public void a(SortedList A_0) => this.i = A_0;

  public LayerParticipant(string A_0, MainWindow mainWindow)
  {
    this.parent = mainWindow;
    this.a(A_0);
    this.e = new SortedList((IComparer) new CaseInsensitiveComparer());
    this.f = new SortedList((IComparer) new CaseInsensitiveComparer());
    this.b(new SortedList((IComparer) new CaseInsensitiveComparer()));
    this.a(new SortedList((IComparer) new CaseInsensitiveComparer()));
    this.a((byte) 0);
    this.c(this.g());
    this.b((byte) 0);
    this.d = new aa();
  }

  public void a(string A_0, SortedList A_1, Participant A_2)
  {
    if (this.h().Contains((object) A_0))
      (this.h()[(object) A_0] as aj).a(A_1, this, A_2, this.parent);
    else if (A_0.IndexOf("INIT.REQ") == -1)
      throw new InvalidOperationException(A_2.b() + Resources.ErrorNoSuchEvent.Replace("%s", A_0));
  }

  public void Clear()
  {
    this.g().Clear();
    this.c().Clear();
    this.e.Clear();
    this.f.Clear();
    this.a((byte) 0);
  }

  public void Init()
  {
    this.d.a = 0;
    this.d.b = 0;
    this.d.d = 0;
    this.d.m = 0;
    this.d.k = 0;
    this.d.g = 0;
    this.d.h = 0;
    this.d.l = 0;
    this.d.f = 0;
    this.d.c = 0;
    this.d.i = 0;
    this.d.e = 0;
    this.d.j = 0;
  }

  public void g(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("levdef " + this.k() + "\n"), 0, unicodeEncoding.GetByteCount("levdef " + this.k() + "\n"));
    A_0.Write(unicodeEncoding.GetBytes("events bank0 " + Convert.ToString(this.g().Count) + "\n"), 0, unicodeEncoding.GetByteCount("events bank0 " + Convert.ToString(this.g().Count) + "\n"));
    for (int index = 0; index < this.g().Count; ++index)
      ((aj) this.g().GetByIndex(index)).d(A_0);
    A_0.Write(unicodeEncoding.GetBytes("events bank1 " + Convert.ToString(this.c().Count) + "\n"), 0, unicodeEncoding.GetByteCount("events bank1 " + Convert.ToString(this.c().Count) + "\n"));
    for (int index = 0; index < this.c().Count; ++index)
      ((aj) this.c().GetByIndex(index)).d(A_0);
    A_0.Write(unicodeEncoding.GetBytes("levdef end\n"), 0, unicodeEncoding.GetByteCount("levdef end\n"));
  }

  public void c(MemoryStream A_0)
  {
    string str1 = ad.a(A_0);
    if (str1.Substring(0, 7) != "levdef ")
      throw new InvalidOperationException("Неверный формат файла");
    if (this.k() != str1.Substring(7))
      throw new InvalidOperationException("Неверный уровень");
    string str2 = ad.a(A_0);
    int num1 = !(str2.Substring(0, 13) != "events bank0 ") ? Convert.ToInt32(str2.Substring(13)) : throw new InvalidOperationException("Неверный формат файла");
    this.g().Clear();
    for (int index = 0; index < num1; ++index)
    {
      aj aj = new aj("System", this.j());
      aj.c(A_0);
      this.g().Add((object) aj.o(), (object) aj);
    }
    string str3 = ad.a(A_0);
    int num2 = !(str3.Substring(0, 13) != "events bank1 ") ? Convert.ToInt32(str3.Substring(13)) : throw new InvalidOperationException("Неверный формат файла");
    this.c().Clear();
    for (int index = 0; index < num2; ++index)
    {
      aj aj = new aj("System", this.j());
      aj.c(A_0);
      this.c().Add((object) aj.o(), (object) aj);
    }
    if (ad.a(A_0) != "levdef end")
      throw new InvalidOperationException("Неверный формат файла");
  }

  public void b(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("levdef " + this.k() + "\n"), 0, unicodeEncoding.GetByteCount("levdef " + this.k() + "\n"));
    A_0.Write(unicodeEncoding.GetBytes("events bank0 " + Convert.ToString(this.g().Count) + "\n"), 0, unicodeEncoding.GetByteCount("events bank0 " + Convert.ToString(this.g().Count) + "\n"));
    for (int index = 0; index < this.g().Count; ++index)
      ((aj) this.g().GetByIndex(index)).b(A_0);
    A_0.Write(unicodeEncoding.GetBytes("events bank1 " + Convert.ToString(this.c().Count) + "\n"), 0, unicodeEncoding.GetByteCount("events bank1 " + Convert.ToString(this.c().Count) + "\n"));
    for (int index = 0; index < this.c().Count; ++index)
      ((aj) this.c().GetByIndex(index)).b(A_0);
    A_0.Write(unicodeEncoding.GetBytes("levdef end\n"), 0, unicodeEncoding.GetByteCount("levdef end\n"));
  }

  public void a(MemoryStream A_0)
  {
    string str1 = !(ad.a(A_0) != "levdef " + this.k()) ? ad.a(A_0) : throw new InvalidOperationException("Неверный формат файла");
    int num1 = !(str1.Substring(0, 13) != "events bank0 ") ? Convert.ToInt32(str1.Substring(13)) : throw new InvalidOperationException("Неверный формат файла");
    for (int index = 0; index < num1; ++index)
      ((aj) this.g().GetByIndex(index)).a(A_0);
    string str2 = ad.a(A_0);
    int num2 = !(str2.Substring(0, 13) != "events bank1 ") ? Convert.ToInt32(str2.Substring(13)) : throw new InvalidOperationException("Неверный формат файла");
    for (int index = 0; index < num2; ++index)
      ((aj) this.c().GetByIndex(index)).a(A_0);
    if (ad.a(A_0) != "levdef end")
      throw new InvalidOperationException("Неверный формат файла");
  }
}
