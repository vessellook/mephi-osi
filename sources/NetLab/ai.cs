// Decompiled with JetBrains decompiler
// Type: ai
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

#nullable disable
public class ai
{
  private global::v a;
  private am b;
  private ak c;
  private aj d;
  private SortedList e;
  private int f;
  private Stack g;
  private an h;

  public ai(SortedList A_0, aj A_1, ak A_2, am A_3, global::v A_4)
  {
    this.e = A_0;
    this.d = A_1;
    this.c = A_2;
    this.b = A_3;
    this.a = A_4;
    this.h = A_4.c();
    this.g = new Stack();
  }

  private af p(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    af af1 = this.a(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ',')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorCommaExpected);
    A_0 = A_0.Remove(0, 1);
    string str = ad.d(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    af af2;
    if (this.c.e.ContainsKey((object) str))
      af2 = (af) this.c.e[(object) str];
    else
      af2 = this.e.ContainsKey((object) str) ? (af) this.e[(object) str] : throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
    return af1.h() != ac.b ? new af("Internal", (object) 0, ac.a) : (af2.h() != ac.b ? new af("Internal", (object) 0, ac.a) : new af("Internal", (object) (af2.c().IndexOf(af1.c()) + 1), ac.a));
  }

  private af o(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    string key = ad.d(ref A_0);
    if (this.c.e.ContainsKey((object) key))
    {
      if ((this.c.e[(object) key] as af).h() == ac.b)
      {
        ad.e(ref A_0);
        if (A_0.Length == 0 || A_0[0] != ',')
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorCommaExpected);
        A_0 = A_0.Remove(0, 1);
        af af1 = this.a(ref A_0);
        ad.e(ref A_0);
        if (A_0.Length == 0 || A_0[0] != ',')
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorCommaExpected);
        A_0 = A_0.Remove(0, 1);
        af af2 = this.a(ref A_0);
        ad.e(ref A_0);
        if (A_0.Length == 0 || A_0[0] != ')')
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
        A_0 = A_0.Remove(0, 1);
        if (af1.h() != ac.a || af2.h() != ac.a)
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpCopyArgNotInt);
        if (af1.e() + af2.e() - 1 > (this.c.e[(object) key] as af).c().Length)
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpCopyStringTooShort);
        return new af("Internal", (object) (this.c.e[(object) key] as af).c().Substring(af1.e() - 1, af2.e()), ac.b);
      }
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpDeleteNotString.Replace("%s", A_0));
    }
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", A_0));
  }

  private af n(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    af af = this.a(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    if (af.h() == ac.b)
    {
      switch (af.c())
      {
        case "Guide":
          return new af("Internal", (object) new int[6]
          {
            0,
            (int) byte.MaxValue,
            0,
            0,
            100,
            100
          }, ac.c);
        case "SystemA":
          return new af("Internal", (object) new int[6]
          {
            0,
            (int) this.h.d().c(),
            0,
            0,
            100,
            100
          }, ac.c);
        default:
          return new af("Internal", (object) new int[6]
          {
            3,
            0,
            0,
            0,
            100,
            100
          }, ac.c);
      }
    }
    else
    {
      if (af.h() == ac.a)
      {
        if (af.e() == (int) this.h.d().c())
          return new af("Internal", (object) "SystemA", ac.b);
        if (af.e() == (int) this.h.b().c())
          return new af("Internal", (object) "SystemB", ac.b);
        return af.e() == (int) this.h.c().c() ? new af("Internal", (object) "Guide", ac.b) : new af("Internal", (object) "Unknown", ac.b);
      }
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorWrongType.ToString().Replace("Переменная %s -", ""));
    }
  }

  private af m(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    string str = ad.d(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    af af;
    if (this.c.e.ContainsKey((object) str))
      af = (af) this.c.e[(object) str];
    else
      af = this.e.ContainsKey((object) str) ? (af) this.e[(object) str] : throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
    return !af.g() ? new af("Internal", (object) 0, ac.a) : (af.h() != ac.a ? new af("Internal", (object) (af.h() == ac.b ? af.c().Length : af.b().Length), ac.a) : new af("Internal", (object) 1, ac.a));
  }

  private af l(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    return new af("Internal", (object) this.b.b(), ac.b);
  }

  private af k(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    return new af("Internal", (object) this.h.h, ac.a);
  }

  public static int a(int A_0)
  {
    RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
    byte[] data = new byte[4];
    if (A_0 <= 1)
      return 0;
    uint num = uint.MaxValue - uint.MaxValue % (uint) A_0;
    uint uint32;
    do
    {
      cryptoServiceProvider.GetBytes(data);
      uint32 = BitConverter.ToUInt32(data, 0);
    }
    while (uint32 >= num);
    return (int) ((long) uint32 % (long) A_0);
  }

  private af j(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    af af = this.a(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    return new af("Internal", (object) an.k.Next(af.e()), ac.a);
  }

  private af i(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    string str = ad.d(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    if (this.c.f.ContainsKey((object) str))
      return (this.c.f[(object) str] as ag).c();
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
  }

  private af h(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    string str = ad.d(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    if (this.c.f.ContainsKey((object) str))
      return (this.c.f[(object) str] as ag).b();
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
  }

  private af g(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != '(')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorOpenBracketExpected);
    A_0 = A_0.Remove(0, 1);
    string str = ad.d(ref A_0);
    ad.e(ref A_0);
    if (A_0.Length == 0 || A_0[0] != ')')
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
    A_0 = A_0.Remove(0, 1);
    if (this.c.f.ContainsKey((object) str))
      return new af("Internal", (object) (this.c.f[(object) str] as ag).a(), ac.a);
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
  }

  private af f(ref string A_0)
  {
    ad.e(ref A_0);
    if (A_0.Length == 0)
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorNoValue);
    af af;
    switch (A_0[0])
    {
      case '"':
        A_0 = A_0.Remove(0, 1);
        af = A_0.IndexOf('"') >= 0 ? new af("Internal", (object) A_0.Substring(0, A_0.IndexOf('"')), ac.b) : throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorEndOfStringNotFound);
        A_0 = A_0.Remove(0, A_0.IndexOf('"') + 1);
        break;
      case '#':
        A_0 = A_0.Remove(0, 1);
        string s1 = ad.d(ref A_0);
        int result1;
        if (int.TryParse(s1, out result1))
        {
          af = new af("Internal", (object) Convert.ToChar(result1).ToString(), ac.b);
          break;
        }
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + s1 + Resources.ErrorNotNumber);
      case '$':
        A_0 = A_0.Remove(0, 1);
        string str = ad.d(ref A_0);
        if (this.c.e.ContainsKey((object) str))
        {
          af = ((af) this.c.e[(object) str]).a();
          break;
        }
        af = this.e.ContainsKey((object) str) ? ((af) this.e[(object) str]).a() : throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
        break;
      case '(':
        A_0 = A_0.Remove(0, 1);
        af = this.a(ref A_0);
        if (A_0[0] != ')')
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorNoClosingBracket);
        A_0 = A_0.Remove(0, 1);
        break;
      default:
        string s2 = ad.d(ref A_0);
        if (s2 != null)
        {
          switch (s2.Length)
          {
            case 3:
              if (s2 == "pos")
              {
                af = this.p(ref A_0);
                goto label_44;
              }
              else
                break;
            case 4:
              switch (s2[0])
              {
                case 'c':
                  if (s2 == "copy")
                  {
                    af = this.o(ref A_0);
                    goto label_44;
                  }
                  else
                    break;
                case 'p':
                  if (s2 == "peek")
                  {
                    af = this.h(ref A_0);
                    goto label_44;
                  }
                  else
                    break;
              }
              break;
            case 6:
              switch (s2[0])
              {
                case 'q':
                  if (s2 == "qcount")
                  {
                    af = this.g(ref A_0);
                    goto label_44;
                  }
                  else
                    break;
                case 'r':
                  if (s2 == "random")
                  {
                    af = this.j(ref A_0);
                    goto label_44;
                  }
                  else
                    break;
                case 's':
                  if (s2 == "sizeof")
                  {
                    af = this.m(ref A_0);
                    goto label_44;
                  }
                  else
                    break;
              }
              break;
            case 7:
              if (s2 == "dequeue")
              {
                af = this.i(ref A_0);
                goto label_44;
              }
              else
                break;
            case 8:
              if (s2 == "locguide")
              {
                af = this.n(ref A_0);
                goto label_44;
              }
              else
                break;
            case 10:
              if (s2 == "SystemTime")
              {
                af = this.k(ref A_0);
                goto label_44;
              }
              else
                break;
            case 17:
              if (s2 == "CurrentSystemName")
              {
                af = this.l(ref A_0);
                goto label_44;
              }
              else
                break;
          }
        }
        int result2;
        if (int.TryParse(s2, out result2))
        {
          af = new af("Internal", (object) result2, ac.a);
          break;
        }
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + s2 + Resources.ErrorNotNumber);
    }
label_44:
    return af;
  }

  private af e(ref string A_0)
  {
    ad.e(ref A_0);
    af af;
    switch (ad.d(A_0))
    {
      case "!!":
        A_0 = A_0.Remove(0, 2);
        af = this.f(ref A_0);
        af.a(!af.d());
        break;
      case "!":
        A_0 = A_0.Remove(0, 1);
        af = this.f(ref A_0);
        af.a(-af.e() - 1);
        break;
      case "-":
        A_0 = A_0.Remove(0, 1);
        af = this.f(ref A_0);
        af.a(-af.e());
        break;
      default:
        af = this.f(ref A_0);
        break;
    }
    return af;
  }

  private af d(ref string A_0)
  {
    ad.e(ref A_0);
    af af1 = this.e(ref A_0).a();
    af1.b("Internal");
    while (true)
    {
      ad.e(ref A_0);
      if (ad.d(A_0) == "*")
      {
        A_0 = A_0.Remove(0, 1);
        af af2 = this.f(ref A_0);
        af1.a(af1.e() * af2.e());
      }
      else if (ad.d(A_0) == "/")
      {
        A_0 = A_0.Remove(0, 1);
        af af3 = this.f(ref A_0);
        af1.a(af1.e() / af3.e());
      }
      else if (ad.d(A_0) == "%")
      {
        A_0 = A_0.Remove(0, 1);
        af af4 = this.f(ref A_0);
        af1.a(af1.e() % af4.e());
      }
      else
        break;
    }
    return af1;
  }

  private af c(ref string A_0)
  {
    ad.e(ref A_0);
    af af1 = this.d(ref A_0);
    while (true)
    {
      ad.e(ref A_0);
      if (ad.d(A_0) == "+")
      {
        A_0 = A_0.Remove(0, 1);
        af af2 = this.d(ref A_0);
        if (af1.h() == ac.b && af2.h() == ac.b)
          af1.a(af1.c() + af2.c());
        else
          af1.a(af1.e() + af2.e());
      }
      else if (ad.d(A_0) == "-")
      {
        A_0 = A_0.Remove(0, 1);
        af af3 = this.d(ref A_0);
        af1.a(af1.e() - af3.e());
      }
      else if (ad.d(A_0) == "&")
      {
        A_0 = A_0.Remove(0, 1);
        af af4 = this.d(ref A_0);
        af1.a(af1.e() & af4.e());
      }
      else if (ad.d(A_0) == "|")
      {
        A_0 = A_0.Remove(0, 1);
        af af5 = this.d(ref A_0);
        af1.a(af1.e() | af5.e());
      }
      else
        break;
    }
    return af1;
  }

  private af b(ref string A_0)
  {
    ad.e(ref A_0);
    af af1 = this.c(ref A_0);
    while (true)
    {
      ad.e(ref A_0);
      if (ad.d(A_0) == "&&")
      {
        A_0 = A_0.Remove(0, 2);
        af af2 = this.c(ref A_0);
        af1.a(af1.d() && af2.d());
      }
      else if (ad.d(A_0) == "||")
      {
        A_0 = A_0.Remove(0, 2);
        af af3 = this.c(ref A_0);
        af1.a(af1.d() || af3.d());
      }
      else
        break;
    }
    return af1;
  }

  private af a(ref string A_0)
  {
    ad.e(ref A_0);
    af af1 = this.b(ref A_0);
    while (true)
    {
      ad.e(ref A_0);
      if (ad.d(A_0) == ">")
      {
        A_0 = A_0.Remove(0, 1);
        af af2 = this.b(ref A_0);
        if (af1.h() == ac.b && af2.h() == ac.b)
        {
          af af3 = new af();
          af3.a(af1.c().Length > af2.c().Length);
          af1 = af3;
        }
        else
          af1.a(af1.e() > af2.e());
      }
      else
      {
        if (ad.d(A_0) == "<")
        {
          A_0 = A_0.Remove(0, 1);
          af af4 = this.b(ref A_0);
          if (af1.h() == ac.b && af4.h() == ac.b)
          {
            af af5 = new af();
            af5.a(af1.c().Length < af4.c().Length);
            af1 = af5;
          }
          else
            af1.a(af1.e() < af4.e());
        }
        if (ad.d(A_0) == "<=")
        {
          A_0 = A_0.Remove(0, 2);
          af af6 = this.b(ref A_0);
          if (af1.h() == ac.b && af6.h() == ac.b)
          {
            af af7 = new af();
            af7.a(af1.c().Length <= af6.c().Length);
            af1 = af7;
          }
          else
            af1.a(af1.e() <= af6.e());
        }
        else if (ad.d(A_0) == ">=")
        {
          A_0 = A_0.Remove(0, 2);
          af af8 = this.b(ref A_0);
          if (af1.h() == ac.b && af8.h() == ac.b)
          {
            af af9 = new af();
            af9.a(af1.c().Length >= af8.c().Length);
            af1 = af9;
          }
          else
            af1.a(af1.e() >= af8.e());
        }
        else if (ad.d(A_0) == "==")
        {
          A_0 = A_0.Remove(0, 2);
          af af10 = this.b(ref A_0);
          if (af1.h() == ac.b && af10.h() == ac.b)
          {
            af af11 = new af();
            af11.a(af1.c() == af10.c());
            af1 = af11;
          }
          else
            af1.a(af1.e() == af10.e());
        }
        else if (ad.d(A_0) == "!=")
        {
          A_0 = A_0.Remove(0, 2);
          af af12 = this.b(ref A_0);
          if (af1.h() == ac.b && af12.h() == ac.b)
          {
            af af13 = new af();
            af13.a(af1.c() != af12.c());
            af1 = af13;
          }
          else
            af1.a(af1.e() != af12.e());
        }
        else
          break;
      }
    }
    return af1;
  }

  private void a(string A_0, string A_1, string A_2)
  {
    SortedList A_2_1 = new SortedList();
    ad.e(ref A_2);
    while (A_2.Length > 0)
    {
      string key = ad.d(ref A_2);
      ad.e(ref A_2);
      af af = this.a(ref A_2);
      A_2_1.Add((object) key, (object) af);
      ad.e(ref A_2);
    }
    this.b.a(A_0, A_1, A_2_1);
  }

  private int w(string A_0)
  {
    for (int index = 0; index < this.d.l().Count; ++index)
    {
      string A_0_1 = (string) this.d.l()[index];
      ad.e(ref A_0_1);
      string str = ad.c(A_0_1);
      if (str.Length > 0 && str[str.Length - 1] == ':' && str.Substring(0, str.Length - 1) == A_0)
        return index;
    }
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorLabelNotFound.Replace("%s", A_0));
  }

  private int v(string A_0)
  {
    for (int index = 0; index < this.d.l().Count; ++index)
    {
      string A_0_1 = (string) this.d.l()[index];
      ad.e(ref A_0_1);
      string str = ad.d(ref A_0_1);
      if (str.Length > 0 && str == "substart")
      {
        ad.e(ref A_0_1);
        if (ad.c(A_0_1) == A_0)
          return index;
      }
    }
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorSubNotFound.Replace("%s", A_0));
  }

  private void u(string A_0)
  {
    string str1 = ad.d(ref A_0);
    string str2 = ad.d(ref A_0);
    if (str1.Length == 0)
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpDeclareNoVar);
    if (str2 == "queue")
    {
      if (this.c.f.IndexOfKey((object) str1) == -1)
      {
        ag ag = new ag(str1);
        this.c.f.Add((object) str1, (object) ag);
      }
      else
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpDeclareQueueExists.Replace("%s", str1));
    }
    else if (this.c.e.IndexOfKey((object) str1) == -1)
    {
      af af;
      switch (str2)
      {
        case "integer":
          af = new af(str1, (object) 0, ac.a);
          break;
        case "buffer":
          af = new af(str1, (object) new int[0], ac.c);
          break;
        case "string":
          af = new af(str1, (object) "", ac.b);
          break;
        default:
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpDeclareUnknownType + str2 + ".");
      }
      this.c.e.Add((object) af.f(), (object) af);
    }
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpDeclareVarExists.Replace("%s", str1));
  }

  private void t(string A_0)
  {
    string str1 = ad.d(ref A_0);
    if (this.c.e.ContainsKey((object) str1))
    {
      af af = this.a(ref A_0);
      if (af.h() != (this.c.e[(object) str1] as af).h())
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorWrongType.Replace("%s", str1));
      switch (af.h())
      {
        case ac.a:
          (this.c.e[(object) str1] as af).a(af.e());
          break;
        case ac.b:
          (this.c.e[(object) str1] as af).a(af.c());
          break;
        case ac.c:
          (this.c.e[(object) str1] as af).a(af.b());
          break;
      }
    }
    else if (this.c.f.ContainsKey((object) str1))
    {
      ad.e(ref A_0);
      A_0 = A_0[0] == '$' ? A_0.Remove(0, 1) : throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorSetQueueNotS);
      string str2 = ad.d(ref A_0);
      if (!this.c.f.ContainsKey((object) str2))
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str2));
      this.c.f[(object) str1] = (object) (this.c.f[(object) str2] as ag).a(str1);
    }
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str1));
  }

  private void s(string A_0)
  {
    string str = ad.d(ref A_0);
    if (this.c.e.ContainsKey((object) str))
    {
      af af = this.a(ref A_0);
      if (af.h() == ac.b)
      {
        switch (af.c())
        {
          case "SystemA":
            (this.c.e[(object) str] as af).a((int) this.a.c().d().c());
            break;
          case "SystemB":
            (this.c.e[(object) str] as af).a((int) this.a.c().b().c());
            break;
          case "Guide":
            (this.c.e[(object) str] as af).a((int) this.a.c().c().c());
            break;
          default:
            throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorWrongSystem);
        }
      }
      else
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorWrongType.Replace("%s", str));
    }
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
  }

  private void r(string A_0)
  {
    string str = ad.d(ref A_0);
    if (this.c.e.ContainsKey((object) str))
    {
      if ((this.c.e[(object) str] as af).h() == ac.b)
      {
        af af1 = this.a(ref A_0);
        af af2 = this.a(ref A_0);
        if (af1.h() != ac.a || af2.h() != ac.a)
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpDeleteArgNotInt);
        if (af1.e() + af2.e() - 1 > (this.c.e[(object) str] as af).c().Length)
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpDeleteStringTooShort);
        (this.c.e[(object) str] as af).a((this.c.e[(object) str] as af).c().Remove(af1.e() - 1, af2.e()));
      }
      else
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpDeleteNotString.Replace("%s", str));
    }
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
  }

  private void q(string A_0)
  {
    if (an.f || this.a.dm.Checked && this.c.k() == "Transport" || this.a.dn.Checked && this.c.k() == "Session" || this.a.dp.Checked && this.c.k() == "Presentation" || this.a.dq.Checked && this.c.k() == "Application" || this.a.dr.Checked && this.c.k() == "UE" || this.a.ds.Checked && this.c.k() == "Process" || this.a.dl.Checked && this.c.k() == "Network")
      return;
    StringBuilder stringBuilder = new StringBuilder();
    ad.e(ref A_0);
    while (A_0.Length > 0)
    {
      af af = this.a(ref A_0);
      switch (af.h())
      {
        case ac.a:
          stringBuilder.Append(af.e());
          break;
        case ac.b:
          stringBuilder.Append(af.c());
          break;
        case ac.c:
          stringBuilder.Append(af.b().Length);
          break;
      }
      ad.e(ref A_0);
    }
    this.h.b(stringBuilder.ToString());
  }

  private void p(string A_0)
  {
    StringBuilder stringBuilder = new StringBuilder();
    ad.e(ref A_0);
    while (A_0.Length > 0)
    {
      af af = this.a(ref A_0);
      switch (af.h())
      {
        case ac.a:
          stringBuilder.Append(af.e());
          break;
        case ac.b:
          stringBuilder.Append(af.c());
          break;
        case ac.c:
          stringBuilder.Append(af.b().Length);
          break;
      }
      ad.e(ref A_0);
    }
    this.h.b(stringBuilder.ToString());
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + " " + stringBuilder.ToString());
  }

  private void o(string A_0)
  {
    string A_1 = ad.d(ref A_0);
    string A_0_1;
    switch (this.c.k())
    {
      case "Network":
        A_0_1 = "Transport";
        break;
      case "Transport":
        A_0_1 = "Session";
        break;
      case "Session":
        A_0_1 = "Presentation";
        break;
      case "Presentation":
        A_0_1 = "Application";
        break;
      case "Application":
        A_0_1 = "UE";
        break;
      case "UE":
        A_0_1 = "Process";
        break;
      default:
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorUnknownLevel + this.c.k());
    }
    if (A_1.Length > 4 && A_1.Substring(A_1.Length - 4) == ".IND" || A_1.Length > 5 && A_1.Substring(A_1.Length - 5) == ".CONF")
      this.a(A_0_1, A_1, A_0);
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpUp);
  }

  private void n(string A_0)
  {
    string A_1 = ad.d(ref A_0);
    string A_0_1;
    switch (this.c.k())
    {
      case "Transport":
        A_0_1 = "Network";
        break;
      case "Session":
        A_0_1 = "Transport";
        break;
      case "Presentation":
        A_0_1 = "Session";
        break;
      case "Application":
        A_0_1 = "Presentation";
        break;
      case "UE":
        A_0_1 = "Application";
        break;
      case "Process":
        A_0_1 = "UE";
        break;
      default:
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorUnknownLevel + this.c.k());
    }
    if (A_1.Length > 4 && A_1.Substring(A_1.Length - 4) == ".REQ" || A_1.Length > 5 && A_1.Substring(A_1.Length - 5) == ".RESP")
      this.a(A_0_1, A_1, A_0);
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpDown);
  }

  private void m(string A_0)
  {
    string A_0_1 = ad.d(ref A_0);
    string str = ad.d(ref A_0);
    af af1 = this.a(ref A_0);
    SortedList A_1 = new SortedList();
    ad.e(ref A_0);
    while (A_0.Length > 0)
    {
      string key = ad.d(ref A_0);
      ad.e(ref A_0);
      af af2 = this.a(ref A_0);
      A_1.Add((object) key, (object) af2);
      ad.e(ref A_0);
    }
    if (this.c.e.ContainsKey((object) str))
      (this.c.e[(object) str] as af).a(this.h.a(A_0_1, A_1, this.c.k(), this.b, this.h.h + af1.e(), ((af) this.c.e[(object) str]).e()));
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
  }

  private void l(string A_0)
  {
    string A_1 = ad.d(ref A_0);
    af af1 = this.a(ref A_0);
    SortedList A_2 = new SortedList();
    ad.e(ref A_0);
    while (A_0.Length > 0)
    {
      string key = ad.d(ref A_0);
      ad.e(ref A_0);
      af af2 = this.a(ref A_0);
      A_2.Add((object) key, (object) af2);
      ad.e(ref A_0);
    }
    if (A_2.ContainsKey((object) "userdata"))
    {
      af af3 = A_2[(object) "userdata"] as af;
      if (af3.h() == ac.c)
        this.c.d.m += af3.b().Length;
    }
    switch (af1.c())
    {
      case "SystemA":
        this.h.d().a(this.c.k(), A_1, A_2);
        break;
      case "Guide":
        this.h.c().a(this.c.k(), A_1, A_2);
        break;
      case "SystemB":
        this.h.b().a(this.c.k(), A_1, A_2);
        break;
      default:
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorOpTransmitWrongSystem.Replace("%s", af1.c()));
    }
  }

  private void k(string A_0) => this.h.a(this.a(ref A_0).e());

  private void j(string A_0)
  {
    string str = ad.d(ref A_0);
    if (this.c.e.ContainsKey((object) str) && (this.c.e[(object) str] as af).h() == ac.a)
    {
      af af = this.a(ref A_0);
      byte[] numArray = af.h() == ac.c ? new byte[af.b().Length * 4] : throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + " " + (this.f + 1).ToString() + Resources.ErrorOpCrcWrongType);
      Buffer.BlockCopy((Array) af.b(), 0, (Array) numArray, 0, numArray.Length);
      (this.c.e[(object) str] as af).a((int) global::l.a(numArray));
    }
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + " " + (this.f + 1).ToString() + Resources.ErrorOpCrcNotDeclared.Replace("%s", str));
  }

  private void i(string A_0)
  {
    string str = ad.d(ref A_0);
    if (this.c.f.ContainsKey((object) str))
      (this.c.f[(object) str] as ag).a(this.a(ref A_0));
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpQueueNotDeclared.Replace("%s", str));
  }

  private void h(string A_0)
  {
    string str = ad.d(ref A_0);
    if (this.c.f.ContainsKey((object) str))
      (this.c.f[(object) str] as ag).d();
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorOpQueueNotDeclared.Replace("%s", str));
  }

  private void g(string A_0)
  {
    string str = ad.d(ref A_0);
    if (this.c.e.ContainsKey((object) str))
    {
      af af1 = this.a(ref A_0);
      int[] A_0_1 = new int[af1.e()];
      ad.e(ref A_0);
      int index1 = 0;
      while (A_0.Length > 0)
      {
        af af2 = this.a(ref A_0);
        ad.e(ref A_0);
        af af3 = this.a(ref A_0);
        ad.e(ref A_0);
        if (index1 + af3.e() > af1.e())
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorBufferTooShort);
        switch (af2.h())
        {
          case ac.a:
            A_0_1[index1] = af2.e();
            index1 += af3.e();
            continue;
          case ac.b:
            if (af3.e() > af2.c().Length)
              throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorBufferStringTooShort.Replace("%s", af2.f()));
            for (int index2 = 0; index2 < af3.e(); ++index2)
              A_0_1[index1 + index2] = index2 >= af2.c().Length ? (int) af2.c()[index2] : (int) af2.c()[index2];
            index1 += af3.e();
            continue;
          case ac.c:
            for (int index3 = 0; index3 < af3.e(); ++index3)
              A_0_1[index1 + index3] = index3 >= af2.b().Length ? af2.b()[index3] : af2.b()[index3];
            index1 += af3.e();
            continue;
          default:
            continue;
        }
      }
      (this.c.e[(object) str] as af).a(A_0_1);
    }
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + " " + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str));
  }

  private void f(string A_0)
  {
    string str1 = ad.d(ref A_0);
    if (this.c.e.ContainsKey((object) str1))
    {
      ad.e(ref A_0);
      int sourceIndex = 0;
      while (A_0.Length > 0)
      {
        string str2 = ad.d(ref A_0);
        ad.e(ref A_0);
        af af = this.a(ref A_0);
        ad.e(ref A_0);
        if (sourceIndex + af.e() > (this.c.e[(object) str1] as af).b().Length)
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorBufferTooShort);
        if (!this.c.e.Contains((object) str2))
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str2));
        switch ((this.c.e[(object) str2] as af).h())
        {
          case ac.a:
            if (af.e() != 1)
              throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorIntegerLength);
            (this.c.e[(object) str2] as af).a((this.c.e[(object) str1] as af).b()[sourceIndex]);
            sourceIndex += af.e();
            continue;
          case ac.b:
            string str3 = "";
            for (int index = 0; index < af.e(); ++index)
              str3 += ((char) (this.c.e[(object) str1] as af).b()[index + sourceIndex]).ToString();
            (this.c.e[(object) str2] as af).a(str3.ToString());
            sourceIndex += af.e();
            continue;
          case ac.c:
            int[] numArray = new int[af.e()];
            Array.Copy((Array) (this.c.e[(object) str1] as af).b(), sourceIndex, (Array) numArray, 0, af.e());
            (this.c.e[(object) str2] as af).a(numArray);
            sourceIndex += af.e();
            continue;
          default:
            continue;
        }
      }
    }
    else if (this.e.ContainsKey((object) str1))
    {
      ad.e(ref A_0);
      int sourceIndex = 0;
      while (A_0.Length > 0)
      {
        string str4 = ad.d(ref A_0);
        ad.e(ref A_0);
        af af = this.a(ref A_0);
        ad.e(ref A_0);
        if (sourceIndex + af.e() > (this.e[(object) str1] as af).b().Length)
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorBufferTooShort);
        if (!this.c.e.Contains((object) str4))
          throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str4));
        switch ((this.c.e[(object) str4] as af).h())
        {
          case ac.a:
            if (af.e() != 1)
              throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.String + (this.f + 1).ToString() + Resources.ErrorIntegerLength);
            (this.c.e[(object) str4] as af).a((this.e[(object) str1] as af).b()[sourceIndex]);
            sourceIndex += af.e();
            continue;
          case ac.b:
            string str5 = "";
            for (int index = 0; index < af.e(); ++index)
              str5 += ((char) (this.e[(object) str1] as af).b()[index + sourceIndex]).ToString();
            (this.c.e[(object) str4] as af).a(str5.ToString());
            sourceIndex += af.e();
            continue;
          case ac.c:
            int[] numArray = new int[af.e()];
            Array.Copy((Array) (this.e[(object) str1] as af).b(), sourceIndex, (Array) numArray, 0, af.e());
            (this.c.e[(object) str4] as af).a(numArray);
            sourceIndex += af.e();
            continue;
          default:
            continue;
        }
      }
    }
    else
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + " " + (this.f + 1).ToString() + Resources.ErrorVarNotDeclared.Replace("%s", str1));
  }

  private void e(string A_0) => this.f = this.w(ad.d(ref A_0));

  private void d(string A_0)
  {
    if (!this.a(ref A_0).d())
      return;
    this.f = this.w(ad.d(ref A_0));
  }

  private void c(string A_0)
  {
    if (this.g.Count > 20)
      throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorTooMuchSub);
    this.g.Push((object) this.f);
    this.f = this.v(ad.d(ref A_0));
  }

  private void b(string A_0)
  {
    throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorSubStart);
  }

  private void a(string A_0)
  {
    this.f = this.g.Count != 0 ? (int) this.g.Pop() : throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorSubEnd);
  }

  public void a()
  {
    for (int index = 0; index < this.e.Count; ++index)
    {
      if (this.c.e.ContainsKey(this.e.GetKey(index)))
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorParamInVars.Replace("%s", (string) this.e.GetKey(index)));
    }
    this.g.Clear();
    bool flag1 = this.c.k() == "Network" && this.a.c7.Checked || this.c.k() == "Transport" && this.a.c6.Checked || this.c.k() == "Session" && this.a.c5.Checked || this.c.k() == "Presentation" && this.a.c4.Checked || this.c.k() == "Application" && this.a.c3.Checked || this.c.k() == "UE" && this.a.c2.Checked || this.c.k() == "Process" && this.a.c1.Checked;
    bool flag2 = (bool) ab.layers[(object) this.c.k()];
    if (an.e > 0 & flag1)
      this.a.v.a((object[]) this.d.k().ToArray(typeof (string)), this.b.b(), this.d.o());
    if (an.e == 2 & flag1)
      an.e = 1;
    for (this.f = 0; this.f < this.d.l().Count; ++this.f)
    {
      int num;
      if (((!flag1 ? 0 : (ab.a ? 1 : 0)) & (flag2 ? 1 : 0)) != 0)
      {
        an h = this.h;
        string[] strArray = new string[7]
        {
          this.b.b(),
          " ",
          this.c.k(),
          " ",
          this.d.o(),
          " строка ",
          null
        };
        num = this.f + 1;
        strArray[6] = num.ToString();
        string A_0 = string.Concat(strArray).Replace("SystemA", "Система А").Replace("SystemB", "Система B").Replace("Guide", "Справочник");
        h.b(A_0);
      }
      string A_0_1 = (string) this.d.l()[this.f];
      ad.e(ref A_0_1);
      if (A_0_1.Length != 0)
      {
        string A_0_2 = ad.d(ref A_0_1);
        if (A_0_2.Length > 0 && A_0_2[A_0_2.Length - 1] == ':')
        {
          A_0_2 = ad.d(ref A_0_1);
          if (A_0_1.Length == 0)
            continue;
        }
        if (an.e > 0 & flag1)
          this.a.v.a(A_0_2, this.f);
        if (A_0_2 != null)
        {
          num = A_0_2.Length;
          switch (num)
          {
            case 2:
              switch (A_0_2[0])
              {
                case 'i':
                  if (A_0_2 == "if")
                  {
                    this.d(A_0_1);
                    ++this.c.d.h;
                    break;
                  }
                  goto label_79;
                case 'u':
                  if (A_0_2 == "up")
                  {
                    this.o(A_0_1);
                    ++this.c.d.b;
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            case 3:
              switch (A_0_2[0])
              {
                case 'c':
                  if (A_0_2 == "crc")
                  {
                    this.j(A_0_1);
                    ++this.c.d.k;
                    break;
                  }
                  goto label_79;
                case 'o':
                  if (A_0_2 == "out")
                  {
                    this.q(A_0_1);
                    ++this.c.d.l;
                    break;
                  }
                  goto label_79;
                case 's':
                  if (A_0_2 == "set")
                  {
                    this.t(A_0_1);
                    ++this.c.d.c;
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            case 4:
              switch (A_0_2[0])
              {
                case 'd':
                  if (A_0_2 == "down")
                  {
                    this.n(A_0_1);
                    ++this.c.d.a;
                    break;
                  }
                  goto label_79;
                case 'g':
                  if (A_0_2 == "goto")
                  {
                    this.e(A_0_1);
                    ++this.c.d.g;
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            case 5:
              switch (A_0_2[0])
              {
                case 'b':
                  if (A_0_2 == "break")
                  {
                    if (an.e != 0)
                      an.e = 1;
                    this.a.v.a((object[]) this.d.k().ToArray(typeof (string)), this.b.b(), this.d.o());
                    this.a.v.a(A_0_2, this.f);
                    break;
                  }
                  goto label_79;
                case 'o':
                  if (A_0_2 == "outon")
                  {
                    an.f = false;
                    break;
                  }
                  goto label_79;
                case 'q':
                  if (A_0_2 == "queue")
                  {
                    this.i(A_0_1);
                    ++this.c.d.f;
                    break;
                  }
                  goto label_79;
                case 't':
                  if (A_0_2 == "timer")
                  {
                    this.m(A_0_1);
                    ++this.c.d.i;
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            case 6:
              switch (A_0_2[0])
              {
                case 'b':
                  if (A_0_2 == "buffer")
                  {
                    this.g(A_0_1);
                    ++this.c.d.d;
                    break;
                  }
                  goto label_79;
                case 'd':
                  if (A_0_2 == "delete")
                  {
                    this.r(A_0_1);
                    break;
                  }
                  goto label_79;
                case 'o':
                  if (A_0_2 == "outoff")
                  {
                    an.f = true;
                    break;
                  }
                  goto label_79;
                case 'r':
                  if (A_0_2 == "return")
                  {
                    this.f = this.d.l().Count;
                    break;
                  }
                  goto label_79;
                case 's':
                  if (A_0_2 == "subend")
                  {
                    this.a(A_0_1);
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            case 7:
              switch (A_0_2[0])
              {
                case 'd':
                  if (A_0_2 == "declare")
                  {
                    this.u(A_0_1);
                    break;
                  }
                  goto label_79;
                case 's':
                  if (A_0_2 == "subprog")
                  {
                    this.c(A_0_1);
                    break;
                  }
                  goto label_79;
                case 'u':
                  if (A_0_2 == "untimer")
                  {
                    this.k(A_0_1);
                    ++this.c.d.j;
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            case 8:
              switch (A_0_2[0])
              {
                case 's':
                  if (A_0_2 == "substart")
                  {
                    this.b(A_0_1);
                    break;
                  }
                  goto label_79;
                case 't':
                  if (A_0_2 == "transmit")
                  {
                    this.l(A_0_1);
                    break;
                  }
                  goto label_79;
                case 'u':
                  if (A_0_2 == "unbuffer")
                  {
                    this.f(A_0_1);
                    ++this.c.d.e;
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            case 9:
              if (A_0_2 == "exception")
              {
                this.p(A_0_1);
                ++this.c.d.l;
                break;
              }
              goto label_79;
            case 10:
              switch (A_0_2[0])
              {
                case 'c':
                  if (A_0_2 == "clearqueue")
                  {
                    this.h(A_0_1);
                    ++this.c.d.n;
                    break;
                  }
                  goto label_79;
                case 'g':
                  if (A_0_2 == "getaddress")
                  {
                    this.s(A_0_1);
                    ++this.c.d.c;
                    break;
                  }
                  goto label_79;
                default:
                  goto label_79;
              }
              break;
            default:
              goto label_79;
          }
          if (an.e != 0 & flag1)
          {
            string[] A_0_3 = new string[this.a.v.b.Count];
            for (int index1 = 0; index1 < this.a.v.b.Count; ++index1)
            {
              if (this.c.e.ContainsKey(this.a.v.b[index1]))
              {
                switch ((this.c.e[this.a.v.b[index1]] as af).h())
                {
                  case ac.a:
                    string[] strArray1 = A_0_3;
                    int index2 = index1;
                    string str1 = this.a.v.b[index1]?.ToString();
                    num = (this.c.e[this.a.v.b[index1]] as af).e();
                    string str2 = num.ToString();
                    string str3 = str1 + ": " + str2;
                    strArray1[index2] = str3;
                    continue;
                  case ac.b:
                    A_0_3[index1] = this.a.v.b[index1]?.ToString() + ": " + (this.c.e[this.a.v.b[index1]] as af).c();
                    continue;
                  case ac.c:
                    string[] strArray2 = A_0_3;
                    int index3 = index1;
                    string str4 = this.a.v.b[index1]?.ToString();
                    num = (this.c.e[this.a.v.b[index1]] as af).b().Length;
                    string str5 = num.ToString();
                    string str6 = str4 + ": " + str5;
                    strArray2[index3] = str6;
                    continue;
                  default:
                    continue;
                }
              }
              else
                A_0_3[index1] = this.a.v.b[index1]?.ToString() + ":  Недоступное значение.";
            }
            this.a.v.a((object[]) A_0_3);
          }
          if (an.e == 1 & flag1)
            an.e = 4;
          while (an.e == 4)
            Application.DoEvents();
          continue;
        }
label_79:
        throw new InvalidOperationException(this.b.b() + " " + this.c.k() + " " + this.d.o() + Resources.ErrorInvalidOperator + A_0_2);
      }
    }
  }
}
