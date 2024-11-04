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
public class LayerWindow : Form
{
  private an an;
  private ArrayList editors;
  private IContainer e;
  private Button editButton;
  private Button addButton;
  private Button deleteButton;
  private Button copyButton;
  private Button reduplicateButton;
  private Button initButton;
  private GroupBox activeBankBox;
  private RadioButton bank1Button;
  private RadioButton bank0Button;
  private Button closeButton;
  private Button leftSystemButton;
  private Button rightSystemButton;
  private ListBox eventsListBox;
  private Label label1;
  private Button renameButton;

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

  public LayerWindow(an an)
  {
    this.Initialize();
    this.an = an;
    this.editors = new ArrayList();
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
      if (MainWindow.t)
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
      this.leftSystemButton.Visible = MainWindow.t;
      this.rightSystemButton.Visible = MainWindow.t;
      int index1 = this.d().h().IndexOfKey((object) key);
      if (index1 >= 0)
        (this.d().h().GetByIndex(index1) as aj).a(true);
      if (this.d().i() == (byte) 0)
        this.bank0Button.Checked = true;
      else
        this.bank1Button.Checked = true;
      this.eventsListBox.Items.Clear();
      for (int index2 = 0; index2 < this.d().h().Count; ++index2)
      {
        if (!(this.d().h().GetByIndex(index2) as aj).n())
          this.eventsListBox.Items.Add((object) (this.d().h().GetByIndex(index2) as aj).o());
      }
      return;
    }
label_17:
    throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
  }

  private void OnCloseButtonClick(object A_0, EventArgs A_1) => this.Close();

  private void OnRightSystemButtonClick(object A_0, EventArgs A_1)
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
                this.a(this.an.c());
                this.a(this.an.c().j());
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
                    this.a(this.an.c());
                    this.a(this.an.c().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str1 == "Process")
                  {
                    this.a(this.an.c());
                    this.a(this.an.c().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str1 == "Session")
                  {
                    this.a(this.an.c());
                    this.a(this.an.c().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str1 == "Transport")
              {
                this.a(this.an.c());
                this.a(this.an.c().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str1 == "Application")
              {
                this.a(this.an.c());
                this.a(this.an.c().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str1 == "Presentation")
              {
                this.a(this.an.c());
                this.a(this.an.c().h());
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
                this.a(this.an.b());
                this.a(this.an.b().j());
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
                    this.a(this.an.b());
                    this.a(this.an.b().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str2 == "Process")
                  {
                    this.a(this.an.b());
                    this.a(this.an.b().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str2 == "Session")
                  {
                    this.a(this.an.b());
                    this.a(this.an.b().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str2 == "Transport")
              {
                this.a(this.an.b());
                this.a(this.an.b().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str2 == "Application")
              {
                this.a(this.an.b());
                this.a(this.an.b().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str2 == "Presentation")
              {
                this.a(this.an.b());
                this.a(this.an.b().h());
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
                this.a(this.an.d());
                this.a(this.an.d().j());
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
                    this.a(this.an.d());
                    this.a(this.an.d().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str3 == "Process")
                  {
                    this.a(this.an.d());
                    this.a(this.an.d().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str3 == "Session")
                  {
                    this.a(this.an.d());
                    this.a(this.an.d().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str3 == "Transport")
              {
                this.a(this.an.d());
                this.a(this.an.d().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str3 == "Application")
              {
                this.a(this.an.d());
                this.a(this.an.d().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str3 == "Presentation")
              {
                this.a(this.an.d());
                this.a(this.an.d().h());
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

  private void OnLeftSystemButtonClick(object A_0, EventArgs A_1)
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
                this.a(this.an.c());
                this.a(this.an.c().j());
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
                    this.a(this.an.c());
                    this.a(this.an.c().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str1 == "Process")
                  {
                    this.a(this.an.c());
                    this.a(this.an.c().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str1 == "Session")
                  {
                    this.a(this.an.c());
                    this.a(this.an.c().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str1 == "Transport")
              {
                this.a(this.an.c());
                this.a(this.an.c().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str1 == "Application")
              {
                this.a(this.an.c());
                this.a(this.an.c().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str1 == "Presentation")
              {
                this.a(this.an.c());
                this.a(this.an.c().h());
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
                this.a(this.an.b());
                this.a(this.an.b().j());
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
                    this.a(this.an.b());
                    this.a(this.an.b().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str2 == "Process")
                  {
                    this.a(this.an.b());
                    this.a(this.an.b().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str2 == "Session")
                  {
                    this.a(this.an.b());
                    this.a(this.an.b().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str2 == "Transport")
              {
                this.a(this.an.b());
                this.a(this.an.b().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str2 == "Application")
              {
                this.a(this.an.b());
                this.a(this.an.b().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str2 == "Presentation")
              {
                this.a(this.an.b());
                this.a(this.an.b().h());
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
                this.a(this.an.d());
                this.a(this.an.d().j());
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
                    this.a(this.an.d());
                    this.a(this.an.d().e());
                    goto label_56;
                  }
                  else
                    break;
                case 'P':
                  if (str3 == "Process")
                  {
                    this.a(this.an.d());
                    this.a(this.an.d().k());
                    goto label_56;
                  }
                  else
                    break;
                case 'S':
                  if (str3 == "Session")
                  {
                    this.a(this.an.d());
                    this.a(this.an.d().g());
                    goto label_56;
                  }
                  else
                    break;
              }
              break;
            case 9:
              if (str3 == "Transport")
              {
                this.a(this.an.d());
                this.a(this.an.d().f());
                goto label_56;
              }
              else
                break;
            case 11:
              if (str3 == "Application")
              {
                this.a(this.an.d());
                this.a(this.an.d().i());
                goto label_56;
              }
              else
                break;
            case 12:
              if (str3 == "Presentation")
              {
                this.a(this.an.d());
                this.a(this.an.d().h());
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

  private void OnBankChange(object A_0, EventArgs A_1)
  {
    if (this.bank0Button.Checked)
    {
      this.an.d().e().a((byte) 0);
      this.an.c().e().a((byte) 0);
      this.an.b().e().a((byte) 0);
      this.an.d().f().a((byte) 0);
      this.an.d().g().a((byte) 0);
      this.an.d().h().a((byte) 0);
      this.an.d().i().a((byte) 0);
      this.an.d().j().a((byte) 0);
      this.an.d().k().a((byte) 0);
      this.an.c().f().a((byte) 0);
      this.an.c().g().a((byte) 0);
      this.an.c().h().a((byte) 0);
      this.an.c().i().a((byte) 0);
      this.an.c().j().a((byte) 0);
      this.an.c().k().a((byte) 0);
      this.an.b().f().a((byte) 0);
      this.an.b().g().a((byte) 0);
      this.an.b().h().a((byte) 0);
      this.an.b().i().a((byte) 0);
      this.an.b().j().a((byte) 0);
      this.an.b().k().a((byte) 0);
    }
    else
    {
      this.an.d().e().a((byte) 1);
      this.an.c().e().a((byte) 1);
      this.an.b().e().a((byte) 1);
      this.an.d().f().a((byte) 1);
      this.an.d().g().a((byte) 1);
      this.an.d().h().a((byte) 1);
      this.an.d().i().a((byte) 1);
      this.an.d().j().a((byte) 1);
      this.an.d().k().a((byte) 1);
      this.an.c().f().a((byte) 1);
      this.an.c().g().a((byte) 1);
      this.an.c().h().a((byte) 1);
      this.an.c().i().a((byte) 1);
      this.an.c().j().a((byte) 1);
      this.an.c().k().a((byte) 1);
      this.an.b().f().a((byte) 1);
      this.an.b().g().a((byte) 1);
      this.an.b().h().a((byte) 1);
      this.an.b().i().a((byte) 1);
      this.an.b().j().a((byte) 1);
      this.an.b().k().a((byte) 1);
    }
    this.b();
  }

  private void OnAddButtonClick(object A_0, EventArgs A_1)
  {
    ak[] A_0_1;
    if (MainWindow.t)
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
                this.an.d().j(),
                this.an.b().j()
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
                    this.an.d().e(),
                    this.an.c().e(),
                    this.an.b().e()
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
                    this.an.d().k(),
                    this.an.b().k()
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
                    this.an.d().g(),
                    this.an.c().g(),
                    this.an.b().g()
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
                this.an.d().f(),
                this.an.c().f(),
                this.an.b().f()
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
                this.an.d().i(),
                this.an.b().i()
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
                this.an.d().h(),
                this.an.c().h(),
                this.an.b().h()
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

  private void OnDeleteButtonClick(object A_0, EventArgs A_1)
  {
    if (MessageBox.Show(Resources.ConfirmRemove + this.eventsListBox.SelectedItems.Count.ToString() + Resources.Event_sQuestion, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
      return;
    if (MainWindow.t)
    {
      for (int index = this.eventsListBox.SelectedItems.Count - 1; index >= 0; --index)
        this.d().h().Remove(this.eventsListBox.SelectedItems[index]);
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
                this.an.d().j(),
                this.an.b().j()
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
                    this.an.d().e(),
                    this.an.c().e(),
                    this.an.b().e()
                  };
                  break;
                }
                goto label_23;
              case 'P':
                if (str == "Process")
                {
                  akArray = new ak[2]
                  {
                    this.an.d().k(),
                    this.an.b().k()
                  };
                  break;
                }
                goto label_23;
              case 'S':
                if (str == "Session")
                {
                  akArray = new ak[3]
                  {
                    this.an.d().g(),
                    this.an.c().g(),
                    this.an.b().g()
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
                this.an.d().f(),
                this.an.c().f(),
                this.an.b().f()
              };
              break;
            }
            goto label_23;
          case 11:
            if (str == "Application")
            {
              akArray = new ak[2]
              {
                this.an.d().i(),
                this.an.b().i()
              };
              break;
            }
            goto label_23;
          case 12:
            if (str == "Presentation")
            {
              akArray = new ak[3]
              {
                this.an.d().h(),
                this.an.c().h(),
                this.an.b().h()
              };
              break;
            }
            goto label_23;
          default:
            goto label_23;
        }
        for (int index1 = 0; index1 < akArray.Length; ++index1)
        {
          for (int index2 = this.eventsListBox.SelectedItems.Count - 1; index2 >= 0; --index2)
            akArray[index1].h().Remove(this.eventsListBox.SelectedItems[index2]);
        }
        goto label_30;
      }
label_23:
      throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
    }
label_30:
    this.b();
  }

  private void f_func(object A_0, EventArgs A_1)
  {
    if (this.eventsListBox.SelectedItems.Count <= 0)
      return;
    ak[] A_1_1;
    if (MainWindow.t)
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
                this.an.d().j(),
                this.an.b().j()
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
                    this.an.d().e(),
                    this.an.c().e(),
                    this.an.b().e()
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
                    this.an.d().k(),
                    this.an.b().k()
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
                    this.an.d().g(),
                    this.an.c().g(),
                    this.an.b().g()
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
                this.an.d().f(),
                this.an.c().f(),
                this.an.b().f()
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
                this.an.d().i(),
                this.an.b().i()
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
                this.an.d().h(),
                this.an.c().h(),
                this.an.b().h()
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
    global::r r = new global::r(this.eventsListBox.SelectedItem.ToString(), A_1_1);
    int num = (int) r.ShowDialog();
    this.b();
    r.Dispose();
  }

  private void OnReduplicateButtonClick(object A_0, EventArgs A_1)
  {
    ak[] akArray;
    if (MainWindow.t)
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
                this.an.d().j(),
                this.an.b().j()
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
                    this.an.d().e(),
                    this.an.c().e(),
                    this.an.b().e()
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
                    this.an.d().k(),
                    this.an.b().k()
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
                    this.an.d().g(),
                    this.an.c().g(),
                    this.an.b().g()
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
                this.an.d().f(),
                this.an.c().f(),
                this.an.b().f()
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
                this.an.d().i(),
                this.an.b().i()
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
                this.an.d().h(),
                this.an.c().h(),
                this.an.b().h()
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
        for (int index2 = 0; index2 < this.eventsListBox.SelectedItems.Count; ++index2)
        {
          if (akArray[index1].c().IndexOfKey(this.eventsListBox.SelectedItems[index2]) != -1)
          {
            int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          }
          aj aj = (akArray[index1].h()[this.eventsListBox.SelectedItems[index2]] as aj).a();
          akArray[index1].c().Add((object) aj.o(), (object) aj);
        }
      }
      else
      {
        for (int index3 = 0; index3 < this.eventsListBox.SelectedItems.Count; ++index3)
        {
          if (akArray[index1].g().IndexOfKey(this.eventsListBox.SelectedItems[index3]) != -1)
          {
            int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          }
          aj aj = (akArray[index1].h()[this.eventsListBox.SelectedItems[index3]] as aj).a();
          akArray[index1].g().Add((object) aj.o(), (object) aj);
        }
      }
    }
  }

  private void OnEventKeyDown(object A_0, KeyEventArgs A_1)
  {
    switch (A_1.KeyCode)
    {
      case Keys.Return:
        this.editButton.PerformClick();
        break;
      case Keys.Insert:
        this.addButton.PerformClick();
        break;
      case Keys.Delete:
        this.deleteButton.PerformClick();
        break;
      case Keys.F2:
        this.renameButton.PerformClick();
        break;
    }
  }

  private void d_func(object A_0, EventArgs A_1)
  {
    if (this.eventsListBox.SelectedIndex < 0)
      return;
    for (int index = 0; index < this.editors.Count; ++index)
    {
      if (((Control) this.editors[index]).Text == this.eventsListBox.SelectedItem.ToString())
      {
        if (((Form) this.editors[index]).WindowState == FormWindowState.Minimized)
          ((Form) this.editors[index]).WindowState = FormWindowState.Normal;
        ((Control) this.editors[index]).BringToFront();
        return;
      }
    }
    ak[] akArray;
    if (MainWindow.t)
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
                this.an.d().j(),
                this.an.b().j()
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
                    this.an.d().e(),
                    this.an.c().e(),
                    this.an.b().e()
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
                    this.an.d().k(),
                    this.an.b().k()
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
                    this.an.d().g(),
                    this.an.c().g(),
                    this.an.b().g()
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
                this.an.d().f(),
                this.an.c().f(),
                this.an.b().f()
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
                this.an.d().i(),
                this.an.b().i()
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
                this.an.d().h(),
                this.an.c().h(),
                this.an.b().h()
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
    if (this.eventsListBox.SelectedItems.Count <= 0)
      return;
    for (int index = 0; index < akArray.Length; ++index)
    {
      if (akArray[index].h().IndexOfKey((object) this.eventsListBox.SelectedItem.ToString()) == -1)
      {
        aj aj = new aj(this.eventsListBox.SelectedItem.ToString(), akArray[index].j());
        akArray[index].h().Add((object) this.eventsListBox.SelectedItem.ToString(), (object) aj);
      }
      A_0_1[index] = akArray[index].h()[(object) this.eventsListBox.SelectedItem.ToString()] as aj;
    }
    global::EditorWindow j = new global::EditorWindow(A_0_1, this.an);
    this.editors.Add((object) j);
    j.Show();
  }

  private void OnEventClick(object A_0, MouseEventArgs A_1) => this.editButton.PerformClick();

  private void OnInitButtonClick(object A_0, EventArgs A_1)
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
      for (int index = 0; index < this.editors.Count; ++index)
      {
        if (((Control) this.editors[index]).Text == str2)
        {
          if (((Form) this.editors[index]).WindowState == FormWindowState.Minimized)
            ((Form) this.editors[index]).WindowState = FormWindowState.Normal;
          ((Control) this.editors[index]).BringToFront();
          return;
        }
      }
      ak[] akArray;
      if (MainWindow.t)
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
                  this.an.d().j(),
                  this.an.b().j()
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
                      this.an.d().e(),
                      this.an.c().e(),
                      this.an.b().e()
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
                      this.an.d().k(),
                      this.an.b().k()
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
                      this.an.d().g(),
                      this.an.c().g(),
                      this.an.b().g()
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
                  this.an.d().f(),
                  this.an.c().f(),
                  this.an.b().f()
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
                  this.an.d().i(),
                  this.an.b().i()
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
                  this.an.d().h(),
                  this.an.c().h(),
                  this.an.b().h()
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
      global::EditorWindow editorWindow = new global::EditorWindow(A_0_1, this.an);
      this.editors.Add((object) editorWindow);
      editorWindow.Show();
      return;
    }
label_17:
    throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
  }

  private void OnCopyButtonClick(object A_0, EventArgs A_1)
  {
    if (!MainWindow.t)
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
    global::h h = new global::h("Копировать событие " + this.eventsListBox.SelectedItem.ToString() + " в систему ", A_1_1);
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
                  ak = this.an.d().j();
                  break;
                }
                goto label_24;
              case 7:
                switch (str1[0])
                {
                  case 'N':
                    if (str1 == "Network")
                    {
                      ak = this.an.d().e();
                      break;
                    }
                    goto label_24;
                  case 'P':
                    if (str1 == "Process")
                    {
                      ak = this.an.d().k();
                      break;
                    }
                    goto label_24;
                  case 'S':
                    if (str1 == "Session")
                    {
                      ak = this.an.d().g();
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
                  ak = this.an.d().f();
                  break;
                }
                goto label_24;
              case 11:
                if (str1 == "Application")
                {
                  ak = this.an.d().i();
                  break;
                }
                goto label_24;
              case 12:
                if (str1 == "Presentation")
                {
                  ak = this.an.d().h();
                  break;
                }
                goto label_24;
              default:
                goto label_24;
            }
            if (ak.h().IndexOfKey(this.eventsListBox.SelectedItem) != -1)
            {
              int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            aj aj = (this.d().h()[this.eventsListBox.SelectedItem] as aj).a();
            ak.h().Add(this.eventsListBox.SelectedItem, (object) aj);
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
                  ak = this.an.c().j();
                  break;
                }
                goto label_45;
              case 7:
                switch (str2[0])
                {
                  case 'N':
                    if (str2 == "Network")
                    {
                      ak = this.an.c().e();
                      break;
                    }
                    goto label_45;
                  case 'P':
                    if (str2 == "Process")
                    {
                      ak = this.an.c().k();
                      break;
                    }
                    goto label_45;
                  case 'S':
                    if (str2 == "Session")
                    {
                      ak = this.an.c().g();
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
                  ak = this.an.c().f();
                  break;
                }
                goto label_45;
              case 11:
                if (str2 == "Application")
                {
                  ak = this.an.c().i();
                  break;
                }
                goto label_45;
              case 12:
                if (str2 == "Presentation")
                {
                  ak = this.an.c().h();
                  break;
                }
                goto label_45;
              default:
                goto label_45;
            }
            if (ak.h().IndexOfKey(this.eventsListBox.SelectedItem) != -1)
            {
              int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            aj aj = (this.d().h()[this.eventsListBox.SelectedItem] as aj).a();
            ak.h().Add(this.eventsListBox.SelectedItem, (object) aj);
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
                  ak = this.an.b().j();
                  break;
                }
                goto label_67;
              case 7:
                switch (str3[0])
                {
                  case 'N':
                    if (str3 == "Network")
                    {
                      ak = this.an.b().e();
                      break;
                    }
                    goto label_67;
                  case 'P':
                    if (str3 == "Process")
                    {
                      ak = this.an.b().k();
                      break;
                    }
                    goto label_67;
                  case 'S':
                    if (str3 == "Session")
                    {
                      ak = this.an.b().g();
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
                  ak = this.an.b().f();
                  break;
                }
                goto label_67;
              case 11:
                if (str3 == "Application")
                {
                  ak = this.an.b().i();
                  break;
                }
                goto label_67;
              case 12:
                if (str3 == "Presentation")
                {
                  ak = this.an.b().h();
                  break;
                }
                goto label_67;
              default:
                goto label_67;
            }
            if (ak.h().IndexOfKey(this.eventsListBox.SelectedItem) != -1)
            {
              int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              break;
            }
            aj aj = (this.d().h()[this.eventsListBox.SelectedItem] as aj).a();
            ak.h().Add(this.eventsListBox.SelectedItem, (object) aj);
            break;
          }
label_67:
          throw new IndexOutOfRangeException(Resources.ErrorUnknownLevel);
      }
    }
    h.Dispose();
  }

  private void OnFormShown(object A_0, EventArgs A_1)
  {
  }

  private void OnFormClosing(object A_0, FormClosingEventArgs A_1)
  {
    for (int index = 0; index < this.editors.Count; ++index)
      (this.editors[index] as global::EditorWindow).Close();
    this.editors.Clear();
    A_1.Cancel = true;
    this.Hide();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.e != null)
      this.e.Dispose();
    base.Dispose(disposing);
  }

  private void Initialize()
  {
    this.editButton = new Button();
    this.addButton = new Button();
    this.deleteButton = new Button();
    this.copyButton = new Button();
    this.reduplicateButton = new Button();
    this.initButton = new Button();
    this.activeBankBox = new GroupBox();
    this.bank1Button = new RadioButton();
    this.bank0Button = new RadioButton();
    this.closeButton = new Button();
    this.leftSystemButton = new Button();
    this.rightSystemButton = new Button();
    this.eventsListBox = new ListBox();
    this.label1 = new Label();
    this.renameButton = new Button();
    this.activeBankBox.SuspendLayout();
    this.SuspendLayout();
    this.editButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.editButton.Location = new Point(193, 32);
    this.editButton.Name = "EditButton";
    this.editButton.Size = new Size(112, 28);
    this.editButton.TabIndex = 0;
    this.editButton.Text = "Редактировать...";
    this.editButton.UseVisualStyleBackColor = true;
    this.editButton.Click += new EventHandler(this.d_func);
    this.addButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.addButton.Location = new Point(193, 66);
    this.addButton.Name = "AddButton";
    this.addButton.Size = new Size(112, 28);
    this.addButton.TabIndex = 1;
    this.addButton.Text = "Добавить...";
    this.addButton.UseVisualStyleBackColor = true;
    this.addButton.Click += new EventHandler(this.OnAddButtonClick);
    this.deleteButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.deleteButton.Location = new Point(193, 134);
    this.deleteButton.Name = "DeleteButton";
    this.deleteButton.Size = new Size(112, 28);
    this.deleteButton.TabIndex = 2;
    this.deleteButton.Text = "Удалить...";
    this.deleteButton.UseVisualStyleBackColor = true;
    this.deleteButton.Click += new EventHandler(this.OnDeleteButtonClick);
    this.copyButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.copyButton.Location = new Point(193, 168);
    this.copyButton.Name = "CopyButton";
    this.copyButton.Size = new Size(112, 28);
    this.copyButton.TabIndex = 3;
    this.copyButton.Text = "Копировать...";
    this.copyButton.UseVisualStyleBackColor = true;
    this.copyButton.Click += new EventHandler(this.OnCopyButtonClick);
    this.reduplicateButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.reduplicateButton.Location = new Point(193, 202);
    this.reduplicateButton.Name = "ReduplicateButton";
    this.reduplicateButton.Size = new Size(112, 28);
    this.reduplicateButton.TabIndex = 4;
    this.reduplicateButton.Text = "Повторить";
    this.reduplicateButton.UseVisualStyleBackColor = true;
    this.reduplicateButton.Click += new EventHandler(this.OnReduplicateButtonClick);
    this.initButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.initButton.Location = new Point(193, 236);
    this.initButton.Name = "InitButton";
    this.initButton.Size = new Size(112, 28);
    this.initButton.TabIndex = 5;
    this.initButton.Text = "Инициализация...";
    this.initButton.UseVisualStyleBackColor = true;
    this.initButton.Click += new EventHandler(this.OnInitButtonClick);
    this.activeBankBox.Controls.Add((Control) this.bank1Button);
    this.activeBankBox.Controls.Add((Control) this.bank0Button);
    this.activeBankBox.Location = new Point(193, 270);
    this.activeBankBox.Name = "groupBox1";
    this.activeBankBox.Size = new Size(112, 67);
    this.activeBankBox.TabIndex = 6;
    this.activeBankBox.TabStop = false;
    this.activeBankBox.Text = "Активный банк";
    this.bank1Button.AutoSize = true;
    this.bank1Button.Location = new Point(16, 42);
    this.bank1Button.Name = "Bank1Button";
    this.bank1Button.Size = new Size(59, 17);
    this.bank1Button.TabIndex = 1;
    this.bank1Button.Text = "Банк 1";
    this.bank1Button.UseVisualStyleBackColor = true;
    this.bank0Button.AutoSize = true;
    this.bank0Button.Checked = true;
    this.bank0Button.Location = new Point(16, 19);
    this.bank0Button.Name = "Bank0Button";
    this.bank0Button.Size = new Size(59, 17);
    this.bank0Button.TabIndex = 0;
    this.bank0Button.TabStop = true;
    this.bank0Button.Text = "Банк 0";
    this.bank0Button.UseVisualStyleBackColor = true;
    this.bank0Button.CheckedChanged += new EventHandler(this.OnBankChange);
    this.closeButton.DialogResult = DialogResult.Cancel;
    this.closeButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.closeButton.Location = new Point(193, 385);
    this.closeButton.Name = "CloseButton";
    this.closeButton.Size = new Size(112, 28);
    this.closeButton.TabIndex = 7;
    this.closeButton.Text = "Закрыть";
    this.closeButton.UseVisualStyleBackColor = true;
    this.closeButton.Click += new EventHandler(this.OnCloseButtonClick);
    this.leftSystemButton.Image = (Image) Resources.LeftArrow;
    this.leftSystemButton.Location = new Point(193, 344);
    this.leftSystemButton.Name = "LeftSystemButton";
    this.leftSystemButton.Size = new Size(36, 26);
    this.leftSystemButton.TabIndex = 8;
    this.leftSystemButton.UseVisualStyleBackColor = true;
    this.leftSystemButton.Visible = false;
    this.leftSystemButton.Click += new EventHandler(this.OnLeftSystemButtonClick);
    this.rightSystemButton.Image = (Image) Resources.RightArrow;
    this.rightSystemButton.Location = new Point(269, 343);
    this.rightSystemButton.Name = "RightSystemButton";
    this.rightSystemButton.Size = new Size(36, 26);
    this.rightSystemButton.TabIndex = 9;
    this.rightSystemButton.UseVisualStyleBackColor = true;
    this.rightSystemButton.Visible = false;
    this.rightSystemButton.Click += new EventHandler(this.OnRightSystemButtonClick);
    this.eventsListBox.FormattingEnabled = true;
    this.eventsListBox.Location = new Point(3, 32);
    this.eventsListBox.Name = "EventsListBox";
    this.eventsListBox.SelectionMode = SelectionMode.MultiExtended;
    this.eventsListBox.Size = new Size(184, 381);
    this.eventsListBox.Sorted = true;
    this.eventsListBox.TabIndex = 0;
    this.eventsListBox.KeyDown += new KeyEventHandler(this.OnEventKeyDown);
    this.eventsListBox.MouseDoubleClick += new MouseEventHandler(this.OnEventClick);
    this.label1.Location = new Point(0, 3);
    this.label1.Name = "label1";
    this.label1.Size = new Size(187, 26);
    this.label1.TabIndex = 11;
    this.label1.Text = "Выберите событие для редактирования кода обработчика:";
    this.renameButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
    this.renameButton.Location = new Point(193, 100);
    this.renameButton.Name = "RenameButton";
    this.renameButton.Size = new Size(112, 28);
    this.renameButton.TabIndex = 12;
    this.renameButton.Text = "Переименовать...";
    this.renameButton.UseVisualStyleBackColor = true;
    this.renameButton.Click += new EventHandler(this.f_func);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.closeButton;
    this.ClientSize = new Size(308, 417);
    this.Controls.Add((Control) this.renameButton);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.eventsListBox);
    this.Controls.Add((Control) this.rightSystemButton);
    this.Controls.Add((Control) this.leftSystemButton);
    this.Controls.Add((Control) this.closeButton);
    this.Controls.Add((Control) this.activeBankBox);
    this.Controls.Add((Control) this.initButton);
    this.Controls.Add((Control) this.reduplicateButton);
    this.Controls.Add((Control) this.copyButton);
    this.Controls.Add((Control) this.deleteButton);
    this.Controls.Add((Control) this.addButton);
    this.Controls.Add((Control) this.editButton);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.ImeMode = ImeMode.NoControl;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = "LevEditorForm";
    this.ShowIcon = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.FormClosing += new FormClosingEventHandler(this.OnFormClosing);
    this.Shown += new EventHandler(this.OnFormShown);
    this.activeBankBox.ResumeLayout(false);
    this.activeBankBox.PerformLayout();
    this.ResumeLayout(false);
  }
}
