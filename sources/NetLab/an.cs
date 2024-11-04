// Decompiled with JetBrains decompiler
// Type: an
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
public class an
{
  private StreamWriter d;
  public static int e;
  public static bool f;
  private v g;
  public int h;
  private int i;
  private ArrayList j;
  public static Random k;

  [CompilerGenerated]
  [SpecialName]
  public am d() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void c(am A_0) => this.a = A_0;

  [CompilerGenerated]
  [SpecialName]
  public am c() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void b(am A_0) => this.b = A_0;

  [CompilerGenerated]
  [SpecialName]
  public am b() => this.c;

  [CompilerGenerated]
  [SpecialName]
  public void a(am A_0) => this.c = A_0;

  [SpecialName]
  public int a()
  {
    ++this.i;
    return this.i;
  }

  [SpecialName]
  public void b(int A_0) => this.i = A_0;

  public an(v A_0)
  {
    an.k = new Random();
    this.g = A_0;
    this.c(new am("SystemA", Convert.ToByte(an.k.Next(1, 128)), this.g, this));
    this.b(new am("Guide", byte.MaxValue, this.g, this));
    this.a(new am("SystemB", Convert.ToByte(an.k.Next(128, (int) byte.MaxValue)), this.g, this));
    this.h = 0;
    this.b(0);
    this.j = new ArrayList();
  }

  public void b(string A_0)
  {
    this.d.WriteLine("[" + this.h.ToString() + "] " + A_0);
    if (!v.m)
      return;
    this.g.c("[" + this.h.ToString() + "] " + A_0);
  }

  public int a(string A_0, SortedList A_1, string A_2, am A_3, int A_4, int A_5)
  {
    ah ah = new ah(A_0, A_1, A_2, A_3, A_4, 0);
    for (int index = 0; index < this.j.Count; ++index)
    {
      if ((this.j[index] as ah).b() == A_5)
        ah.a(A_5);
    }
    if (ah.b() == 0)
      ah.a(this.a());
    this.j.Add((object) ah);
    return ah.b();
  }

  public void a(int A_0)
  {
    for (int index = 0; index < this.j.Count; ++index)
    {
      if ((this.j[index] as ah).b() == A_0)
        (this.j[index] as ah).a(true);
    }
  }

  public void a(string A_0)
  {
    try
    {
      using (this.d = File.CreateText(A_0))
      {
        try
        {
          this.d().e().a();
          this.d().f().a();
          this.d().g().a();
          this.d().h().a();
          this.d().i().a();
          this.d().j().a();
          this.d().k().a();
          this.c().e().a();
          this.c().f().a();
          this.c().g().a();
          this.c().h().a();
          this.c().i().a();
          this.c().j().a();
          this.c().k().a();
          this.b().e().a();
          this.b().f().a();
          this.b().g().a();
          this.b().h().a();
          this.b().i().a();
          this.b().j().a();
          this.b().k().a();
          this.b(Resources.EmulationStarted);
          this.d().b("NetworkEmulator", "N_INIT.REQ", (SortedList) null);
          this.c().b("NetworkEmulator", "N_INIT.REQ", (SortedList) null);
          this.b().b("NetworkEmulator", "N_INIT.REQ", (SortedList) null);
          an.f = false;
          while (this.j.Count > 0)
          {
            for (int index = this.j.Count - 1; index >= 0; --index)
            {
              if ((this.j[index] as ah).a())
                this.j.RemoveAt(index);
            }
            Application.DoEvents();
            if (an.e == 6)
            {
              this.b(Resources.EmulationCancelled);
              this.j.Clear();
            }
            ++this.h;
            for (int index1 = this.j.Count - 1; index1 >= 0; --index1)
            {
              if ((this.j[index1] as ah).c() <= this.h)
              {
                if (an.e > 0 && (this.j[index1] as ah).g().Length > 1 && (this.j[index1] as ah).g()[1] == '_' && ((this.j[index1] as ah).g().EndsWith(".IND") || (this.j[index1] as ah).g().EndsWith(".CONF")))
                {
                  this.g.v.ap.Text = (this.j[index1] as ah).g();
                  switch ((this.j[index1] as ah).d().b())
                  {
                    case "SystemA":
                      this.g.v.ap.Left = 60 - this.g.v.ap.Width / 2;
                      break;
                    case "Guide":
                      this.g.v.ap.Left = 175 - this.g.v.ap.Width / 2;
                      break;
                    case "SystemB":
                      this.g.v.ap.Left = 290 - this.g.v.ap.Width / 2;
                      break;
                  }
                  string str = (this.j[index1] as ah).e();
                  if (str != null)
                  {
                    switch (str.Length)
                    {
                      case 2:
                        if (str == "UE")
                        {
                          this.g.v.ap.Top = 85;
                          break;
                        }
                        break;
                      case 7:
                        switch (str[0])
                        {
                          case 'N':
                            if (str == "Network")
                            {
                              this.g.v.ap.Top = 285;
                              break;
                            }
                            break;
                          case 'P':
                            if (str == "Process")
                            {
                              this.g.v.ap.Top = 45;
                              break;
                            }
                            break;
                          case 'S':
                            if (str == "Session")
                            {
                              this.g.v.ap.Top = 205;
                              break;
                            }
                            break;
                        }
                        break;
                      case 9:
                        if (str == "Transport")
                        {
                          this.g.v.ap.Top = 245;
                          break;
                        }
                        break;
                      case 11:
                        if (str == "Application")
                        {
                          this.g.v.ap.Top = 125;
                          break;
                        }
                        break;
                      case 12:
                        if (str == "Presentation")
                        {
                          this.g.v.ap.Top = 165;
                          break;
                        }
                        break;
                    }
                  }
                  for (int index2 = 0; index2 < 37; ++index2)
                  {
                    --this.g.v.ap.Top;
                    this.g.v.Update();
                    Application.DoEvents();
                    Thread.Sleep(v.ag);
                  }
                }
                else if (an.e > 0 && (this.j[index1] as ah).g().Length > 1 && (this.j[index1] as ah).g()[1] == '_' && ((this.j[index1] as ah).g().EndsWith(".REQ") || (this.j[index1] as ah).g().EndsWith(".RESP")))
                {
                  this.g.v.ap.Text = (this.j[index1] as ah).g();
                  switch ((this.j[index1] as ah).d().b())
                  {
                    case "SystemA":
                      this.g.v.ap.Left = 60 - this.g.v.ap.Width / 2;
                      break;
                    case "Guide":
                      this.g.v.ap.Left = 175 - this.g.v.ap.Width / 2;
                      break;
                    case "SystemB":
                      this.g.v.ap.Left = 290 - this.g.v.ap.Width / 2;
                      break;
                  }
                  string str = (this.j[index1] as ah).e();
                  if (str != null)
                  {
                    switch (str.Length)
                    {
                      case 2:
                        if (str == "UE")
                        {
                          this.g.v.ap.Top = 45;
                          break;
                        }
                        break;
                      case 7:
                        switch (str[0])
                        {
                          case 'N':
                            if (str == "Network")
                            {
                              this.g.v.ap.Top = 205;
                              break;
                            }
                            break;
                          case 'P':
                            if (str == "Process")
                            {
                              this.g.v.ap.Top = 45;
                              break;
                            }
                            break;
                          case 'S':
                            if (str == "Session")
                            {
                              this.g.v.ap.Top = 125;
                              break;
                            }
                            break;
                        }
                        break;
                      case 9:
                        if (str == "Transport")
                        {
                          this.g.v.ap.Top = 165;
                          break;
                        }
                        break;
                      case 11:
                        if (str == "Application")
                        {
                          this.g.v.ap.Top = 45;
                          break;
                        }
                        break;
                      case 12:
                        if (str == "Presentation")
                        {
                          this.g.v.ap.Top = 85;
                          break;
                        }
                        break;
                    }
                  }
                  for (int index3 = 0; index3 < 37; ++index3)
                  {
                    ++this.g.v.ap.Top;
                    this.g.v.Update();
                    Application.DoEvents();
                    Thread.Sleep(v.ag);
                  }
                }
                this.g.v.ap.Text = "";
                (this.j[index1] as ah).d().b((this.j[index1] as ah).e(), (this.j[index1] as ah).g(), (this.j[index1] as ah).f());
                this.j.RemoveAt(index1);
              }
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, "NetLab", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        finally
        {
          this.b(Resources.EmulationEnded);
          this.d.Close();
          this.d().e().e.Clear();
          this.d().e().f.Clear();
          this.d().f().e.Clear();
          this.d().f().f.Clear();
          this.d().g().e.Clear();
          this.d().g().f.Clear();
          this.d().h().e.Clear();
          this.d().h().f.Clear();
          this.d().i().e.Clear();
          this.d().i().f.Clear();
          this.d().j().e.Clear();
          this.d().j().f.Clear();
          this.d().k().e.Clear();
          this.d().k().f.Clear();
          this.c().e().e.Clear();
          this.c().e().f.Clear();
          this.c().f().e.Clear();
          this.c().f().f.Clear();
          this.c().g().e.Clear();
          this.c().g().f.Clear();
          this.c().h().e.Clear();
          this.c().h().f.Clear();
          this.c().i().e.Clear();
          this.c().i().f.Clear();
          this.c().j().e.Clear();
          this.c().j().f.Clear();
          this.c().k().e.Clear();
          this.c().k().f.Clear();
          this.b().e().e.Clear();
          this.b().e().f.Clear();
          this.b().f().e.Clear();
          this.b().f().f.Clear();
          this.b().g().e.Clear();
          this.b().g().f.Clear();
          this.b().h().e.Clear();
          this.b().h().f.Clear();
          this.b().i().e.Clear();
          this.b().i().f.Clear();
          this.b().j().e.Clear();
          this.b().j().f.Clear();
          this.b().k().e.Clear();
          this.b().k().f.Clear();
          this.h = 0;
          this.i = 0;
          this.j.Clear();
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, "NetLab", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }
}
