#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
/**
 * Autogenerated by Thrift Compiler ()
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;


#if !SILVERLIGHT
[Serializable]
#endif
public partial class TrackLatencyRequest : TBase
{
  private string _sessionId;
  private string _rpc;
  private long _latency;
  private long _connectionLatency;

  /// <summary>
  /// id of the session
  /// </summary>
  public string SessionId
  {
    get
    {
      return _sessionId;
    }
    set
    {
      __isset.sessionId = true;
      this._sessionId = value;
    }
  }

  /// <summary>
  /// name of the rpc that was measured
  /// </summary>
  public string Rpc
  {
    get
    {
      return _rpc;
    }
    set
    {
      __isset.rpc = true;
      this._rpc = value;
    }
  }

  /// <summary>
  /// latency in ms of the RPC call (exclusive connection time)
  /// </summary>
  public long Latency
  {
    get
    {
      return _latency;
    }
    set
    {
      __isset.latency = true;
      this._latency = value;
    }
  }

  /// <summary>
  /// latency in ms of the connection time
  /// </summary>
  public long ConnectionLatency
  {
    get
    {
      return _connectionLatency;
    }
    set
    {
      __isset.connectionLatency = true;
      this._connectionLatency = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool sessionId;
    public bool rpc;
    public bool latency;
    public bool connectionLatency;
  }

  public TrackLatencyRequest() {
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              SessionId = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Rpc = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              Latency = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.I64) {
              ConnectionLatency = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public void Write(TProtocol oprot) {
    oprot.IncrementRecursionDepth();
    try
    {
      TStruct struc = new TStruct("TrackLatencyRequest");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (SessionId != null && __isset.sessionId) {
        field.Name = "sessionId";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(SessionId);
        oprot.WriteFieldEnd();
      }
      if (Rpc != null && __isset.rpc) {
        field.Name = "rpc";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Rpc);
        oprot.WriteFieldEnd();
      }
      if (__isset.latency) {
        field.Name = "latency";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Latency);
        oprot.WriteFieldEnd();
      }
      if (__isset.connectionLatency) {
        field.Name = "connectionLatency";
        field.Type = TType.I64;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(ConnectionLatency);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("TrackLatencyRequest(");
    bool __first = true;
    if (SessionId != null && __isset.sessionId) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("SessionId: ");
      __sb.Append(SessionId);
    }
    if (Rpc != null && __isset.rpc) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Rpc: ");
      __sb.Append(Rpc);
    }
    if (__isset.latency) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Latency: ");
      __sb.Append(Latency);
    }
    if (__isset.connectionLatency) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ConnectionLatency: ");
      __sb.Append(ConnectionLatency);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}
#endif