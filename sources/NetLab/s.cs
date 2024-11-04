// Decompiled with JetBrains decompiler
// Type: s
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
public class s : Form
{
  private an c;
  private ArrayList d;
  private IContainer e;
  private Button f;
  private Button g;
  private Button h;
  private Button i;
  private Button j;
  private Button k;
  private GroupBox l;
  private RadioButton m;
  private RadioButton n;
  private Button o;
  private Button p;
  private Button q;
  private ListBox r;
  private Label s;
  private Button t;

  [CompilerGenerated]
  [SpecialName]
  public ak d() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void a(ak A_0) => this.a = A_0;

  [CompilerGenerated]
  [SpecialName]
  public am c() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void a(am A_0) => this.b = A_0;

  public s(an A_0)
  {
    this.a();
    this.c = A_0;
    this.d = new ArrayList();
  }

  public void b()
  {
    this.Text = "";
    string str = this.d().k();
    if (str != null)
    {
      string key;
      switch (str.Length)
      {
        case 2:
          if (str == "UE")
          {
            key = "UE_INIT.REQ";
            this.Text = Resources.UELevel;
            break;
          }
          goto label_17;
        case 7:
          switch (str[0])
          {
            case 'N':
              if (str == "Network")
              {
                key = "N_INIT.REQ";
                this.Text = Resources.TransportLevel;
                break;
              }
              goto label_17;
            case 'P':
              if (str == "Process")
              {
                key = "AP_INIT.REQ";
                this.Text = Resources.APLevel;
                break;
              }
              goto label_17;
            case 'S':
              if (str == "Session")
              {
                key = "S_INIT.REQ";
                this.Text = Resources.SessionLevel;
                break;
              }
              goto label_17;
            default:
              goto label_17;
          }
          break;
        case 9:
          if (str == "Transport")
          {
            key = "T_INIT.REQ";
            this.Text = Resources.TransportLevel;
            break;
          }
          goto label_17;
        case 11:
          if (str == "Application")
          {
            key = "A_INIT.REQ";
            this.Text = Resources.ApplicationLevel;
            break;
          }
          goto label_17;
        case 12:
          if (str == "Presentation")
          {
            key = "P_INIT.REQ";
            this.Text = Resources.PresentationLevel;
            break;
          }
          goto label_17;
        default:
          goto label_17;
      }
      if (v.t)
      {
        switch (this.c().b())
        {
          case "SystemA":
            this.Text += Resources._systemyA;
            break;
          case "Guide":
            this.Text += Resources._guidey;
            break;
          case "SystemB":
            this.Text += Resources._systemyB;
            break;
          default:
            throw new IndexOutOfRangeException(Resources.ErrorUnknownSystem);
        }
      }
      this.p.Visible = v.t;
      this.q.Visible = v.t;
      int index1 = this.d().h().IndexOfKey((object) key);
      if (index1 >= 0)
        (this.d().h().GetByIndex(index1) as aj).a(true);
      if (this.d().i() == (byte) 0)
        this.n.Checked = true;
      else
        this.m.Checked = true;
      this.r.Items.Clear();
      for (int index2 = 0; index2 < this.d().h().Count; ++index2)
      {
        if (!(this.d().h().GetByIndex(index2) as aj).n())
          this.r.Items.Add((object) (this.d().h().GetByIndex(index2) as aj).o());
      }
      return;
    }
label_17:
    throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
  }

  private void l(object A_0, EventArgs A_1) => this.Close();

  private void k(object A_0, EventArgs A_1)
  {
    switch (this.c().b())
    {
      case "SystemA":
        string str1 = this.d().k();
        if (str1 != null)
        {
          switch (str1.Length)
          {
            case 2:
              if (str1 == "UE")
              {
                this.a(this.c.c());
                this.a(this.c.c().j());
                goto label_56;
              }
              else
                break;
            case 7:
              switch (str1[0])
              {
                case 'N':
                  if (str1 == "Network")
                  {
                    this.a(this.c.c());
                    this.a(this.c.c().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str1 == "Process")
                  {
                    this.a(this.c.c());
                    this.a(this.c.c().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str1 == "Session")
                  {
                    this.a(this.c.c());
                    this.a(this.c.c().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str1 == "Transport")
              {
                this.a(this.c.c());
                this.a(this.c.c().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str1 == "Application")
              {
                this.a(this.c.c());
                this.a(this.c.c().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str1 == "Presentation")
              {
                this.a(this.c.c());
                this.a(this.c.c().h());
                goto label_56;
              }
              else
                break;
          }
        }
        throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      case "Guide":
        string str2 = this.d().k();
        if (str2 != null)
        {
          switch (str2.Length)
          {
            case 2:
              if (str2 == "UE")
              {
                this.a(this.c.b());
                this.a(this.c.b().j());
                goto label_56;
              }
              else
                break;
            case 7:
              switch (str2[0])
              {
                case 'N':
                  if (str2 == "Network")
                  {
                    this.a(this.c.b());
                    this.a(this.c.b().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str2 == "Process")
                  {
                    this.a(this.c.b());
                    this.a(this.c.b().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str2 == "Session")
                  {
                    this.a(this.c.b());
                    this.a(this.c.b().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str2 == "Transport")
              {
                this.a(this.c.b());
                this.a(this.c.b().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str2 == "Application")
              {
                this.a(this.c.b());
                this.a(this.c.b().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str2 == "Presentation")
              {
                this.a(this.c.b());
                this.a(this.c.b().h());
                goto label_56;
              }
              else
                break;
          }
        }
        throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      case "SystemB":
        string str3 = this.d().k();
        if (str3 != null)
        {
          switch (str3.Length)
          {
            case 2:
              if (str3 == "UE")
              {
                this.a(this.c.d());
                this.a(this.c.d().j());
                goto label_56;
              }
              else
                break;
            case 7:
              switch (str3[0])
              {
                case 'N':
                  if (str3 == "Network")
                  {
                    this.a(this.c.d());
                    this.a(this.c.d().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str3 == "Process")
                  {
                    this.a(this.c.d());
                    this.a(this.c.d().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str3 == "Session")
                  {
                    this.a(this.c.d());
                    this.a(this.c.d().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str3 == "Transport")
              {
                this.a(this.c.d());
                this.a(this.c.d().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str3 == "Application")
              {
                this.a(this.c.d());
                this.a(this.c.d().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str3 == "Presentation")
              {
                this.a(this.c.d());
                this.a(this.c.d().h());
                goto label_56;
              }
              else
                break;
          }
        }
        throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      default:
        throw new IndexOutOfRangeException(Resources.ErrorUnknownSystem);
    }
label_56:
    this.b();
  }

  private void j(object A_0, EventArgs A_1)
  {
    switch (this.c().b())
    {
      case "SystemB":
        string str1 = this.d().k();
        if (str1 != null)
        {
          switch (str1.Length)
          {
            case 2:
              if (str1 == "UE")
              {
                this.a(this.c.c());
                this.a(this.c.c().j());
                goto label_56;
              }
              else
                break;
            case 7:
              switch (str1[0])
              {
                case 'N':
                  if (str1 == "Network")
                  {
                    this.a(this.c.c());
                    this.a(this.c.c().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str1 == "Process")
                  {
                    this.a(this.c.c());
                    this.a(this.c.c().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str1 == "Session")
                  {
                    this.a(this.c.c());
                    this.a(this.c.c().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str1 == "Transport")
              {
                this.a(this.c.c());
                this.a(this.c.c().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str1 == "Application")
              {
                this.a(this.c.c());
                this.a(this.c.c().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str1 == "Presentation")
              {
                this.a(this.c.c());
                this.a(this.c.c().h());
                goto label_56;
              }
              else
                break;
          }
        }
        throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      case "SystemA":
        string str2 = this.d().k();
        if (str2 != null)
        {
          switch (str2.Length)
          {
            case 2:
              if (str2 == "UE")
              {
                this.a(this.c.b());
                this.a(this.c.b().j());
                goto label_56;
              }
              else
                break;
            case 7:
              switch (str2[0])
              {
                case 'N':
                  if (str2 == "Network")
                  {
                    this.a(this.c.b());
                    this.a(this.c.b().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str2 == "Process")
                  {
                    this.a(this.c.b());
                    this.a(this.c.b().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str2 == "Session")
                  {
                    this.a(this.c.b());
                    this.a(this.c.b().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str2 == "Transport")
              {
                this.a(this.c.b());
                this.a(this.c.b().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str2 == "Application")
              {
                this.a(this.c.b());
                this.a(this.c.b().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str2 == "Presentation")
              {
                this.a(this.c.b());
                this.a(this.c.b().h());
                goto label_56;
              }
              else
                break;
          }
        }
        throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      case "Guide":
        string str3 = this.d().k();
        if (str3 != null)
        {
          switch (str3.Length)
          {
            case 2:
              if (str3 == "UE")
              {
                this.a(this.c.d());
                this.a(this.c.d().j());
                goto label_56;
              }
              else
                break;
            case 7:
              switch (str3[0])
              {
                case 'N':
                  if (str3 == "Network")
                  {
                    this.a(this.c.d());
                    this.a(this.c.d().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str3 == "Process")
                  {
                    this.a(this.c.d());
                    this.a(this.c.d().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str3 == "Session")
                  {
                    this.a(this.c.d());
                    this.a(this.c.d().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str3 == "Transport")
              {
                this.a(this.c.d());
                this.a(this.c.d().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str3 == "Application")
              {
                this.a(this.c.d());
                this.a(this.c.d().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str3 == "Presentation")
              {
                this.a(this.c.d());
                this.a(this.c.d().h());
                goto label_56;
              }
              else
                break;
          }
        }
        throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      default:
        throw new IndexOutOfRangeException(Resources.ErrorUnknownSystem);
    }
label_56:
    this.b();
  }

  private void i(object A_0, EventArgs A_1)
  {
    if (this.n.Checked)
    {
      this.c.d().e().a((byte) 0);
      this.c.c().e().a((byte) 0);
      this.c.b().e().a((byte) 0);
      this.c.d().f().a((byte) 0);
      this.c.d().g().a((byte) 0);
      this.c.d().h().a((byte) 0);
      this.c.d().i().a((byte) 0);
      this.c.d().j().a((byte) 0);
      this.c.d().k().a((byte) 0);
      this.c.c().f().a((byte) 0);
      this.c.c().g().a((byte) 0);
      this.c.c().h().a((byte) 0);
      this.c.c().i().a((byte) 0);
      this.c.c().j().a((byte) 0);
      this.c.c().k().a((byte) 0);
      this.c.b().f().a((byte) 0);
      this.c.b().g().a((byte) 0);
      this.c.b().h().a((byte) 0);
      this.c.b().i().a((byte) 0);
      this.c.b().j().a((byte) 0);
      this.c.b().k().a((byte) 0);
    }
    else
    {
      this.c.d().e().a((byte) 1);
      this.c.c().e().a((byte) 1);
      this.c.b().e().a((byte) 1);
      this.c.d().f().a((byte) 1);
      this.c.d().g().a((byte) 1);
      this.c.d().h().a((byte) 1);
      this.c.d().i().a((byte) 1);
      this.c.d().j().a((byte) 1);
      this.c.d().k().a((byte) 1);
      this.c.c().f().a((byte) 1);
      this.c.c().g().a((byte) 1);
      this.c.c().h().a((byte) 1);
      this.c.c().i().a((byte) 1);
      this.c.c().j().a((byte) 1);
      this.c.c().k().a((byte) 1);
      this.c.b().f().a((byte) 1);
      this.c.b().g().a((byte) 1);
      this.c.b().h().a((byte) 1);
      this.c.b().i().a((byte) 1);
      this.c.b().j().a((byte) 1);
      this.c.b().k().a((byte) 1);
    }
    this.b();
  }

  private void h(object A_0, EventArgs A_1)
  {
    ak[] A_0_1;
    if (v.t)
    {
      A_0_1 = new ak[1]{ this.d() };
    }
    else
    {
      string str = this.d().k();
      if (str != null)
      {
        switch (str.Length)
        {
          case 2:
            if (str == "UE")
            {
              A_0_1 = new ak[2]
              {
                this.c.d().j(),
                this.c.b().j()
              };
              goto label_20;
            }
            else
              break;
          case 7:
            switch (str[0])
            {
              case 'N':
                if (str == "Network")
                {
                  A_0_1 = new ak[3]
                  {
                    this.c.d().e(),
                    this.c.c().e(),
                    this.c.b().e()
                  };
                  goto label_20;
                }
                else
                  break;
              case 'P':
                if (str == "Process")
                {
                  A_0_1 = new ak[2]
                  {
                    this.c.d().k(),
                    this.c.b().k()
                  };
                  goto label_20;
                }
                else
                  break;
              case 'S':
                if (str == "Session")
                {
                  A_0_1 = new ak[3]
                  {
                    this.c.d().g(),
                    this.c.c().g(),
                    this.c.b().g()
                  };
                  goto label_20;
                }
                else
                  break;
            }
            break;
          case 9:
            if (str == "Transport")
            {
              A_0_1 = new ak[3]
              {
                this.c.d().f(),
                this.c.c().f(),
                this.c.b().f()
              };
              goto label_20;
            }
            else
              break;
          case 11:
            if (str == "Application")
            {
              A_0_1 = new ak[2]
              {
                this.c.d().i(),
                this.c.b().i()
              };
              goto label_20;
            }
            else
              break;
          case 12:
            if (str == "Presentation")
            {
              A_0_1 = new ak[3]
              {
                this.c.d().h(),
                this.c.c().h(),
                this.c.b().h()
              };
              goto label_20;
            }
            else
              break;
        }
      }
      throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
    }
label_20:
    global::e e = new global::e(A_0_1);
    int num = (int) e.ShowDialog();
    this.b();
    e.Dispose();
  }

  private void g(object A_0, EventArgs A_1)
  {
    if (MessageBox.Show(Resources.ConfirmRemove + this.r.SelectedItems.Count.ToString() + Resources.Event_sQuestion, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
      return;
    if (v.t)
    {
      for (int index = this.r.SelectedItems.Count - 1; index >= 0; --index)
        this.d().h().Remove(this.r.SelectedItems[index]);
    }
    else
    {
      string str = this.d().k();
      if (str != null)
      {
        ak[] akArray;
        switch (str.Length)
        {
          case 2:
            if (str == "UE")
            {
              akArray = new ak[2]
              {
                this.c.d().j(),
                this.c.b().j()
              };
              break;
            }
            goto label_23;
          case 7:
            switch (str[0])
            {
              case 'N':
                if (str == "Network")
                {
                  akArray = new ak[3]
                  {
                    this.c.d().e(),
                    this.c.c().e(),
                    this.c.b().e()
                  };
                  break;
                }
                goto label_23;
              case 'P':
                if (str == "Process")
                {
                  akArray = new ak[2]
                  {
                    this.c.d().k(),
                    this.c.b().k()
                  };
                  break;
                }
                goto label_23;
              case 'S':
                if (str == "Session")
                {
                  akArray = new ak[3]
                  {
                    this.c.d().g(),
                    this.c.c().g(),
                    this.c.b().g()
                  };
                  break;
                }
                goto label_23;
              default:
                goto label_23;
            }
            break;
          case 9:
            if (str == "Transport")
            {
              akArray = new ak[3]
              {
                this.c.d().f(),
                this.c.c().f(),
                this.c.b().f()
              };
              break;
            }
            goto label_23;
          case 11:
            if (str == "Application")
            {
              akArray = new ak[2]
              {
                this.c.d().i(),
                this.c.b().i()
              };
              break;
            }
            goto label_23;
          case 12:
            if (str == "Presentation")
            {
              akArray = new ak[3]
              {
                this.c.d().h(),
                this.c.c().h(),
                this.c.b().h()
              };
              break;
            }
            goto label_23;
          default:
            goto label_23;
        }
        for (int index1 = 0; index1 < akArray.Length; ++index1)
        {
          for (int index2 = this.r.SelectedItems.Count - 1; index2 >= 0; --index2)
            akArray[index1].h().Remove(this.r.SelectedItems[index2]);
        }
        goto label_30;
      }
label_23:
      throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
    }
label_30:
    this.b();
  }

  private void f(object A_0, EventArgs A_1)
  {
    if (this.r.SelectedItems.Count <= 0)
      return;
    ak[] A_1_1;
    if (v.t)
    {
      A_1_1 = new ak[1]{ this.d() };
    }
    else
    {
      string str = this.d().k();
      if (str != null)
      {
        switch (str.Length)
        {
          case 2:
            if (str == "UE")
            {
              A_1_1 = new ak[2]
              {
                this.c.d().j(),
                this.c.b().j()
              };
              goto label_22;
            }
            else
              break;
          case 7:
            switch (str[0])
            {
              case 'N':
                if (str == "Network")
                {
                  A_1_1 = new ak[3]
                  {
                    this.c.d().e(),
                    this.c.c().e(),
                    this.c.b().e()
                  };
                  goto label_22;
                }
                else
                  break;
              case 'P':
                if (str == "Process")
                {
                  A_1_1 = new ak[2]
                  {
                    this.c.d().k(),
                    this.c.b().k()
                  };
                  goto label_22;
                }
                else
                  break;
              case 'S':
                if (str == "Session")
                {
                  A_1_1 = new ak[3]
                  {
                    this.c.d().g(),
                    this.c.c().g(),
                    this.c.b().g()
                  };
                  goto label_22;
                }
                else
                  break;
            }
            break;
          case 9:
            if (str == "Transport")
            {
              A_1_1 = new ak[3]
              {
                this.c.d().f(),
                this.c.c().f(),
                this.c.b().f()
              };
              goto label_22;
            }
            else
              break;
          case 11:
            if (str == "Application")
            {
              A_1_1 = new ak[2]
              {
                this.c.d().i(),
                this.c.b().i()
              };
              goto label_22;
            }
            else
              break;
          case 12:
            if (str == "Presentation")
            {
              A_1_1 = new ak[3]
              {
                this.c.d().h(),
                this.c.c().h(),
                this.c.b().h()
              };
              goto label_22;
            }
            else
              break;
        }
      }
      throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
    }
label_22:
    global::r r = new global::r(this.r.SelectedItem.ToString(), A_1_1);
    int num = (int) r.ShowDialog();
    this.b();
    r.Dispose();
  }

  private void e(object A_0, EventArgs A_1)
  {
    ak[] akArray;
    if (v.t)
    {
      akArray = new ak[1]{ this.d() };
    }
    else
    {
      string str = this.d().k();
      if (str != null)
      {
        switch (str.Length)
        {
          case 2:
            if (str == "UE")
            {
              akArray = new ak[2]
              {
                this.c.d().j(),
                this.c.b().j()
              };
              goto label_20;
            }
            else
              break;
          case 7:
            switch (str[0])
            {
              case 'N':
                if (str == "Network")
                {
                  akArray = new ak[3]
                  {
                    this.c.d().e(),
                    this.c.c().e(),
                    this.c.b().e()
                  };
                  goto label_20;
                }
                else
                  break;
              case 'P':
                if (str == "Process")
                {
                  akArray = new ak[2]
                  {
                    this.c.d().k(),
                    this.c.b().k()
                  };
                  goto label_20;
                }
                else
                  break;
              case 'S':
                if (str == "Session")
                {
                  akArray = new ak[3]
                  {
                    this.c.d().g(),
                    this.c.c().g(),
                    this.c.b().g()
                  };
                  goto label_20;
                }
                else
                  break;
            }
            break;
          case 9:
            if (str == "Transport")
            {
              akArray = new ak[3]
              {
                this.c.d().f(),
                this.c.c().f(),
                this.c.b().f()
              };
              goto label_20;
            }
            else
              break;
          case 11:
            if (str == "Application")
            {
              akArray = new ak[2]
              {
                this.c.d().i(),
                this.c.b().i()
              };
              goto label_20;
            }
            else
              break;
          case 12:
            if (str == "Presentation")
            {
              akArray = new ak[3]
              {
                this.c.d().h(),
                this.c.c().h(),
                this.c.b().h()
              };
              goto label_20;
            }
            else
              break;
        }
      }
      throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
    }
label_20:
    for (int index1 = 0; index1 < akArray.Length; ++index1)
    {
      if (akArray[index1].i() == (byte) 0)
      {
        for (int index2 = 0; index2 < this.r.SelectedItems.Count; ++index2)
        {
          if (akArray[index1].c().IndexOfKey(this.r.SelectedItems[index2]) != -1)
          {
            int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          }
          aj aj = (akArray[index1].h()[this.r.SelectedItems[index2]] as aj).a();
          akArray[index1].c().Add((object) aj.o(), (object) aj);
        }
      }
      else
      {
        for (int index3 = 0; index3 < this.r.SelectedItems.Count; ++index3)
        {
          if (akArray[index1].g().IndexOfKey(this.r.SelectedItems[index3]) != -1)
          {
            int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          }
          aj aj = (akArray[index1].h()[this.r.SelectedItems[index3]] as aj).a();
          akArray[index1].g().Add((object) aj.o(), (object) aj);
        }
      }
    }
  }

  private void a(object A_0, KeyEventArgs A_1)
  {
    switch (A_1.KeyCode)
    {
      case Keys.Return:
        this.f.PerformClick();
        break;
      case Keys.Insert:
        this.g.PerformClick();
        break;
      case Keys.Delete:
        this.h.PerformClick();
        break;
      case Keys.F2:
        this.t.PerformClick();
        break;
    }
  }

  private void d(object A_0, EventArgs A_1)
  {
    if (this.r.SelectedIndex < 0)
      return;
    for (int index = 0; index < this.d.Count; ++index)
    {
      if (((Control) this.d[index]).Text == this.r.SelectedItem.ToString())
      {
        if (((Form) this.d[index]).WindowState == FormWindowState.Minimized)
          ((Form) this.d[index]).WindowState = FormWindowState.Normal;
        ((Control) this.d[index]).BringToFront();
        return;
      }
    }
    ak[] akArray;
    if (v.t)
    {
      akArray = new ak[1]{ this.d() };
    }
    else
    {
      string str = this.d().k();
      if (str != null)
      {
        switch (str.Length)
        {
          case 2:
            if (str == "UE")
            {
              akArray = new ak[2]
              {
                this.c.d().j(),
                this.c.b().j()
              };
              goto label_30;
            }
            else
              break;
          case 7:
            switch (str[0])
            {
              case 'N':
                if (str == "Network")
                {
                  akArray = new ak[3]
                  {
                    this.c.d().e(),
                    this.c.c().e(),
                    this.c.b().e()
                  };
                  goto label_30;
                }
                else
                  break;
              case 'P':
                if (str == "Process")
                {
                  akArray = new ak[2]
                  {
                    this.c.d().k(),
                    this.c.b().k()
                  };
                  goto label_30;
                }
                else
                  break;
              case 'S':
                if (str == "Session")
                {
                  akArray = new ak[3]
                  {
                    this.c.d().g(),
                    this.c.c().g(),
                    this.c.b().g()
                  };
                  goto label_30;
                }
                else
                  break;
            }
            break;
          case 9:
            if (str == "Transport")
            {
              akArray = new ak[3]
              {
                this.c.d().f(),
                this.c.c().f(),
                this.c.b().f()
              };
              goto label_30;
            }
            else
              break;
          case 11:
            if (str == "Application")
            {
              akArray = new ak[2]
              {
                this.c.d().i(),
                this.c.b().i()
              };
              goto label_30;
            }
            else
              break;
          case 12:
            if (str == "Presentation")
            {
              akArray = new ak[3]
              {
                this.c.d().h(),
                this.c.c().h(),
                this.c.b().h()
              };
              goto label_30;
            }
            else
              break;
        }
      }
      throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
    }
label_30:
    aj[] A_0_1 = new aj[akArray.Length];
    if (this.r.SelectedItems.Count <= 0)
      return;
    for (int index = 0; index < akArray.Length; ++index)
    {
      if (akArray[index].h().IndexOfKey((object) this.r.SelectedItem.ToString()) == -1)
      {
        aj aj = new aj(this.r.SelectedItem.ToString(), akArray[index].j());
        akArray[index].h().Add((object) this.r.SelectedItem.ToString(), (object) aj);
      }
      A_0_1[index] = akArray[index].h()[(object) this.r.SelectedItem.ToString()] as aj;
    }
    global::j j = new global::j(A_0_1, this.c);
    this.d.Add((object) j);
    j.Show();
  }

  private void a(object A_0, MouseEventArgs A_1) => this.f.PerformClick();

  private void c(object A_0, EventArgs A_1)
  {
    string str1 = this.d().k();
    if (str1 != null)
    {
      string str2;
      switch (str1.Length)
      {
        case 2:
          if (str1 == "UE")
          {
            str2 = "UE_INIT.REQ";
            break;
          }
          goto label_17;
        case 7:
          switch (str1[0])
          {
            case 'N':
              if (str1 == "Network")
              {
                str2 = "N_INIT.REQ";
                break;
              }
              goto label_17;
            case 'P':
              if (str1 == "Process")
              {
                str2 = "AP_INIT.REQ";
                break;
              }
              goto label_17;
            case 'S':
              if (str1 == "Session")
              {
                str2 = "S_INIT.REQ";
                break;
              }
              goto label_17;
            default:
              goto label_17;
          }
          break;
        case 9:
          if (str1 == "Transport")
          {
            str2 = "T_INIT.REQ";
            break;
          }
          goto label_17;
        case 11:
          if (str1 == "Application")
          {
            str2 = "A_INIT.REQ";
            break;
          }
          goto label_17;
        case 12:
          if (str1 == "Presentation")
          {
            str2 = "P_INIT.REQ";
            break;
          }
          goto label_17;
        default:
          goto label_17;
      }
      for (int index = 0; index < this.d.Count; ++index)
      {
        if (((Control) this.d[index]).Text == str2)
        {
          if (((Form) this.d[index]).WindowState == FormWindowState.Minimized)
            ((Form) this.d[index]).WindowState = FormWindowState.Normal;
          ((Control) this.d[index]).BringToFront();
          return;
        }
      }
      ak[] akArray;
      if (v.t)
      {
        akArray = new ak[1]{ this.d() };
      }
      else
      {
        string str3 = this.d().k();
        if (str3 != null)
        {
          switch (str3.Length)
          {
            case 2:
              if (str3 == "UE")
              {
                akArray = new ak[2]
                {
                  this.c.d().j(),
                  this.c.b().j()
                };
                goto label_45;
              }
              else
                break;
            case 7:
              switch (str3[0])
              {
                case 'N':
                  if (str3 == "Network")
                  {
                    akArray = new ak[3]
                    {
                      this.c.d().e(),
                      this.c.c().e(),
                      this.c.b().e()
                    };
                    goto label_45;
                  }
                  else
                    break;
                case 'P':
                  if (str3 == "Process")
                  {
                    akArray = new ak[2]
                    {
                      this.c.d().k(),
                      this.c.b().k()
                    };
                    goto label_45;
                  }
                  else
                    break;
                case 'S':
                  if (str3 == "Session")
                  {
                    akArray = new ak[3]
                    {
                      this.c.d().g(),
                      this.c.c().g(),
                      this.c.b().g()
                    };
                    goto label_45;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str3 == "Transport")
              {
                akArray = new ak[3]
                {
                  this.c.d().f(),
                  this.c.c().f(),
                  this.c.b().f()
                };
                goto label_45;
              }
              else
                break;
            case 11:
              if (str3 == "Application")
              {
                akArray = new ak[2]
                {
                  this.c.d().i(),
                  this.c.b().i()
                };
                goto label_45;
              }
              else
                break;
            case 12:
              if (str3 == "Presentation")
              {
                akArray = new ak[3]
                {
                  this.c.d().h(),
                  this.c.c().h(),
                  this.c.b().h()
                };
                goto label_45;
              }
              else
                break;
          }
        }
        throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      }
label_45:
      if (this.d().h().IndexOfKey((object) str2) == -1)
      {
        for (int index = 0; index < akArray.Length; ++index)
        {
          aj aj = new aj(str2, akArray[index].j());
          akArray[index].h().Add((object) str2, (object) aj);
        }
      }
      aj[] A_0_1 = new aj[akArray.Length];
      for (int index = 0; index < akArray.Length; ++index)
        A_0_1[index] = akArray[index].h()[(object) str2] as aj;
      global::j j = new global::j(A_0_1, this.c);
      this.d.Add((object) j);
      j.Show();
      return;
    }
label_17:
    throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
  }

  private void b(object A_0, EventArgs A_1)
  {
    if (!v.t)
      return;
    string[] A_1_1 = new string[2];
    switch (this.c().b())
    {
      case "SystemA":
        A_1_1[0] = "SystemB";
        A_1_1[1] = "Guide";
        break;
      case "Guide":
        A_1_1[1] = "SystemB";
        A_1_1[0] = "SystemA";
        break;
      case "SystemB":
        A_1_1[1] = "Guide";
        A_1_1[0] = "SystemA";
        break;
    }
    global::h h = new global::h("Копировать событие " + this.r.SelectedItem.ToString() + " в систему ", A_1_1);
    if (h.ShowDialog() == DialogResult.OK)
    {
      switch (h.b())
      {
        case "SystemA":
          string str1 = this.d().k();
          if (str1 != null)
          {
            ak ak;
            switch (str1.Length)
            {
              case 2:
                if (str1 == "UE")
                {
                  ak = this.c.d().j();
                  break;
                }
                goto label_24;
              case 7:
                switch (str1[0])
                {
                  case 'N':
                    if (str1 == "Network")
                    {
                      ak = this.c.d().e();
                      break;
                    }
                    goto label_24;
                  case 'P':
                    if (str1 == "Process")
                    {
                      ak = this.c.d().k();
                      break;
                    }
                    goto label_24;
                  case 'S':
                    if (str1 == "Session")
                    {
                      ak = this.c.d().g();
                      break;
                    }
                    goto label_24;
                  default:
                    goto label_24;
                }
                break;
              case 9:
                if (str1 == "Transport")
                {
                  ak = this.c.d().f();
                  break;
                }
                goto label_24;
              case 11:
                if (str1 == "Application")
                {
                  ak = this.c.d().i();
                  break;
                }
                goto label_24;
              case 12:
                if (str1 == "Presentation")
                {
                  ak = this.c.d().h();
                  break;
                }
                goto label_24;
              default:
                goto label_24;
            }
            if (ak.h().IndexOfKey(this.r.SelectedItem) != -1)
            {
              int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            aj aj = (this.d().h()[this.r.SelectedItem] as aj).a();
            ak.h().Add(this.r.SelectedItem, (object) aj);
            break;
          }
label_24:
          throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
        case "Guide":
          string str2 = this.d().k();
          if (str2 != null)
          {
            ak ak;
            switch (str2.Length)
            {
              case 2:
                if (str2 == "UE")
                {
                  ak = this.c.c().j();
                  break;
                }
                goto label_45;
              case 7:
                switch (str2[0])
                {
                  case 'N':
                    if (str2 == "Network")
                    {
                      ak = this.c.c().e();
                      break;
                    }
                    goto label_45;
                  case 'P':
                    if (str2 == "Process")
                    {
                      ak = this.c.c().k();
                      break;
                    }
                    goto label_45;
                  case 'S':
                    if (str2 == "Session")
                    {
                      ak = this.c.c().g();
                      break;
                    }
                    goto label_45;
                  default:
                    goto label_45;
                }
                break;
              case 9:
                if (str2 == "Transport")
                {
                  ak = this.c.c().f();
                  break;
                }
                goto label_45;
              case 11:
                if (str2 == "Application")
                {
                  ak = this.c.c().i();
                  break;
                }
                goto label_45;
              case 12:
                if (str2 == "Presentation")
                {
                  ak = this.c.c().h();
                  break;
                }
                goto label_45;
              default:
                goto label_45;
            }
            if (ak.h().IndexOfKey(this.r.SelectedItem) != -1)
            {
              int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            aj aj = (this.d().h()[this.r.SelectedItem] as aj).a();
            ak.h().Add(this.r.SelectedItem, (object) aj);
            break;
          }
label_45:
          throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
        case "SystemB":
          string str3 = this.d().k();
          if (str3 != null)
          {
            ak ak;
            switch (str3.Length)
            {
              case 2:
                if (str3 == "UE")
                {
                  ak = this.c.b().j();
                  break;
                }
                goto label_67;
              case 7:
                switch (str3[0])
                {
                  case 'N':
                    if (str3 == "Network")
                    {
                      ak = this.c.b().e();
                      break;
                    }
                    goto label_67;
                  case 'P':
                    if (str3 == "Process")
                    {
                      ak = this.c.b().k();
                      break;
                    }
                    goto label_67;
                  case 'S':
                    if (str3 == "Session")
                    {
                      ak = this.c.b().g();
                      break;
                    }
                    goto label_67;
                  default:
                    goto label_67;
                }
                break;
              case 9:
                if (str3 == "Transport")
                {
                  ak = this.c.b().f();
                  break;
                }
                goto label_67;
              case 11:
                if (str3 == "Application")
                {
                  ak = this.c.b().i();
                  break;
                }
                goto label_67;
              case 12:
                if (str3 == "Presentation")
                {
                  ak = this.c.b().h();
                  break;
                }
                goto label_67;
              default:
                goto label_67;
            }
            if (ak.h().IndexOfKey(this.r.SelectedItem) != -1)
            {
              int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            aj aj = (this.d().h()[this.r.SelectedItem] as aj).a();
            ak.h().Add(this.r.SelectedItem, (object) aj);
            break;
          }
label_67:
          throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      }
    }
    h.Dispose();
  }

  private void a(object A_0, EventArgs A_1)
  {
  }

  private void a(object A_0, FormClosingEventArgs A_1)
  {
    for (int index = 0; index < this.d.Count; ++index)
      (this.d[index] as global::j).Close();
    this.d.Clear();
    A_1.Cancel = true;
    this.Hide();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.e != null)
      this.e.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.f = new Button();
    this.g = new Button();
    this.h = new Button();
    this.i = new Button();
    this.j = new Button();
    this.k = new Button();
    this.l = new GroupBox();
    this.m = new RadioButton();
    this.n = new RadioButton();
    this.o = new Button();
    this.p = new Button();
    this.q = new Button();
    this.r = new ListBox();
    this.s = new Label();
    this.t = new Button();
    this.l.SuspendLayout();
    this.SuspendLayout();
    this.f.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.f.Location = new Point(193, 32);
    this.f.Name = "EditButton";
    this.f.Size = new Size(112, 28);
    this.f.TabIndex = 0;
    this.f.Text = "Редактировать...";
    this.f.UseVisualStyleBackColor = true;
    this.f.Click += new EventHandler(this.d);
    this.g.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.g.Location = new Point(193, 66);
    this.g.Name = "AddButton";
    this.g.Size = new Size(112, 28);
    this.g.TabIndex = 1;
    this.g.Text = "Добавить...";
    this.g.UseVisualStyleBackColor = true;
    this.g.Click += new EventHandler(this.h);
    this.h.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.h.Location = new Point(193, 134);
    this.h.Name = "DeleteButton";
    this.h.Size = new Size(112, 28);
    this.h.TabIndex = 2;
    this.h.Text = "Удалить...";
    this.h.UseVisualStyleBackColor = true;
    this.h.Click += new EventHandler(this.g);
    this.i.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.i.Location = new Point(193, 168);
    this.i.Name = "CopyButton";
    this.i.Size = new Size(112, 28);
    this.i.TabIndex = 3;
    this.i.Text = "Копировать...";
    this.i.UseVisualStyleBackColor = true;
    this.i.Click += new EventHandler(this.b);
    this.j.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.j.Location = new Point(193, 202);
    this.j.Name = "ReduplicateButton";
    this.j.Size = new Size(112, 28);
    this.j.TabIndex = 4;
    this.j.Text = "Повторить";
    this.j.UseVisualStyleBackColor = true;
    this.j.Click += new EventHandler(this.e);
    this.k.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.k.Location = new Point(193, 236);
    this.k.Name = "InitButton";
    this.k.Size = new Size(112, 28);
    this.k.TabIndex = 5;
    this.k.Text = "Инициализация...";
    this.k.UseVisualStyleBackColor = true;
    this.k.Click += new EventHandler(this.c);
    this.l.Controls.Add((Control) this.m);
    this.l.Controls.Add((Control) this.n);
    this.l.Location = new Point(193, 270);
    this.l.Name = "groupBox1";
    this.l.Size = new Size(112, 67);
    this.l.TabIndex = 6;
    this.l.TabStop = false;
    this.l.Text = "Активный банк";
    this.m.AutoSize = true;
    this.m.Location = new Point(16, 42);
    this.m.Name = "Bank1Button";
    this.m.Size = new Size(59, 17);
    this.m.TabIndex = 1;
    this.m.Text = "Банк 1";
    this.m.UseVisualStyleBackColor = true;
    this.n.AutoSize = true;
    this.n.Checked = true;
    this.n.Location = new Point(16, 19);
    this.n.Name = "Bank0Button";
    this.n.Size = new Size(59, 17);
    this.n.TabIndex = 0;
    this.n.TabStop = true;
    this.n.Text = "Банк 0";
    this.n.UseVisualStyleBackColor = true;
    this.n.CheckedChanged += new EventHandler(this.i);
    this.o.DialogResult = DialogResult.Cancel;
    this.o.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.o.Location = new Point(193, 385);
    this.o.Name = "CloseButton";
    this.o.Size = new Size(112, 28);
    this.o.TabIndex = 7;
    this.o.Text = "Закрыть";
    this.o.UseVisualStyleBackColor = true;
    this.o.Click += new EventHandler(this.l);
    this.p.Image = (Image) Resources.LeftArrow;
    this.p.Location = new Point(193, 344);
    this.p.Name = "LeftSystemButton";
    this.p.Size = new Size(36, 26);
    this.p.TabIndex = 8;
    this.p.UseVisualStyleBackColor = true;
    this.p.Visible = false;
    this.p.Click += new EventHandler(this.j);
    this.q.Image = (Image) Resources.RightArrow;
    this.q.Location = new Point(269, 343);
    this.q.Name = "RightSystemButton";
    this.q.Size = new Size(36, 26);
    this.q.TabIndex = 9;
    this.q.UseVisualStyleBackColor = true;
    this.q.Visible = false;
    this.q.Click += new EventHandler(this.k);
    this.r.FormattingEnabled = true;
    this.r.Location = new Point(3, 32);
    this.r.Name = "EventsListBox";
    this.r.SelectionMode = SelectionMode.MultiExtended;
    this.r.Size = new Size(184, 381);
    this.r.Sorted = true;
    this.r.TabIndex = 0;
    this.r.KeyDown += new KeyEventHandler(this.a);
    this.r.MouseDoubleClick += new MouseEventHandler(this.a);
    this.s.Location = new Point(0, 3);
    this.s.Name = "label1";
    this.s.Size = new Size(187, 26);
    this.s.TabIndex = 11;
    this.s.Text = "Выберите событие для редактирования кода обработчика:";
    this.t.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.t.Location = new Point(193, 100);
    this.t.Name = "RenameButton";
    this.t.Size = new Size(112, 28);
    this.t.TabIndex = 12;
    this.t.Text = "Переименовать...";
    this.t.UseVisualStyleBackColor = true;
    this.t.Click += new EventHandler(this.f);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.o;
    this.ClientSize = new Size(308, 417);
    this.Controls.Add((Control) this.t);
    this.Controls.Add((Control) this.s);
    this.Controls.Add((Control) this.r);
    this.Controls.Add((Control) this.q);
    this.Controls.Add((Control) this.p);
    this.Controls.Add((Control) this.o);
    this.Controls.Add((Control) this.l);
    this.Controls.Add((Control) this.k);
    this.Controls.Add((Control) this.j);
    this.Controls.Add((Control) this.i);
    this.Controls.Add((Control) this.h);
    this.Controls.Add((Control) this.g);
    this.Controls.Add((Control) this.f);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.ImeMode = ImeMode.NoControl;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = "LevEditorForm";
    this.ShowIcon = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.FormClosing += new FormClosingEventHandler(this.a);
    this.Shown += new EventHandler(this.a);
    this.l.ResumeLayout(false);
    this.l.PerformLayout();
    this.ResumeLayout(false);
  }
}
