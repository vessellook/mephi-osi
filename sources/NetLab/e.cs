// Decompiled with JetBrains decompiler
// Type: e
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
public class e : Form
{
  private LayerParticipant[] a;
  private IContainer b;
  private ComboBox c;
  private Label d;
  private Button e;
  private Button f;

  public e(LayerParticipant[] A_0)
  {
    this.a();
    this.a = A_0;
    switch (this.a[0].k())
    {
      case "Transport":
        this.c.Items.AddRange((object[]) new string[10]
        {
          "T_CONNECT.REQ",
          "N_CONNECT.IND",
          "T_CONNECT.RESP",
          "N_CONNECT.CONF",
          "T_DISCONNECT.REQ",
          "N_DISCONNECT.IND",
          "T_DATA.REQ",
          "N_DATA.IND",
          "T_DATAGRAM.REQ",
          "N_DATAGRAM.IND"
        });
        break;
      case "Session":
        this.c.Items.AddRange((object[]) new string[18]
        {
          "S_CONNECT.REQ",
          "T_CONNECT.IND",
          "S_CONNECT.RESP",
          "T_CONNECT.CONF",
          "S_U_ABORT.REQ",
          "S_U_ABORT.IND",
          "S_P_ABORT.IND",
          "S_DATA.REQ",
          "S_EXPEDITED_DATA.REQ",
          "T_DATA.IND",
          "S_GIVE_TOKENS.REQ",
          "S_PLEASE_TOKENS.REQ",
          "S_SYNC_MAJOR.REQ",
          "S_SYNC_MAJOR.RESP",
          "S_RESYNCHRONIZE.REQ",
          "S_RESYNCHRONIZE.RESP",
          "S_RELEASE.REQ",
          "S_RELEASE.RESP"
        });
        break;
      case "Presentation":
        this.c.Items.AddRange((object[]) new string[20]
        {
          "P_CONNECT.REQ",
          "S_CONNECT.IND",
          "P_CONNECT.RESP",
          "S_CONNECT.CONF",
          "P_U_ABORT.REQ",
          "S_U_ABORT.IND",
          "S_P_ABORT.IND",
          "P_DATA.REQ",
          "S_DATA.IND",
          "S_EXPEDITED_DATA.IND",
          "P_GIVE_TOKENS.REQ",
          "P_PLEASE_TOKENS.REQ",
          "P_SYNC_MAJOR.REQ",
          "P_SYNC_MAJOR.RESP",
          "P_RESYNCHRONIZE.REQ",
          "P_RESYNCHRONIZE.RESP",
          "P_RELEASE.REQ",
          "P_RELEASE.RESP",
          "S_RELEASE.IND",
          "S_RELEASE.CONF"
        });
        break;
      case "Application":
        this.c.Items.AddRange((object[]) new string[13]
        {
          "A_ASSOCIATE.REQ",
          "A_ASSOCIATE.RESP",
          "A_RELEASE.REQ",
          "A_RELEASE.RESP",
          "A_U_ABORT.REQ",
          "A_TRANSFER_INIT.REQ",
          "A_TRANSFER_INIT.RESP",
          "A_DATA.REQ",
          "P_DATA.IND",
          "A_TERMINATE.REQ",
          "A_TERMINATE.RESP",
          "A_TRANSFER_ABORT.REQ",
          "A_RESOLVE.REQ"
        });
        break;
    }
  }

  private void b(object A_0, EventArgs A_1) => this.Close();

  private void a(object A_0, EventArgs A_1)
  {
    for (int index = 0; index < this.a.Length; ++index)
    {
      if (this.c.Text != "")
      {
        if (this.a[index].h().IndexOfKey((object) this.c.Text) == -1)
        {
          aj aj = new aj(this.c.Text, this.a[index].j());
          if (global::EventsParams.event2params.ContainsKey((object) this.c.Text))
            aj.k().Add(global::EventsParams.event2params[(object) this.c.Text]);
          this.a[index].h().Add((object) this.c.Text, (object) aj);
          this.Close();
        }
        else
        {
          int num = (int) MessageBox.Show(Resources.ErrorEventAlreadyExists, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.b != null)
      this.b.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.c = new ComboBox();
    this.d = new Label();
    this.e = new Button();
    this.f = new Button();
    this.SuspendLayout();
    this.c.FormattingEnabled = true;
    this.c.Location = new Point(15, 25);
    this.c.Name = "EventNameEdit";
    this.c.Size = new Size(208, 21);
    this.c.TabIndex = 0;
    this.d.AutoSize = true;
    this.d.Location = new Point(12, 9);
    this.d.Name = "label1";
    this.d.Size = new Size(162, 13);
    this.d.TabIndex = 1;
    this.d.Text = "Введите имя нового события :";
    this.e.FlatStyle = FlatStyle.Flat;
    this.e.Location = new Point(148, 52);
    this.e.Name = "AddButton";
    this.e.Size = new Size(75, 23);
    this.e.TabIndex = 2;
    this.e.Text = "Добавить";
    this.e.UseVisualStyleBackColor = true;
    this.e.Click += new EventHandler(this.a);
    this.f.DialogResult = DialogResult.Cancel;
    this.f.FlatStyle = FlatStyle.Flat;
    this.f.Location = new Point(15, 52);
    this.f.Name = "Cancel_Button";
    this.f.Size = new Size(75, 23);
    this.f.TabIndex = 3;
    this.f.Text = "Отмена";
    this.f.UseVisualStyleBackColor = true;
    this.f.Click += new EventHandler(this.b);
    this.AcceptButton = (IButtonControl) this.e;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.f;
    this.ClientSize = new Size(235, 84);
    this.Controls.Add((Control) this.f);
    this.Controls.Add((Control) this.e);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.c);
    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
    this.Name = "AddEventDlg";
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "Добавить событие";
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
