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
public partial class THActivityPostContent : TBase
{
  private string _text;
  private string _imageUrl;
  private string _buttonTitle;
  private string _buttonAction;
  private string _language;
  private string _videoUrl;
  private THAction _action;

  public string Text
  {
    get
    {
      return _text;
    }
    set
    {
      __isset.text = true;
      this._text = value;
    }
  }

  public string ImageUrl
  {
    get
    {
      return _imageUrl;
    }
    set
    {
      __isset.imageUrl = true;
      this._imageUrl = value;
    }
  }

  public string ButtonTitle
  {
    get
    {
      return _buttonTitle;
    }
    set
    {
      __isset.buttonTitle = true;
      this._buttonTitle = value;
    }
  }

  public string ButtonAction
  {
    get
    {
      return _buttonAction;
    }
    set
    {
      __isset.buttonAction = true;
      this._buttonAction = value;
    }
  }

  public string Language
  {
    get
    {
      return _language;
    }
    set
    {
      __isset.language = true;
      this._language = value;
    }
  }

  public string VideoUrl
  {
    get
    {
      return _videoUrl;
    }
    set
    {
      __isset.videoUrl = true;
      this._videoUrl = value;
    }
  }

  public THAction Action
  {
    get
    {
      return _action;
    }
    set
    {
      __isset.action = true;
      this._action = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool text;
    public bool imageUrl;
    public bool buttonTitle;
    public bool buttonAction;
    public bool language;
    public bool videoUrl;
    public bool action;
  }

  public THActivityPostContent() {
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
              Text = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              ImageUrl = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              ButtonTitle = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              ButtonAction = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              Language = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              VideoUrl = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.Struct) {
              Action = new THAction();
              Action.Read(iprot);
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
      TStruct struc = new TStruct("THActivityPostContent");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Text != null && __isset.text) {
        field.Name = "text";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Text);
        oprot.WriteFieldEnd();
      }
      if (ImageUrl != null && __isset.imageUrl) {
        field.Name = "imageUrl";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ImageUrl);
        oprot.WriteFieldEnd();
      }
      if (ButtonTitle != null && __isset.buttonTitle) {
        field.Name = "buttonTitle";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ButtonTitle);
        oprot.WriteFieldEnd();
      }
      if (ButtonAction != null && __isset.buttonAction) {
        field.Name = "buttonAction";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ButtonAction);
        oprot.WriteFieldEnd();
      }
      if (Language != null && __isset.language) {
        field.Name = "language";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Language);
        oprot.WriteFieldEnd();
      }
      if (VideoUrl != null && __isset.videoUrl) {
        field.Name = "videoUrl";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(VideoUrl);
        oprot.WriteFieldEnd();
      }
      if (Action != null && __isset.action) {
        field.Name = "action";
        field.Type = TType.Struct;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        Action.Write(oprot);
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
    StringBuilder __sb = new StringBuilder("THActivityPostContent(");
    bool __first = true;
    if (Text != null && __isset.text) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Text: ");
      __sb.Append(Text);
    }
    if (ImageUrl != null && __isset.imageUrl) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ImageUrl: ");
      __sb.Append(ImageUrl);
    }
    if (ButtonTitle != null && __isset.buttonTitle) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ButtonTitle: ");
      __sb.Append(ButtonTitle);
    }
    if (ButtonAction != null && __isset.buttonAction) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ButtonAction: ");
      __sb.Append(ButtonAction);
    }
    if (Language != null && __isset.language) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Language: ");
      __sb.Append(Language);
    }
    if (VideoUrl != null && __isset.videoUrl) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("VideoUrl: ");
      __sb.Append(VideoUrl);
    }
    if (Action != null && __isset.action) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Action: ");
      __sb.Append(Action== null ? "<null>" : Action.ToString());
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}
#endif
