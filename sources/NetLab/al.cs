// Decompiled with JetBrains decompiler
// Type: al
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System.Collections;
using System.Runtime.CompilerServices;

#nullable disable
public class al
{
  private byte[] l;
  private byte[] m;
  private Queue n;

  [CompilerGenerated]
  [SpecialName]
  public string k() => this.a;

  [CompilerGenerated]
  [SpecialName]
  public void a(string A_0) => this.a = A_0;

  [CompilerGenerated]
  [SpecialName]
  public int j() => this.b;

  [CompilerGenerated]
  [SpecialName]
  public void a(int A_0) => this.b = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ae i() => this.c;

  [CompilerGenerated]
  [SpecialName]
  public void d(ae A_0) => this.c = A_0;

  [CompilerGenerated]
  [SpecialName]
  public double h() => this.d;

  [CompilerGenerated]
  [SpecialName]
  public void e(double A_0) => this.d = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ae g() => this.e;

  [CompilerGenerated]
  [SpecialName]
  public void c(ae A_0) => this.e = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ae f() => this.f;

  [CompilerGenerated]
  [SpecialName]
  public void b(ae A_0) => this.f = A_0;

  [CompilerGenerated]
  [SpecialName]
  public double e() => this.g;

  [CompilerGenerated]
  [SpecialName]
  public void d(double A_0) => this.g = A_0;

  [CompilerGenerated]
  [SpecialName]
  public double d() => this.h;

  [CompilerGenerated]
  [SpecialName]
  public void c(double A_0) => this.h = A_0;

  [CompilerGenerated]
  [SpecialName]
  public double c() => this.i;

  [CompilerGenerated]
  [SpecialName]
  public void b(double A_0) => this.i = A_0;

  [CompilerGenerated]
  [SpecialName]
  public ae b() => this.j;

  [CompilerGenerated]
  [SpecialName]
  public void a(ae A_0) => this.j = A_0;

  [CompilerGenerated]
  [SpecialName]
  public double a() => this.k;

  [CompilerGenerated]
  [SpecialName]
  public void a(double A_0) => this.k = A_0;

  public al(string A_0)
  {
    this.a(A_0);
    this.a(1024);
    this.d(new ae(256, 64));
    this.e(0.1);
    this.c(new ae(128, 10));
    this.b(new ae(64, 16));
    this.d(0.25);
    this.c(0.05);
    this.b(0.002);
    this.a(new ae(128, 64));
    this.a(0.05);
    this.l = new byte[3];
    this.m = new byte[3];
    this.n = new Queue();
  }

  public void a(string A_0, SortedList A_1, Participant A_2)
  {
    if (!(A_0 == "N_INIT.REQ"))
      return;
    this.l = new byte[3];
    this.m = new byte[3];
    this.n.Clear();
    A_2.GetNetworkLayer().e.Add((object) "MaxPacketSize", (object) new af("MaxPacketSize", (object) this.j(), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "ConnectDelayBase", (object) new af("ConnectDelayBase", (object) (this.i().c() - 3), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "ConnectDelayDispersion", (object) new af("ConnectDelayDispersion", (object) this.i().b(), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "ConnectErrorProbability", (object) new af("ConnectErrorProbability", (object) (int) (this.h() * 10000.0), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "TransferRateBase", (object) new af("TransferRateBase", (object) this.g().c(), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "TransferRateDispersion", (object) new af("TransferRateDispersion", (object) this.g().b(), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "TransferDelayBase", (object) new af("TransferDelayBase", (object) (this.f().c() - 3), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "TransferDelayDispersion", (object) new af("TransferDelayDispersion", (object) this.f().b(), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "TransferErrorProbability", (object) new af("TransferErrorProbability", (object) (int) (this.e() * 10000.0), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "PacketLoseProbability", (object) new af("PacketLoseProbability", (object) (int) (this.d() * 10000.0), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "DisconnectProbability", (object) new af("DisconnectProbability", (object) (int) (this.c() * 10000.0), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "DisconnectDelayBase", (object) new af("DisconnectDelayBase", (object) (this.b().c() - 3), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "DisconnectDelayDispersion", (object) new af("DisconnectDelayDispersion", (object) this.b().b(), ac.a));
    A_2.GetNetworkLayer().e.Add((object) "DuplicateProbability", (object) new af("DuplicateProbability", (object) (int) (this.a() * 10000.0), ac.a));
    A_2.b("Network", "N_INIT.REQ", (SortedList) null);
    A_2.b("Transport", "T_INIT.REQ", (SortedList) null);
    A_2.b("Session", "S_INIT.REQ", (SortedList) null);
    A_2.b("Presentation", "P_INIT.REQ", (SortedList) null);
    A_2.b("Application", "A_INIT.REQ", (SortedList) null);
    A_2.b("UE", "UE_INIT.REQ", (SortedList) null);
    A_2.b("Process", "AP_INIT.REQ", (SortedList) null);
  }
}
