using System;
using System.Collections.Generic;
using System.Linq;
using Docfx2xml.Models.CustomXML.ElementTypes;
using Docfx2xml.Models.CustomXML.Enums;
using Docfx2xml.Models.CustomXML.Types;
using Attribute = Docfx2xml.Models.CustomXML.ElementTypes.Attribute;

namespace Docfx2xml.Models.CustomXML
{
  public static class XmlMapper
  {
    public static ClassInfo ToClassInfo(DataInfo data)
    {
      var baseInfo = data.Items.FirstOrDefault();
      var result = BuildBaseInfo<ClassInfo>(baseInfo);
      if (result != null)
      {
        var descriptions = data.Items.Skip(1).Select(ToDescription).ToList();
        result.Constructors = descriptions.Where(d => d.Type == InfoType.Constructor).ToList();
        result.Properties = descriptions.Where(d => d.Type == InfoType.Property).ToList();
        result.Fields = descriptions.Where(d => d.Type == InfoType.Field).ToList();
        result.Methods = descriptions.Where(d => d.Type == InfoType.Method).ToList();
      }
      return result;
    }

    public static EnumInfo ToEnumInfo(DataInfo data)
    {
      var baseInfo = data.Items.FirstOrDefault();
      var result = BuildBaseInfo<EnumInfo>(baseInfo);
      if (result != null)
      {
        var descriptions = data.Items.Skip(1).Select(ToDescription).ToList();
        result.Fields = descriptions.Where(d => d.Type == InfoType.Field).ToList();
      }
      return result;
    }

    public static InterfaceInfo ToInterfaceInfo(DataInfo data)
    {
      var baseInfo = data.Items.FirstOrDefault();
      var result = BuildBaseInfo<InterfaceInfo>(baseInfo);
      if (result != null)
      {
        var descriptions = data.Items.Skip(1).Select(ToDescription).ToList();
        result.Methods = descriptions.Where(d => d.Type == InfoType.Method).ToList();
        result.Properties = descriptions.Where(d => d.Type == InfoType.Property).ToList();
      }
      return result;
    }

    public static NamespaceInfo ToNamespaceInfo(DataInfo data) => 
      BuildBaseInfo<NamespaceInfo>(data.Items.FirstOrDefault());

    public static DelegateInfo ToDelegateInfo(DataInfo data) => 
      BuildBaseInfo<DelegateInfo>(data.Items.FirstOrDefault());

    public static StructInfo ToStructInfo(DataInfo data)
    {
      var baseInfo = data.Items.FirstOrDefault();
      var result = BuildBaseInfo<StructInfo>(baseInfo);
      if (result != null)
      {
        var descriptions = data.Items.Skip(1).Select(ToDescription).ToList();
        result.Constructors = descriptions.Where(d => d.Type == InfoType.Constructor).ToList();
        result.Properties = descriptions.Where(d => d.Type == InfoType.Property).ToList();
        result.Fields = descriptions.Where(d => d.Type == InfoType.Field).ToList();
        result.Methods = descriptions.Where(d => d.Type == InfoType.Method).ToList();
      }
      return result;
    }

    private static Description ToDescription(ItemInfo info) =>
      info == null ? default : new Description
      {
        Name = info.Name,
        NameWithType = info.NameWithType,
        FullName = info.FullName,
        Assembly = info.Assemblies?.FirstOrDefault(),
        Summary = info.Summary,
        Syntax = ConvertSyntax(info.Syntax),
        Source = ConvertSource(info.Source),
        Type = ParseInfoType(info.Type),
        Parameters = info.Syntax.Parameters?.Select(ConvertParameter).ToList() ?? new List<Parameter>(),
        Remarks = string.IsNullOrEmpty(info.CommentId) ? new List<string>() : new List<string>{info.CommentId},
        Examples = info.Example,
        Modifiers = info.ModifiersCSharp
      };

    private static Source ConvertSource(SourceInfo info) =>
      info == null ? default : new Source
      {
        Name = info.Id,
        FilePath = info.Path,
        Branch = info.Branch,
        Repo = info.Repo,
        StartLine = info.StartLine,
        EndLine = info.EndLine
      };

    private static Syntax ConvertSyntax(SyntaxInfo info) =>
      info == null ? default : new Syntax
      {
        Content = info.Content,
        Parameters = info.Parameters?.Select(ConvertParameter).ToList() ?? new List<Parameter>(),
        Return = ConvertReturn(info.Return)
      };

    private static Return ConvertReturn(ReturnInfo info) =>
      info == null ? default : new Return
      {
        Description = info.Description,
        Type = info.Type
      };

    private static Parameter ConvertParameter(ParameterInfo info) =>
      info == null ? default : new Parameter
      {
        Name = info.Id,
        Description = info.Description,
        Type = info.Type,
        Attributes = info.Attributes?.Select(ConvertAttribute).ToList() ?? new List<Attribute>()
      };

    private static Attribute ConvertAttribute(AttributeInfo info) =>
      info == null ? default : new Attribute
      {
        Type = info.Type,
        Constructor = info.Ctor,
        Arguments = info.Arguments?.Select(ConvertArgument).ToList() ?? new List<Argument>(),
        NamedArguments = info.NamedArguments?.Select(ConvertArgument).ToList() ?? new List<Argument>()
      };

    private static Argument ConvertArgument(ArgumentInfo info) =>
      info == null ? default : new Argument
      {
        Type = info.Type,
        Value = info.Value
      };

    private static InfoType ParseInfoType(string dataType) =>
      Enum.TryParse(dataType, true, out InfoType parseResult) 
        ? parseResult 
        : throw new ArgumentException($"Unable to parse :{dataType}",nameof(dataType));

    private static T BuildBaseInfo<T>(ItemInfo baseInfo) where T : BaseInfo, new() =>
      baseInfo == null ? default : new T
      {
        Name = baseInfo.UId,
        NameWithType = baseInfo.NameWithType,
        FullName = baseInfo.FullName,
        Languages = baseInfo.Langs,
        Namespace = baseInfo.Namespace,
        Comment = baseInfo.CommentId,
        Syntax = ConvertSyntax(baseInfo.Syntax),
        Assemblies = baseInfo.Assemblies,
        Inheritance = baseInfo.Inheritance,
        InheritedMembers = baseInfo.Inheritance,
        Summary = baseInfo.Summary
      };
  }
}