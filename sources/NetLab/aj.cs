// Decompiled with JetBrains decompiler
// Type: aj
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
public class aj
{
  public uint m;

  [CompilerGenerated]
  [SpecialName]
  public string o() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void a(string A_0) => this.a = A_0;

  [CompilerGenerated]
  [SpecialName]
  public bool n() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void a(bool A_0) => this.b = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ArrayList l() => this.c;

  [CompilerGenerated]
  [SpecialName]
  public void b(ArrayList A_0) => this.c = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ArrayList k() => this.d;

  [CompilerGenerated]
  [SpecialName]
  public void a(ArrayList A_0) => this.d = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int j() => this.e;

  [CompilerGenerated]
  [SpecialName]
  public void g(int A_0) => this.e = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int i() => this.f;

  [CompilerGenerated]
  [SpecialName]
  public void f(int A_0) => this.f = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int h() => this.g;

  [CompilerGenerated]
  [SpecialName]
  public void e(int A_0) => this.g = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int g() => this.h;

  [CompilerGenerated]
  [SpecialName]
  public void d(int A_0) => this.h = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int f() => this.i;

  [CompilerGenerated]
  [SpecialName]
  public void c(int A_0) => this.i = A_0;

  [CompilerGenerated]
  [SpecialName]
  public DateTime e() => this.j;

  [CompilerGenerated]
  [SpecialName]
  public void a(DateTime A_0) => this.j = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int d() => this.k;

  [CompilerGenerated]
  [SpecialName]
  public void b(int A_0) => this.k = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int c() => this.l;

  [CompilerGenerated]
  [SpecialName]
  public void a(int A_0) => this.l = A_0;

  [CompilerGenerated]
  [SpecialName]
  public byte b() => this.n;

  [CompilerGenerated]
  [SpecialName]
  public void a(byte A_0) => this.n = A_0;

  public aj(string A_0, byte A_1)
  {
    this.a(A_0);
    this.a(new ArrayList());
    this.b(new ArrayList());
    this.a(A_1);
    this.m = 0U;
    this.a(0);
    this.b(0);
    this.a(DateTime.Now);
    this.c(0);
    this.d(0);
    this.f(0);
    this.g(0);
    this.e(0);
  }

  public aj a()
  {
    aj aj = new aj(this.o(), this.b());
    aj.m = this.m;
    aj.b((ArrayList) this.l().Clone());
    aj.c(this.f());
    aj.a(this.c());
    aj.b(this.d());
    aj.a(this.e());
    aj.a(this.n());
    aj.a((ArrayList) this.k().Clone());
    aj.d(this.g());
    aj.f(this.i());
    aj.g(this.j());
    aj.e(this.h());
    return aj;
  }

  public void d(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("ev name " + this.o() + "\n"), 0, unicodeEncoding.GetByteCount("ev name " + this.o() + "\n"));
    A_0.Write(unicodeEncoding.GetBytes("ev clines " + Convert.ToString(this.k().Count) + "\n"), 0, unicodeEncoding.GetByteCount("ev clines " + Convert.ToString(this.k().Count) + "\n"));
    for (int index = 0; index < this.k().Count; ++index)
      A_0.Write(unicodeEncoding.GetBytes("evcode " + (string) this.k()[index] + "\n"), 0, unicodeEncoding.GetByteCount("evcode " + (string) this.k()[index] + "\n"));
  }

  public void c(MemoryStream A_0)
  {
    this.k().Clear();
    string str1 = ad.a(A_0);
    if (str1.Substring(0, 8) != "ev name ")
      throw new InvalidOperationException("Неверный формат файла");
    this.a(str1.Substring(8));
    string str2 = ad.a(A_0);
    int num = !(str2.Substring(0, 10) != "ev clines ") ? Convert.ToInt32(str2.Substring(10)) : throw new InvalidOperationException("Неверный формат файла");
    for (int index = 0; index < num; ++index)
    {
      string str3 = ad.a(A_0);
      if (str3.Substring(0, 7) != "evcode ")
        throw new InvalidOperationException("Неверный формат файла");
      this.k().Add((object) str3.Substring(7));
      this.l().Add((object) ad.a(str3.Substring(7), (int) this.b()));
    }
  }

  public void b(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("ev name " + this.o() + "\n"), 0, unicodeEncoding.GetByteCount("ev name " + this.o() + "\n"));
    A_0.Write(unicodeEncoding.GetBytes("ev CRC " + this.m.ToString() + "\n"), 0, unicodeEncoding.GetByteCount("ev CRC " + this.m.ToString() + "\n"));
    A_0.Write(unicodeEncoding.GetBytes("ev LastEditDate " + this.e().ToString() + "\n"), 0, unicodeEncoding.GetByteCount("ev LastEditDate " + this.e().ToString() + "\n"));
    A_0.Write(unicodeEncoding.GetBytes("ev EditNumber " + this.d().ToString() + "\n"), 0, unicodeEncoding.GetByteCount("ev EditNumber " + this.d().ToString() + "\n"));
    A_0.Write(unicodeEncoding.GetBytes("ev EditTime " + this.c().ToString() + "\n"), 0, unicodeEncoding.GetByteCount("ev EditTime " + this.c().ToString() + "\n"));
  }

  public void a(MemoryStream A_0)
  {
    string str1 = !(ad.a(A_0) != "ev name " + this.o()) ? ad.a(A_0) : throw new InvalidOperationException("Неверный формат файла");
    this.m = !(str1.Substring(0, 7) != "ev CRC ") ? Convert.ToUInt32(str1.Substring(7)) : throw new InvalidOperationException("Неверный формат файла");
    string str2 = ad.a(A_0);
    if (str2.Substring(0, 16) != "ev LastEditDate ")
      throw new InvalidOperationException("Неверный формат файла");
    this.a(Convert.ToDateTime(str2.Substring(16)));
    string str3 = ad.a(A_0);
    if (str3.Substring(0, 14) != "ev EditNumber ")
      throw new InvalidOperationException("Неверный формат файла");
    this.b(Convert.ToInt32(str3.Substring(14)));
    string str4 = ad.a(A_0);
    if (str4.Substring(0, 12) != "ev EditTime ")
      throw new InvalidOperationException("Неверный формат файла");
    this.a(Convert.ToInt32(str4.Substring(12)));
  }

  public void a(SortedList A_0, LayerParticipant A_1, Participant A_2, MainWindow A_3)
  {
    if (A_0 == null)
      A_0 = new SortedList();
    new ai(A_0, this, A_1, A_2, A_3).a();
  }
}
