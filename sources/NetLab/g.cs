// Decompiled with JetBrains decompiler
// Type: g
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
public class g : Form
{
  private DataTable a;
  private ak b;
  private IContainer c;
  private DataGridView d;
  private MenuStrip e;
  private ToolStripMenuItem f;

  public g(ak A_0)
  {
    this.a();
    this.b = A_0;
    this.f.Text = "Добавить уровень " + A_0.k();
  }

  private void b(object A_0, EventArgs A_1)
  {
    for (int index = 0; index < this.b.h().Count; ++index)
    {
      DataRow[] dataRowArray = this.a.Select("EventName = '" + ((aj) this.b.h().GetByIndex(index)).o() + "' AND CRC = '" + ((aj) this.b.h().GetByIndex(index)).m.ToString() + "'");
      if (dataRowArray.Length != 0)
      {
        int num = (int) MessageBox.Show("Событие " + ((aj) this.b.h().GetByIndex(index)).o() + " уже существует.\nАвтор: " + dataRowArray[0].ItemArray[0]?.ToString() + " " + dataRowArray[0].ItemArray[0]?.ToString() + "\nДата изменения сданного: " + dataRowArray[0].ItemArray[4]?.ToString() + "\nДата изменения сдаваемого: " + ((aj) this.b.h().GetByIndex(index)).e().ToString(), "Уже существует", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        this.a.Rows.Add((object) v.q.a, (object) v.q.b, (object) ((aj) this.b.h().GetByIndex(index)).o(), (object) ((aj) this.b.h().GetByIndex(index)).m, (object) ((aj) this.b.h().GetByIndex(index)).e());
    }
  }

  private void a(object A_0, FormClosedEventArgs A_1)
  {
    using (FileStream fileStream = new FileStream(Application.StartupPath + "\\db_date_crc.xml", FileMode.Create, FileAccess.Write))
    {
      this.a.WriteXml((Stream) fileStream, XmlWriteMode.WriteSchema, false);
      fileStream.Close();
    }
  }

  private void a(object A_0, EventArgs A_1)
  {
    this.a = new DataTable();
    using (FileStream fileStream = new FileStream(Application.StartupPath + "\\db_date_crc.xml", FileMode.Open, FileAccess.Read))
    {
      int num = (int) this.a.ReadXml((Stream) fileStream);
      fileStream.Close();
    }
    this.d.DataSource = (object) this.a;
    this.d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    this.d.Columns[0].HeaderText = "ФИО";
    this.d.Columns[1].HeaderText = "Группа";
    this.d.Columns[2].HeaderText = "Имя события";
    this.d.Columns[3].HeaderText = "Контрольная сумма";
    this.d.Columns[4].HeaderText = "Дата изменения";
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.c != null)
      this.c.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.d = new DataGridView();
    this.e = new MenuStrip();
    this.f = new ToolStripMenuItem();
    ((ISupportInitialize) this.d).BeginInit();
    this.e.SuspendLayout();
    this.SuspendLayout();
    this.d.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.d.Dock = DockStyle.Fill;
    this.d.Location = new Point(0, 24);
    this.d.Name = "dataGridView";
    this.d.Size = new Size(586, 338);
    this.d.TabIndex = 0;
    this.e.Items.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.f
    });
    this.e.Location = new Point(0, 0);
    this.e.Name = "MainMenu1";
    this.e.Size = new Size(586, 24);
    this.e.TabIndex = 1;
    this.e.Text = "menuStrip1";
    this.f.Name = "AddMenuItem";
    this.f.Size = new Size(71, 20);
    this.f.Text = "Добавить";
    this.f.Click += new EventHandler(this.b);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(586, 362);
    this.Controls.Add((Control) this.d);
    this.Controls.Add((Control) this.e);
    this.MainMenuStrip = this.e;
    this.Name = "CheatersForm";
    this.Text = "Проверка на совпадения";
    this.FormClosed += new FormClosedEventHandler(this.a);
    this.Shown += new EventHandler(this.a);
    ((ISupportInitialize) this.d).EndInit();
    this.e.ResumeLayout(false);
    this.e.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
