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

public class Participant
{
  private MainWindow mainWindow;
  private EmulationRuntime an;

  [CompilerGenerated]
  [SpecialName]
  public LayerParticipant GetProcessLayer() => this.processLayer;

    [CompilerGenerated]
  [SpecialName]
  public void SetProcessLayer(LayerParticipant layer) => this.processLayer = layer;

  [CompilerGenerated]
  [SpecialName]
  public LayerParticipant GetUELayer() => this.ueLayer;

  [CompilerGenerated]
  [SpecialName]
  public void SetUELayer(LayerParticipant layer) => this.ueLayer = layer;

  [CompilerGenerated]
  [SpecialName]
  public LayerParticipant GetApplicationLayer() => this.applicationLayer;

  [CompilerGenerated]
  [SpecialName]
  public void SetApplicationLayer(LayerParticipant layer) => this.applicationLayer = layer;

  [CompilerGenerated]
  [SpecialName]
  public LayerParticipant GetPresentationLayer() => this.presentationLayer;

  [CompilerGenerated]
  [SpecialName]
  public void SetPresentationLayer(LayerParticipant layer) => this.presentationLayer = layer;

  [CompilerGenerated]
  [SpecialName]
  public LayerParticipant GetSessionLayer() => this.sessionLayer;

  [CompilerGenerated]
  [SpecialName]
  public void SetSessionLayer(LayerParticipant layer) => this.sessionLayer = layer;

  [CompilerGenerated]
  [SpecialName]
  public LayerParticipant GetTransportLayer() => this.transport;

  [CompilerGenerated]
  [SpecialName]
  public void SetTransportLayer(LayerParticipant layer) => this.transport = layer;

  [CompilerGenerated]
  [SpecialName]
  public LayerParticipant GetNetworkLayer() => this.network;

  [CompilerGenerated]
  [SpecialName]
  public void SetNetworkLayer(LayerParticipant layer) => this.network = layer;

  [CompilerGenerated]
  [SpecialName]
  public al GetNetworkEmulator() => this.networkEmulator;

  [CompilerGenerated]
  [SpecialName]
  public void NetworkEmulator(al A_0) => this.networkEmulator = A_0;

  [CompilerGenerated]
  [SpecialName]
  public byte GetByte() => this.myByte;

  [CompilerGenerated]
  [SpecialName]
  public void SetByte(byte A_0) => this.myByte = A_0;

  [CompilerGenerated]
  [SpecialName]
  public string GetName() => this.name;

  [CompilerGenerated]
  [SpecialName]
  public void SetName(string name) => this.name = name;

  public Participant(string name, byte someByte, MainWindow mainWindow, EmulationRuntime an)
  {
    this.SetName(name);
    this.mainWindow = mainWindow;
    this.an = an;
    this.SetByte(someByte);
    this.NetworkEmulator(new al("NetworkEmulator"));
    this.SetNetworkLayer(new LayerParticipant("Network", this.mainWindow));
    this.SetTransportLayer(new LayerParticipant("Transport", this.mainWindow));
    this.SetSessionLayer(new LayerParticipant("Session", this.mainWindow));
    this.SetPresentationLayer(new LayerParticipant("Presentation", this.mainWindow));
    this.SetApplicationLayer(new LayerParticipant("Application", this.mainWindow));
    this.SetUELayer(new LayerParticipant("UE", this.mainWindow));
    this.SetProcessLayer(new LayerParticipant("Process", this.mainWindow));
  }

  public void d(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("sysdef +levels +events +code +fullcodeset +loadall +wantreturns\n"), 0, unicodeEncoding.GetByteCount("sysdef +levels +events +code +fullcodeset +loadall +wantreturns\n"));
    this.GetProcessLayer().g(A_0);
    this.GetUELayer().g(A_0);
    this.GetPresentationLayer().g(A_0);
    this.GetApplicationLayer().g(A_0);
    this.GetSessionLayer().g(A_0);
    this.GetTransportLayer().g(A_0);
    this.GetNetworkLayer().g(A_0);
    A_0.Write(unicodeEncoding.GetBytes("sysdef end\n"), 0, unicodeEncoding.GetByteCount("sysdef end\n"));
  }

  public void c(MemoryStream A_0)
  {
    if (SyntaxUtils.ReadLine(A_0) != "sysdef +levels +events +code +fullcodeset +loadall +wantreturns")
      throw new InvalidOperationException("Неверный формат файла");
    this.GetProcessLayer().c(A_0);
    this.GetUELayer().c(A_0);
    this.GetPresentationLayer().c(A_0);
    this.GetApplicationLayer().c(A_0);
    this.GetSessionLayer().c(A_0);
    this.GetTransportLayer().c(A_0);
    this.GetNetworkLayer().c(A_0);
    if (SyntaxUtils.ReadLine(A_0) != "sysdef end")
      throw new InvalidOperationException("Неверный формат файла");
  }

  public void b(MemoryStream A_0)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes("sysdef +CRC +Date +Time +staff\n"), 0, unicodeEncoding.GetByteCount("sysdef +CRC +Date +Time +staff\n"));
    this.GetProcessLayer().b(A_0);
    this.GetUELayer().b(A_0);
    this.GetPresentationLayer().b(A_0);
    this.GetApplicationLayer().b(A_0);
    this.GetSessionLayer().b(A_0);
    this.GetTransportLayer().b(A_0);
    this.GetNetworkLayer().b(A_0);
    A_0.Write(unicodeEncoding.GetBytes("sysdef end\n"), 0, unicodeEncoding.GetByteCount("sysdef end\n"));
  }

  public void a(MemoryStream A_0)
  {
    if (SyntaxUtils.ReadLine(A_0) != "sysdef +CRC +Date +Time +staff")
      throw new InvalidOperationException("Неверный формат файла");
    this.GetProcessLayer().a(A_0);
    this.GetUELayer().a(A_0);
    this.GetPresentationLayer().a(A_0);
    this.GetApplicationLayer().a(A_0);
    this.GetSessionLayer().a(A_0);
    this.GetTransportLayer().a(A_0);
    this.GetNetworkLayer().a(A_0);
    if (SyntaxUtils.ReadLine(A_0) != "sysdef end")
      throw new InvalidOperationException("Неверный формат файла");
  }

  public void Clear()
  {
    this.GetNetworkLayer().Clear();
    this.GetTransportLayer().Clear();
    this.GetSessionLayer().Clear();
    this.GetPresentationLayer().Clear();
    this.GetApplicationLayer().Clear();
    this.GetUELayer().Clear();
    this.GetProcessLayer().Clear();
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
        this.GetUELayer().a(A_1, A_2, this);
        break;
      case 7:
        switch (A_0[0])
        {
          case 'N':
            if (!(A_0 == "Network"))
              return;
            this.GetNetworkLayer().a(A_1, A_2, this);
            return;
          case 'P':
            if (!(A_0 == "Process"))
              return;
            this.GetProcessLayer().a(A_1, A_2, this);
            return;
          case 'S':
            if (!(A_0 == "Session"))
              return;
            this.GetSessionLayer().a(A_1, A_2, this);
            return;
          default:
            return;
        }
      case 9:
        if (!(A_0 == "Transport"))
          break;
        this.GetTransportLayer().a(A_1, A_2, this);
        break;
      case 11:
        if (!(A_0 == "Application"))
          break;
        this.GetApplicationLayer().a(A_1, A_2, this);
        break;
      case 12:
        if (!(A_0 == "Presentation"))
          break;
        this.GetPresentationLayer().a(A_1, A_2, this);
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
