// Decompiled with JetBrains decompiler
// Type: at
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
public class at : Form
{
  private MainWindow a;
  private ak b;
  private int c;
  private int d;
  private IContainer e;
  private ComboBox f;
  private Label g;
  private ListBox h;
  private Label i;
  private ListBox j;
  private ListBox k;
  private ListBox l;
  private Panel m;
  private Label n;
  private Label o;
  private Button p;
  private Button q;
  private Button r;

  public at(MainWindow A_0)
  {
    this.a();
    this.a = A_0;
  }

  private void a(aj A_0, ref aq A_1)
  {
    for (int index = 0; index < A_0.l().Count; ++index)
    {
      string A_0_1 = (string) A_0.l()[index];
      if (A_0_1.Length != 0 && A_0_1[0] != ';')
      {
        string str = ad.d(ref A_0_1);
        if (str[str.Length - 1] == ':')
          str = ad.d(ref A_0_1);
        if (str != null)
        {
          switch (str.Length)
          {
            case 2:
              switch (str[0])
              {
                case 'i':
                  if (str == "if")
                  {
                    ++A_1.h;
                    continue;
                  }
                  continue;
                case 'u':
                  if (str == "up")
                  {
                    ++A_1.b;
                    continue;
                  }
                  continue;
                default:
                  continue;
              }
            case 3:
              switch (str[0])
              {
                case 'c':
                  if (str == "crc")
                  {
                    ++A_1.k;
                    continue;
                  }
                  continue;
                case 'o':
                  if (str == "out")
                  {
                    ++A_1.l;
                    continue;
                  }
                  continue;
                case 's':
                  if (str == "set")
                  {
                    ++A_1.c;
                    continue;
                  }
                  continue;
                default:
                  continue;
              }
            case 4:
              switch (str[0])
              {
                case 'd':
                  if (str == "down")
                  {
                    ++A_1.a;
                    continue;
                  }
                  continue;
                case 'g':
                  if (str == "goto")
                  {
                    ++A_1.g;
                    continue;
                  }
                  continue;
                default:
                  continue;
              }
            case 5:
              switch (str[0])
              {
                case 'q':
                  if (str == "queue")
                  {
                    ++A_1.f;
                    continue;
                  }
                  continue;
                case 't':
                  if (str == "timer")
                  {
                    ++A_1.i;
                    continue;
                  }
                  continue;
                default:
                  continue;
              }
            case 6:
              if (str == "buffer")
              {
                ++A_1.d;
                continue;
              }
              continue;
            case 7:
              if (str == "untimer")
              {
                ++A_1.j;
                continue;
              }
              continue;
            case 8:
              if (str == "unbuffer")
              {
                ++A_1.e;
                continue;
              }
              continue;
            default:
              continue;
          }
        }
      }
    }
  }

  private void a(ak A_0, ref aq A_1)
  {
    for (int index = 0; index < A_0.h().Count; ++index)
      this.a((aj) A_0.h().GetByIndex(index), ref A_1);
  }

  public void b()
  {
    this.Text = "Статистика " + MainWindow.userInfo.a + " Вариант " + MainWindow.userInfo.variantNumber.ToString();
    this.h.Items.Clear();
    for (int index = 0; index < this.b.h().Count; ++index)
      this.h.Items.Add(this.b.h().GetKey(index));
    if (this.h.Items.Count > 0)
      this.h.SelectedIndex = 0;
    aq A_1_1 = new aq();
    this.a(this.b, ref A_1_1);
    this.k.Items.Clear();
    this.k.Items.Add((object) ("up: " + A_1_1.b.ToString()));
    this.k.Items.Add((object) ("down: " + A_1_1.a.ToString()));
    this.k.Items.Add((object) ("set: " + A_1_1.c.ToString()));
    this.k.Items.Add((object) ("buffer: " + A_1_1.d.ToString()));
    this.k.Items.Add((object) ("unbuffer: " + A_1_1.e.ToString()));
    this.k.Items.Add((object) ("queue: " + A_1_1.f.ToString()));
    this.k.Items.Add((object) ("goto: " + A_1_1.g.ToString()));
    this.k.Items.Add((object) ("if: " + A_1_1.h.ToString()));
    this.k.Items.Add((object) ("timer: " + A_1_1.i.ToString()));
    this.k.Items.Add((object) ("untimer: " + A_1_1.j.ToString()));
    this.k.Items.Add((object) ("crc: " + A_1_1.k.ToString()));
    this.k.Items.Add((object) ("out: " + A_1_1.l.ToString()));
    this.l.Items.Clear();
    this.l.Items.Add((object) ("up: " + this.b.d.b.ToString()));
    this.l.Items.Add((object) ("down: " + this.b.d.a.ToString()));
    this.l.Items.Add((object) ("set: " + this.b.d.c.ToString()));
    this.l.Items.Add((object) ("buffer: " + this.b.d.d.ToString()));
    this.l.Items.Add((object) ("unbuffer: " + this.b.d.e.ToString()));
    this.l.Items.Add((object) ("queue: " + this.b.d.f.ToString()));
    this.l.Items.Add((object) ("goto: " + this.b.d.g.ToString()));
    this.l.Items.Add((object) ("if: " + this.b.d.h.ToString()));
    this.l.Items.Add((object) ("timer: " + this.b.d.i.ToString()));
    this.l.Items.Add((object) ("untimer: " + this.b.d.j.ToString()));
    this.l.Items.Add((object) ("crc: " + this.b.d.k.ToString()));
    this.l.Items.Add((object) ("out: " + this.b.d.l.ToString()));
    this.c = 0;
    aq A_1_2 = new aq();
    if (MainWindow.s.network)
    {
      this.a(this.a.c().d().e(), ref A_1_2);
      this.a(this.a.c().c().e(), ref A_1_2);
      this.a(this.a.c().b().e(), ref A_1_2);
    }
    if (MainWindow.s.transport)
    {
      this.a(this.a.c().d().f(), ref A_1_2);
      this.a(this.a.c().c().f(), ref A_1_2);
      this.a(this.a.c().b().f(), ref A_1_2);
    }
    if (MainWindow.s.session)
    {
      this.a(this.a.c().d().g(), ref A_1_2);
      this.a(this.a.c().c().g(), ref A_1_2);
      this.a(this.a.c().b().g(), ref A_1_2);
    }
    if (MainWindow.s.presentation)
    {
      this.a(this.a.c().d().h(), ref A_1_2);
      this.a(this.a.c().c().h(), ref A_1_2);
      this.a(this.a.c().b().h(), ref A_1_2);
    }
    if (MainWindow.s.application)
    {
      this.a(this.a.c().d().i(), ref A_1_2);
      this.a(this.a.c().b().i(), ref A_1_2);
    }
    if (MainWindow.s.UE)
    {
      this.a(this.a.c().d().j(), ref A_1_2);
      this.a(this.a.c().b().j(), ref A_1_2);
    }
    if (MainWindow.s.AP)
    {
      this.a(this.a.c().d().k(), ref A_1_2);
      this.a(this.a.c().b().k(), ref A_1_2);
    }
    this.c += ar.a * A_1_2.a + ar.b * A_1_2.b + ar.c * A_1_2.c + ar.d * A_1_2.d + ar.e * A_1_2.e + ar.f * A_1_2.f + ar.g * A_1_2.g + ar.h * A_1_2.h + ar.i * A_1_2.i + ar.j * A_1_2.j + ar.k * A_1_2.k;
    this.d = 0;
    if (MainWindow.s.network)
      this.d += @as.a * this.a.c().d().e().d.a + @as.b * this.a.c().d().e().d.b + @as.c * this.a.c().d().e().d.c + @as.d * this.a.c().d().e().d.d + @as.e * this.a.c().d().e().d.e + @as.f * this.a.c().d().e().d.f + @as.g * this.a.c().d().e().d.g + @as.h * this.a.c().d().e().d.h + @as.i * this.a.c().d().e().d.i + @as.j * this.a.c().d().e().d.j + @as.k * this.a.c().d().e().d.k + @as.a * this.a.c().c().e().d.a + @as.b * this.a.c().c().e().d.b + @as.c * this.a.c().c().e().d.c + @as.d * this.a.c().c().e().d.d + @as.e * this.a.c().c().e().d.e + @as.f * this.a.c().c().e().d.f + @as.g * this.a.c().c().e().d.g + @as.h * this.a.c().c().e().d.h + @as.i * this.a.c().c().e().d.i + @as.j * this.a.c().c().e().d.j + @as.k * this.a.c().c().e().d.k + @as.a * this.a.c().b().e().d.a + @as.b * this.a.c().b().e().d.b + @as.c * this.a.c().b().e().d.c + @as.d * this.a.c().b().e().d.d + @as.e * this.a.c().b().e().d.e + @as.f * this.a.c().b().e().d.f + @as.g * this.a.c().b().e().d.g + @as.h * this.a.c().b().e().d.h + @as.i * this.a.c().b().e().d.i + @as.j * this.a.c().b().e().d.j + @as.k * this.a.c().b().e().d.k;
    if (MainWindow.s.transport)
      this.d += @as.a * this.a.c().d().f().d.a + @as.b * this.a.c().d().f().d.b + @as.c * this.a.c().d().f().d.c + @as.d * this.a.c().d().f().d.d + @as.e * this.a.c().d().f().d.e + @as.f * this.a.c().d().f().d.f + @as.g * this.a.c().d().f().d.g + @as.h * this.a.c().d().f().d.h + @as.i * this.a.c().d().f().d.i + @as.j * this.a.c().d().f().d.j + @as.k * this.a.c().d().f().d.k + @as.a * this.a.c().c().f().d.a + @as.b * this.a.c().c().f().d.b + @as.c * this.a.c().c().f().d.c + @as.d * this.a.c().c().f().d.d + @as.e * this.a.c().c().f().d.e + @as.f * this.a.c().c().f().d.f + @as.g * this.a.c().c().f().d.g + @as.h * this.a.c().c().f().d.h + @as.i * this.a.c().c().f().d.i + @as.j * this.a.c().c().f().d.j + @as.k * this.a.c().c().f().d.k + @as.a * this.a.c().b().f().d.a + @as.b * this.a.c().b().f().d.b + @as.c * this.a.c().b().f().d.c + @as.d * this.a.c().b().f().d.d + @as.e * this.a.c().b().f().d.e + @as.f * this.a.c().b().f().d.f + @as.g * this.a.c().b().f().d.g + @as.h * this.a.c().b().f().d.h + @as.i * this.a.c().b().f().d.i + @as.j * this.a.c().b().f().d.j + @as.k * this.a.c().b().f().d.k;
    if (MainWindow.s.session)
      this.d += @as.a * this.a.c().d().g().d.a + @as.b * this.a.c().d().g().d.b + @as.c * this.a.c().d().g().d.c + @as.d * this.a.c().d().g().d.d + @as.e * this.a.c().d().g().d.e + @as.f * this.a.c().d().g().d.f + @as.g * this.a.c().d().g().d.g + @as.h * this.a.c().d().g().d.h + @as.i * this.a.c().d().g().d.i + @as.j * this.a.c().d().g().d.j + @as.k * this.a.c().d().g().d.k + @as.a * this.a.c().c().g().d.a + @as.b * this.a.c().c().g().d.b + @as.c * this.a.c().c().g().d.c + @as.d * this.a.c().c().g().d.d + @as.e * this.a.c().c().g().d.e + @as.f * this.a.c().c().g().d.f + @as.g * this.a.c().c().g().d.g + @as.h * this.a.c().c().g().d.h + @as.i * this.a.c().c().g().d.i + @as.j * this.a.c().c().g().d.j + @as.k * this.a.c().c().g().d.k + @as.a * this.a.c().b().g().d.a + @as.b * this.a.c().b().g().d.b + @as.c * this.a.c().b().g().d.c + @as.d * this.a.c().b().g().d.d + @as.e * this.a.c().b().g().d.e + @as.f * this.a.c().b().g().d.f + @as.g * this.a.c().b().g().d.g + @as.h * this.a.c().b().g().d.h + @as.i * this.a.c().b().g().d.i + @as.j * this.a.c().b().g().d.j + @as.k * this.a.c().b().g().d.k;
    if (MainWindow.s.presentation)
      this.d += @as.a * this.a.c().d().h().d.a + @as.b * this.a.c().d().h().d.b + @as.c * this.a.c().d().h().d.c + @as.d * this.a.c().d().h().d.d + @as.e * this.a.c().d().h().d.e + @as.f * this.a.c().d().h().d.f + @as.g * this.a.c().d().h().d.g + @as.h * this.a.c().d().h().d.h + @as.i * this.a.c().d().h().d.i + @as.j * this.a.c().d().h().d.j + @as.k * this.a.c().d().h().d.k + @as.a * this.a.c().c().h().d.a + @as.b * this.a.c().c().h().d.b + @as.c * this.a.c().c().h().d.c + @as.d * this.a.c().c().h().d.d + @as.e * this.a.c().c().h().d.e + @as.f * this.a.c().c().h().d.f + @as.g * this.a.c().c().h().d.g + @as.h * this.a.c().c().h().d.h + @as.i * this.a.c().c().h().d.i + @as.j * this.a.c().c().h().d.j + @as.k * this.a.c().c().h().d.k + @as.a * this.a.c().b().h().d.a + @as.b * this.a.c().b().h().d.b + @as.c * this.a.c().b().h().d.c + @as.d * this.a.c().b().h().d.d + @as.e * this.a.c().b().h().d.e + @as.f * this.a.c().b().h().d.f + @as.g * this.a.c().b().h().d.g + @as.h * this.a.c().b().h().d.h + @as.i * this.a.c().b().h().d.i + @as.j * this.a.c().b().h().d.j + @as.k * this.a.c().b().h().d.k;
    if (MainWindow.s.application)
      this.d += @as.a * this.a.c().d().i().d.a + @as.b * this.a.c().d().i().d.b + @as.c * this.a.c().d().i().d.c + @as.d * this.a.c().d().i().d.d + @as.e * this.a.c().d().i().d.e + @as.f * this.a.c().d().i().d.f + @as.g * this.a.c().d().i().d.g + @as.h * this.a.c().d().i().d.h + @as.i * this.a.c().d().i().d.i + @as.j * this.a.c().d().i().d.j + @as.k * this.a.c().d().i().d.k + @as.a * this.a.c().c().i().d.a + @as.b * this.a.c().c().i().d.b + @as.c * this.a.c().c().i().d.c + @as.d * this.a.c().c().i().d.d + @as.e * this.a.c().c().i().d.e + @as.f * this.a.c().c().i().d.f + @as.g * this.a.c().c().i().d.g + @as.h * this.a.c().c().i().d.h + @as.i * this.a.c().c().i().d.i + @as.j * this.a.c().c().i().d.j + @as.k * this.a.c().c().i().d.k + @as.a * this.a.c().b().i().d.a + @as.b * this.a.c().b().i().d.b + @as.c * this.a.c().b().i().d.c + @as.d * this.a.c().b().i().d.d + @as.e * this.a.c().b().i().d.e + @as.f * this.a.c().b().i().d.f + @as.g * this.a.c().b().i().d.g + @as.h * this.a.c().b().i().d.h + @as.i * this.a.c().b().i().d.i + @as.j * this.a.c().b().i().d.j + @as.k * this.a.c().b().i().d.k;
    if (MainWindow.s.UE)
      this.d += @as.a * this.a.c().d().j().d.a + @as.b * this.a.c().d().j().d.b + @as.c * this.a.c().d().j().d.c + @as.d * this.a.c().d().j().d.d + @as.e * this.a.c().d().j().d.e + @as.f * this.a.c().d().j().d.f + @as.g * this.a.c().d().j().d.g + @as.h * this.a.c().d().j().d.h + @as.i * this.a.c().d().j().d.i + @as.j * this.a.c().d().j().d.j + @as.k * this.a.c().d().j().d.k + @as.a * this.a.c().c().j().d.a + @as.b * this.a.c().c().j().d.b + @as.c * this.a.c().c().j().d.c + @as.d * this.a.c().c().j().d.d + @as.e * this.a.c().c().j().d.e + @as.f * this.a.c().c().j().d.f + @as.g * this.a.c().c().j().d.g + @as.h * this.a.c().c().j().d.h + @as.i * this.a.c().c().j().d.i + @as.j * this.a.c().c().j().d.j + @as.k * this.a.c().c().j().d.k + @as.a * this.a.c().b().j().d.a + @as.b * this.a.c().b().j().d.b + @as.c * this.a.c().b().j().d.c + @as.d * this.a.c().b().j().d.d + @as.e * this.a.c().b().j().d.e + @as.f * this.a.c().b().j().d.f + @as.g * this.a.c().b().j().d.g + @as.h * this.a.c().b().j().d.h + @as.i * this.a.c().b().j().d.i + @as.j * this.a.c().b().j().d.j + @as.k * this.a.c().b().j().d.k;
    if (MainWindow.s.AP)
      this.d += @as.a * this.a.c().d().k().d.a + @as.b * this.a.c().d().k().d.b + @as.c * this.a.c().d().k().d.c + @as.d * this.a.c().d().k().d.d + @as.e * this.a.c().d().k().d.e + @as.f * this.a.c().d().k().d.f + @as.g * this.a.c().d().k().d.g + @as.h * this.a.c().d().k().d.h + @as.i * this.a.c().d().k().d.i + @as.j * this.a.c().d().k().d.j + @as.k * this.a.c().d().k().d.k + @as.a * this.a.c().c().k().d.a + @as.b * this.a.c().c().k().d.b + @as.c * this.a.c().c().k().d.c + @as.d * this.a.c().c().k().d.d + @as.e * this.a.c().c().k().d.e + @as.f * this.a.c().c().k().d.f + @as.g * this.a.c().c().k().d.g + @as.h * this.a.c().c().k().d.h + @as.i * this.a.c().c().k().d.i + @as.j * this.a.c().c().k().d.j + @as.k * this.a.c().c().k().d.k + @as.a * this.a.c().b().k().d.a + @as.b * this.a.c().b().k().d.b + @as.c * this.a.c().b().k().d.c + @as.d * this.a.c().b().k().d.d + @as.e * this.a.c().b().k().d.e + @as.f * this.a.c().b().k().d.f + @as.g * this.a.c().b().k().d.g + @as.h * this.a.c().b().k().d.h + @as.i * this.a.c().b().k().d.i + @as.j * this.a.c().b().k().d.j + @as.k * this.a.c().b().k().d.k;
    this.d += this.a.c().d().e().d.m * @as.m + this.a.c().c().e().d.m * @as.m + this.a.c().b().e().d.m * @as.m;
    this.n.Text = string.Format("Текущая оценка:\nСтатическая - " + this.c.ToString() + "\n Динамическая - " + this.d.ToString());
  }

  private void f(object A_0, EventArgs A_1) => this.Close();

  private void e(object A_0, EventArgs A_1)
  {
    this.f.Items.Clear();
    if (MainWindow.s.network)
      this.f.Items.Add((object) "Сетевой");
    if (MainWindow.s.transport)
      this.f.Items.Add((object) "Транспортный");
    if (MainWindow.s.session)
      this.f.Items.Add((object) "Сеансовый");
    if (MainWindow.s.presentation)
      this.f.Items.Add((object) "Представления");
    if (MainWindow.s.application)
      this.f.Items.Add((object) "Прикладной");
    if (MainWindow.s.UE)
      this.f.Items.Add((object) "Элемент пользователя");
    if (MainWindow.s.AP)
      this.f.Items.Add((object) "Прикладной процесс");
    this.f.SelectedIndex = this.f.Items.Count - 1;
    if (!MainWindow.f)
      return;
    this.q.Enabled = true;
    this.q.Visible = true;
    this.r.Enabled = true;
    this.r.Visible = true;
  }

  private void d(object A_0, EventArgs A_1)
  {
    string selectedItem = (string) this.f.SelectedItem;
    if (selectedItem != null)
    {
      switch (selectedItem.Length)
      {
        case 7:
          if (selectedItem == "Сетевой")
          {
            this.b = this.a.c().d().e();
            break;
          }
          goto label_16;
        case 9:
          if (selectedItem == "Сеансовый")
          {
            this.b = this.a.c().d().g();
            break;
          }
          goto label_16;
        case 10:
          if (selectedItem == "Прикладной")
          {
            this.b = this.a.c().d().i();
            break;
          }
          goto label_16;
        case 12:
          if (selectedItem == "Транспортный")
          {
            this.b = this.a.c().d().f();
            break;
          }
          goto label_16;
        case 13:
          if (selectedItem == "Представления")
          {
            this.b = this.a.c().d().h();
            break;
          }
          goto label_16;
        case 18:
          if (selectedItem == "Прикладной процесс")
          {
            this.b = this.a.c().d().k();
            break;
          }
          goto label_16;
        case 20:
          if (selectedItem == "Элемент пользователя")
          {
            this.b = this.a.c().d().j();
            break;
          }
          goto label_16;
        default:
          goto label_16;
      }
      this.b();
      return;
    }
label_16:
    throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
  }

  private void c(object A_0, EventArgs A_1)
  {
    this.j.Items.Clear();
    aq A_1_1 = new aq();
    this.a((aj) this.b.h()[this.h.SelectedItem], ref A_1_1);
    this.j.Items.Add((object) ("up: " + A_1_1.b.ToString()));
    this.j.Items.Add((object) ("down: " + A_1_1.a.ToString()));
    this.j.Items.Add((object) ("set: " + A_1_1.c.ToString()));
    this.j.Items.Add((object) ("buffer: " + A_1_1.d.ToString()));
    this.j.Items.Add((object) ("unbuffer: " + A_1_1.e.ToString()));
    this.j.Items.Add((object) ("queue: " + A_1_1.f.ToString()));
    this.j.Items.Add((object) ("goto: " + A_1_1.g.ToString()));
    this.j.Items.Add((object) ("if: " + A_1_1.h.ToString()));
    this.j.Items.Add((object) ("timer: " + A_1_1.i.ToString()));
    this.j.Items.Add((object) ("untimer: " + A_1_1.j.ToString()));
    this.j.Items.Add((object) ("crc: " + A_1_1.k.ToString()));
    this.j.Items.Add((object) ("out: " + A_1_1.l.ToString()));
  }

  private void b(object A_0, EventArgs A_1)
  {
    DataTable dataTable = new DataTable("Accepted");
    try
    {
      using (FileStream fileStream = new FileStream(Application.StartupPath + "\\db.xml", FileMode.Open, FileAccess.Read))
      {
        int num = (int) dataTable.ReadXml((Stream) fileStream);
        fileStream.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(Resources.ErrorFileRead + "\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    string[] keys = new string[2]{ MainWindow.userInfo.a, MainWindow.userInfo.b };
    DataRow row;
    if (dataTable.Rows.Contains((object[]) keys))
    {
      row = dataTable.Rows.Find((object[]) keys);
    }
    else
    {
      row = dataTable.NewRow();
      row["FIO"] = (object) MainWindow.userInfo.a;
      row["Group"] = (object) MainWindow.userInfo.b;
      row["Variant"] = (object) MainWindow.userInfo.variantNumber;
      dataTable.Rows.Add(row);
    }
    int num1;
    switch ((string) this.f.SelectedItem)
    {
      case "Транспортный":
        num1 = 1;
        break;
      case "Сеансовый":
        num1 = 2;
        break;
      case "Представления":
        num1 = 3;
        break;
      case "Прикладной":
        num1 = 4;
        break;
      case "Элемент пользователя":
        num1 = 5;
        break;
      default:
        throw new IndexOutOfRangeException(Resources.ErrorUnknownTask);
    }
    row["Date" + num1.ToString()] = (object) DateTime.Now;
    row["Stat" + num1.ToString()] = (object) this.c;
    row["Din" + num1.ToString()] = (object) this.d;
    row["File" + num1.ToString()] = (object) MainWindow.labFileName;
    row["Run" + num1.ToString()] = (object) MainWindow.userInfo.q;
    row["Debug" + num1.ToString()] = (object) MainWindow.userInfo.p;
    try
    {
      using (FileStream fileStream = new FileStream(Application.StartupPath + "\\db.xml", FileMode.Create, FileAccess.Write))
      {
        dataTable.WriteXml((Stream) fileStream, XmlWriteMode.WriteSchema, false);
        fileStream.Close();
      }
      int num2 = (int) MessageBox.Show("Данные занесены");
    }
    catch (Exception ex)
    {
      int num3 = (int) MessageBox.Show(Resources.ErrorFileWrite + "\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void a(object A_0, EventArgs A_1)
  {
    global::g g = new global::g(this.b);
    int num = (int) g.ShowDialog();
    g.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.e != null)
      this.e.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.f = new ComboBox();
    this.g = new Label();
    this.h = new ListBox();
    this.i = new Label();
    this.j = new ListBox();
    this.k = new ListBox();
    this.l = new ListBox();
    this.m = new Panel();
    this.n = new Label();
    this.o = new Label();
    this.p = new Button();
    this.q = new Button();
    this.r = new Button();
    this.m.SuspendLayout();
    this.SuspendLayout();
    this.f.DropDownStyle = ComboBoxStyle.DropDownList;
    this.f.FlatStyle = FlatStyle.Popup;
    this.f.FormattingEnabled = true;
    this.f.Location = new Point(72, 12);
    this.f.Name = "LevelComboBox";
    this.f.Size = new Size(149, 21);
    this.f.TabIndex = 0;
    this.f.SelectedIndexChanged += new EventHandler(this.d);
    this.g.AutoSize = true;
    this.g.Location = new Point(12, 15);
    this.g.Name = "label1";
    this.g.Size = new Size(54, 13);
    this.g.TabIndex = 1;
    this.g.Text = "Уровень:";
    this.h.FormattingEnabled = true;
    this.h.Location = new Point(12, 69);
    this.h.Name = "EventsListBox";
    this.h.Size = new Size(125, 186);
    this.h.TabIndex = 2;
    this.h.SelectedIndexChanged += new EventHandler(this.c);
    this.i.Enabled = false;
    this.i.Location = new Point(9, 36);
    this.i.Name = "label2";
    this.i.Size = new Size(128, 30);
    this.i.TabIndex = 3;
    this.i.Text = "Выберете событие для просмотра статистики:";
    this.j.Enabled = false;
    this.j.FormattingEnabled = true;
    this.j.Location = new Point(143, 69);
    this.j.Name = "EvenStatListBox";
    this.j.Size = new Size(125, 186);
    this.j.TabIndex = 4;
    this.k.Enabled = false;
    this.k.FormattingEnabled = true;
    this.k.Location = new Point(274, 69);
    this.k.Name = "AllListBox";
    this.k.Size = new Size(125, 186);
    this.k.TabIndex = 5;
    this.l.Enabled = false;
    this.l.FormattingEnabled = true;
    this.l.Location = new Point(405, 69);
    this.l.Name = "RunStatListBox";
    this.l.Size = new Size(125, 186);
    this.l.TabIndex = 6;
    this.m.BorderStyle = BorderStyle.FixedSingle;
    this.m.Controls.Add((Control) this.n);
    this.m.Location = new Point(12, 261);
    this.m.Name = "StatPanel";
    this.m.Size = new Size(338, 76);
    this.m.TabIndex = 7;
    this.n.Dock = DockStyle.Fill;
    this.n.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.n.ForeColor = Color.Red;
    this.n.Location = new Point(0, 0);
    this.n.Name = "Statlabel";
    this.n.Size = new Size(336, 74);
    this.n.TabIndex = 0;
    this.n.Text = "Текущая оценка:";
    this.n.TextAlign = ContentAlignment.MiddleCenter;
    this.o.AutoSize = true;
    this.o.Location = new Point(271, 53);
    this.o.Name = "label3";
    this.o.Size = new Size(40, 13);
    this.o.TabIndex = 8;
    this.o.Text = "Всего:";
    this.p.DialogResult = DialogResult.Cancel;
    this.p.Location = new Point(448, 261);
    this.p.Name = "CloseButton";
    this.p.Size = new Size(82, 76);
    this.p.TabIndex = 9;
    this.p.Text = "Закрыть";
    this.p.UseVisualStyleBackColor = false;
    this.p.Click += new EventHandler(this.f);
    this.q.Enabled = false;
    this.q.Location = new Point(356, 261);
    this.q.Name = "DBbutton";
    this.q.Size = new Size(86, 33);
    this.q.TabIndex = 10;
    this.q.Text = "БД";
    this.q.UseVisualStyleBackColor = false;
    this.q.Visible = false;
    this.q.Click += new EventHandler(this.b);
    this.r.Enabled = false;
    this.r.Location = new Point(355, 304);
    this.r.Name = "Cheatersbutton";
    this.r.Size = new Size(86, 33);
    this.r.TabIndex = 11;
    this.r.Text = "Совпадения";
    this.r.UseVisualStyleBackColor = false;
    this.r.Visible = false;
    this.r.Click += new EventHandler(this.a);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.p;
    this.ClientSize = new Size(543, 346);
    this.Controls.Add((Control) this.r);
    this.Controls.Add((Control) this.q);
    this.Controls.Add((Control) this.p);
    this.Controls.Add((Control) this.o);
    this.Controls.Add((Control) this.m);
    this.Controls.Add((Control) this.l);
    this.Controls.Add((Control) this.k);
    this.Controls.Add((Control) this.j);
    this.Controls.Add((Control) this.i);
    this.Controls.Add((Control) this.h);
    this.Controls.Add((Control) this.g);
    this.Controls.Add((Control) this.f);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = "StatisticForm";
    this.Text = "Статистика";
    this.Shown += new EventHandler(this.e);
    this.m.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
