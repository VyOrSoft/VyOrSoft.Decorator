using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace VyOrSoft.Decorator
{
    internal class DecoratedType : Type
    {
        public readonly Type _innerType;
        public DecoratedType(Type innerType, int id)
        {
            _innerType = innerType;
            IdDec = id;
        }

        public int IdDec { get; }

        public override bool IsConstructedGenericType => _innerType.IsConstructedGenericType;
        public override bool ContainsGenericParameters => _innerType.ContainsGenericParameters;
        public override IEnumerable<CustomAttributeData> CustomAttributes => _innerType.CustomAttributes;
        public override MethodBase? DeclaringMethod => _innerType.DeclaringMethod;
        public override Type? DeclaringType => _innerType.DeclaringType;
        public override bool Equals(object? o)
        {
            var typesEqulas = _innerType.Equals(o);
            if (o is not DecoratedType decoratedType)
            {
                return typesEqulas;
            }
            var ee = _innerType.Equals(decoratedType._innerType);
            return decoratedType.IdDec == this.IdDec && ee;
        }
        public override bool Equals(Type? o) => _innerType.Equals(o);
        public override Type[] FindInterfaces(TypeFilter filter, object? filterCriteria)
            => _innerType.FindInterfaces(filter, filterCriteria);
        public override MemberInfo[] FindMembers(MemberTypes memberType, BindingFlags bindingAttr, MemberFilter? filter, object? filterCriteria)
            => _innerType.FindMembers(memberType, bindingAttr, filter, filterCriteria);
        public override GenericParameterAttributes GenericParameterAttributes => _innerType.GenericParameterAttributes;
        public override int GenericParameterPosition => _innerType.GenericParameterPosition;
        public override Type[] GenericTypeArguments => _innerType.GenericTypeArguments;
        public override int GetArrayRank() => _innerType.GetArrayRank();
        public override IList<CustomAttributeData> GetCustomAttributesData() => _innerType.GetCustomAttributesData();
        public override MemberInfo[] GetDefaultMembers() => _innerType.GetDefaultMembers();
        public override string? GetEnumName(object value) => _innerType.GetEnumName(value);
        public override string[] GetEnumNames() => _innerType.GetEnumNames();
        public override Type GetEnumUnderlyingType() => _innerType.GetEnumUnderlyingType();
        public override Array GetEnumValues() => _innerType.GetEnumValues();
        public override Array GetEnumValuesAsUnderlyingType() => _innerType.GetEnumValuesAsUnderlyingType();
        public override EventInfo[] GetEvents() => _innerType.GetEvents();
        public override Type[] GetGenericArguments() => _innerType.GetGenericArguments();
        public override Type[] GetGenericParameterConstraints() => _innerType.GetGenericParameterConstraints();
        public override Type GetGenericTypeDefinition() => _innerType.GetGenericTypeDefinition();
        public override int GetHashCode() { 
            var hashCode = _innerType.GetHashCode();
            return this.IdDec + hashCode; 
        }
        public override InterfaceMapping GetInterfaceMap([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] Type interfaceType)
            => _innerType.GetInterfaceMap(interfaceType);
        public override MemberInfo[] GetMember(string name, BindingFlags bindingAttr) => _innerType.GetMember(name, bindingAttr);
        public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr) => _innerType.GetMember(name, type, bindingAttr);
        public override MemberInfo GetMemberWithSameMetadataDefinitionAs(MemberInfo member) => _innerType.GetMemberWithSameMetadataDefinitionAs(member);
        protected override MethodInfo? GetMethodImpl(string name, int genericParameterCount, BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[]? types, ParameterModifier[]? modifiers)
            => _innerType.GetMethod(name, genericParameterCount, bindingAttr, binder, callConvention, types, modifiers);
        //protected override TypeCode GetTypeCodeImpl() => _innerType.GetTypeCode(UnderlyingSystemType);
        public override bool HasSameMetadataDefinitionAs(MemberInfo other) => _innerType.HasSameMetadataDefinitionAs(other);
        public override bool IsAssignableFrom([NotNullWhen(true)] Type? c) => _innerType.IsAssignableFrom(c);
        public override bool IsByRefLike => _innerType.IsByRefLike;
        public override bool IsCollectible => _innerType.IsCollectible;
        protected override bool IsContextfulImpl() => _innerType.IsContextful;
        public override bool IsEnum => _innerType.IsEnum;
        public override bool IsEnumDefined(object value) => _innerType.IsEnumDefined(value);
        public override bool IsEquivalentTo([NotNullWhen(true)] Type? other) => _innerType.IsEquivalentTo(other);
        public override bool IsGenericMethodParameter => _innerType.IsGenericMethodParameter;
        public override bool IsGenericParameter => _innerType.IsGenericParameter;
        public override bool IsGenericType => _innerType.IsGenericType;
        public override bool IsGenericTypeDefinition => _innerType.IsGenericTypeDefinition;
        public override bool IsGenericTypeParameter => _innerType.IsGenericTypeParameter;
        public override bool IsInstanceOfType([NotNullWhen(true)] object? o) => _innerType.IsInstanceOfType(o);
        protected override bool IsMarshalByRefImpl() => _innerType.IsMarshalByRef;
        public override bool IsSecurityCritical => _innerType.IsSecurityCritical;
        public override bool IsSecuritySafeCritical => _innerType.IsSecuritySafeCritical;
        public override bool IsSecurityTransparent => _innerType.IsSecurityTransparent;
        public override bool IsSerializable => _innerType.IsSerializable;
        public override bool IsSignatureType => _innerType.IsSignatureType;
        public override bool IsSubclassOf(Type c) => _innerType.IsSubclassOf(c);
        public override bool IsSZArray => _innerType.IsSZArray;
        public override bool IsTypeDefinition => _innerType.IsTypeDefinition;
        protected override bool IsValueTypeImpl() => _innerType.IsValueType;
        public override bool IsVariableBoundArray => _innerType.IsVariableBoundArray;
        public override Type MakeArrayType() => _innerType.MakeArrayType();
        public override Type MakeArrayType(int rank) => _innerType.MakeArrayType(rank);
        public override Type MakeByRefType() => _innerType.MakeByRefType();
        public override Type MakeGenericType(params Type[] typeArguments) => _innerType.MakeGenericType(typeArguments);
        public override Type MakePointerType() => _innerType.MakePointerType();
        public override MemberTypes MemberType => _innerType.MemberType;
        public override int MetadataToken => _innerType.MetadataToken;
        public override Module Module => _innerType.Module;
        public override Type? ReflectedType => _innerType.ReflectedType;
        public override StructLayoutAttribute? StructLayoutAttribute => _innerType.StructLayoutAttribute;
        public override string ToString() => _innerType.ToString();
        public override RuntimeTypeHandle TypeHandle => _innerType.TypeHandle;
        public override Assembly Assembly => _innerType.Assembly;

        public override string? AssemblyQualifiedName => _innerType.AssemblyQualifiedName;

        public override Type? BaseType => _innerType.BaseType;

        public override string? FullName => _innerType.FullName;

        public override Guid GUID => _innerType.GUID;

        public override string? Namespace => _innerType.Namespace;

        public override Type UnderlyingSystemType => _innerType.UnderlyingSystemType;

        public override string Name => _innerType.Name;

        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
            => _innerType.GetConstructors(bindingAttr);

        public override object[] GetCustomAttributes(bool inherit)
            => _innerType.GetCustomAttributes(inherit);

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            => _innerType.GetCustomAttributes(attributeType, inherit);

        public override Type? GetElementType()
            => _innerType.GetElementType();

        public override EventInfo? GetEvent(string name, BindingFlags bindingAttr)
            => _innerType.GetEvent(name, bindingAttr);

        public override EventInfo[] GetEvents(BindingFlags bindingAttr)
           => _innerType.GetEvents(bindingAttr);

        public override FieldInfo? GetField(string name, BindingFlags bindingAttr)
           => _innerType.GetField(name, bindingAttr);

        public override FieldInfo[] GetFields(BindingFlags bindingAttr)
           => _innerType.GetFields(bindingAttr);

        [return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
        public override Type? GetInterface(string name, bool ignoreCase)
           => _innerType.GetInterface(name, ignoreCase);

        public override Type[] GetInterfaces()
           => _innerType.GetInterfaces();

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
           => _innerType.GetMembers(bindingAttr);

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
           => _innerType.GetMethods(bindingAttr);

        public override Type? GetNestedType(string name, BindingFlags bindingAttr)
           => _innerType.GetNestedType(name, bindingAttr);

        public override Type[] GetNestedTypes(BindingFlags bindingAttr)
           => _innerType.GetNestedTypes(bindingAttr);

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
           => _innerType.GetProperties(bindingAttr);

        public override object? InvokeMember(string name, BindingFlags invokeAttr, Binder? binder, object? target, object?[]? args, ParameterModifier[]? modifiers, CultureInfo? culture, string[]? namedParameters)
           => _innerType.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);

        public override bool IsDefined(Type attributeType, bool inherit)
           => _innerType.IsDefined(attributeType, inherit);

        protected override TypeAttributes GetAttributeFlagsImpl()
           => _innerType.Attributes;

        protected override ConstructorInfo? GetConstructorImpl(BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[] types, ParameterModifier[]? modifiers)
           => _innerType.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);

        protected override MethodInfo? GetMethodImpl(string name, BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[]? types, ParameterModifier[]? modifiers)
           => _innerType.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);

        protected override PropertyInfo? GetPropertyImpl(string name, BindingFlags bindingAttr, Binder? binder, Type? returnType, Type[]? types, ParameterModifier[]? modifiers)
           => _innerType.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);

        protected override bool HasElementTypeImpl()
           => _innerType.HasElementType;

        protected override bool IsArrayImpl()
           => _innerType.IsArray;

        protected override bool IsByRefImpl()
           => _innerType.IsByRef;

        protected override bool IsCOMObjectImpl()
           => _innerType.IsCOMObject;

        protected override bool IsPointerImpl()
            => _innerType.IsPointer;

        protected override bool IsPrimitiveImpl()
             => _innerType.IsPrimitive;
    }

}
