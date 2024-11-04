// Decompiled with JetBrains decompiler
// Type: am
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
public class am
{
  private MainWindow i;
  private an j;

  [CompilerGenerated]
  [SpecialName]
  public ak k() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void g(ak A_0) => this.a = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ak j() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void f(ak A_0) => this.b = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ak i() => this.c;

  [CompilerGenerated]
  [SpecialName]
  public void e(ak A_0) => this.c = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ak h() => this.d;

  [CompilerGenerated]
  [SpecialName]
  public void d(ak A_0) => this.d = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ak g() => this.e;

  [CompilerGenerated]
  [SpecialName]
  public void c(ak A_0) => this.e = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ak f() => this.f;

  [CompilerGenerated]
  [SpecialName]
  public void b(ak A_0) => this.f = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ak e() => this.g;

  [CompilerGenerated]
  [SpecialName]
  public void a(ak A_0) => this.g = A_0;

  [CompilerGenerated]
  [SpecialName]
  public al d() => this.h;

  [CompilerGenerated]
  [SpecialName]
  public void a(al A_0) => this.h = A_0;

  [CompilerGenerated]
  [SpecialName]
  public byte c() => this.k;

  [CompilerGenerated]
  [SpecialName]
  public void a(byte A_0) => this.k = A_0;

  [CompilerGenerated]
  [SpecialName]
  public string b() => this.l;

  [CompilerGenerated]
  [SpecialName]
  public void a(string A_0) => this.l = A_0;

  public am(string A_0, byte A_1, MainWindow A_2, an A_3)
  {
    this.a(A_0);
    this.i = A_2;
    this.j = A_3;
    this.a(A_1);
    this.a(new al("NetworkEmulator"));
    this.a(new ak("Network", this.i));
    this.b(new ak("Transport", this.i));
    this.c(new ak("Session", this.i));
    this.d(new ak("Presentation", this.i));
    this.e(new ak("Application", this.i));
    this.f(new ak("UE", this.i));
    this.g(new ak("Process", this.i));
  }

  public void d(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("sysdef +levels +events +code +fullcodeset +loadall +wantreturns\n"), 0, unicodeEncoding.GetByteCount("sysdef +levels +events +code +fullcodeset +loadall +wantreturns\n"));
    this.k().g(A_0);
    this.j().g(A_0);
    this.h().g(A_0);
    this.i().g(A_0);
    this.g().g(A_0);
    this.f().g(A_0);
    this.e().g(A_0);
    A_0.Write(unicodeEncoding.GetBytes("sysdef end\n"), 0, unicodeEncoding.GetByteCount("sysdef end\n"));
  }

  public void c(MemoryStream A_0)
  {
    if (ad.a(A_0) != "sysdef +levels +events +code +fullcodeset +loadall +wantreturns")
      throw new InvalidOperationException("Неверный формат файла");
    this.k().c(A_0);
    this.j().c(A_0);
    this.h().c(A_0);
    this.i().c(A_0);
    this.g().c(A_0);
    this.f().c(A_0);
    this.e().c(A_0);
    if (ad.a(A_0) != "sysdef end")
      throw new InvalidOperationException("Неверный формат файла");
  }

  public void b(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("sysdef +CRC +Date +Time +staff\n"), 0, unicodeEncoding.GetByteCount("sysdef +CRC +Date +Time +staff\n"));
    this.k().b(A_0);
    this.j().b(A_0);
    this.h().b(A_0);
    this.i().b(A_0);
    this.g().b(A_0);
    this.f().b(A_0);
    this.e().b(A_0);
    A_0.Write(unicodeEncoding.GetBytes("sysdef end\n"), 0, unicodeEncoding.GetByteCount("sysdef end\n"));
  }

  public void a(MemoryStream A_0)
  {
    if (ad.a(A_0) != "sysdef +CRC +Date +Time +staff")
      throw new InvalidOperationException("Неверный формат файла");
    this.k().a(A_0);
    this.j().a(A_0);
    this.h().a(A_0);
    this.i().a(A_0);
    this.g().a(A_0);
    this.f().a(A_0);
    this.e().a(A_0);
    if (ad.a(A_0) != "sysdef end")
      throw new InvalidOperationException("Неверный формат файла");
  }

  public void a()
  {
    this.e().b();
    this.f().b();
    this.g().b();
    this.h().b();
    this.i().b();
    this.j().b();
    this.k().b();
  }

  public void b(string A_0, string A_1, SortedList A_2)
  {
    if (A_0 == null)
      return;
    switch (A_0.Length)
    {
      case 2:
        if (!(A_0 == "UE"))
          break;
        this.j().a(A_1, A_2, this);
        break;
      case 7:
        switch (A_0[0])
        {
          case 'N':
            if (!(A_0 == "Network"))
              return;
            this.e().a(A_1, A_2, this);
            return;
          case 'P':
            if (!(A_0 == "Process"))
              return;
            this.k().a(A_1, A_2, this);
            return;
          case 'S':
            if (!(A_0 == "Session"))
              return;
            this.g().a(A_1, A_2, this);
            return;
          default:
            return;
        }
      case 9:
        if (!(A_0 == "Transport"))
          break;
        this.f().a(A_1, A_2, this);
        break;
      case 11:
        if (!(A_0 == "Application"))
          break;
        this.i().a(A_1, A_2, this);
        break;
      case 12:
        if (!(A_0 == "Presentation"))
          break;
        this.h().a(A_1, A_2, this);
        break;
      case 15:
        if (!(A_0 == "NetworkEmulator"))
          break;
        this.d().a(A_1, A_2, this);
        break;
    }
  }

  public void a(string A_0, string A_1, SortedList A_2)
  {
    this.j.a(A_1, A_2, A_0, this, 0, this.j.a());
  }
}
