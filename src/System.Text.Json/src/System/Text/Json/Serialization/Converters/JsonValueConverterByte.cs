﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Text.Json.Serialization.Converters
{
    internal sealed class JsonConverterByte : JsonConverter<byte>
    {
        public override byte Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.Number ||
                !reader.TryGetInt32(out int rawValue) ||
                !JsonHelpers.IsInRangeInclusive(rawValue, byte.MinValue, byte.MaxValue))
            {
                ThrowHelper.ThrowJsonException();
                return default;
            }

            return (byte)rawValue;
        }

        public override void Write(Utf8JsonWriter writer, byte value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }

        public override void Write(Utf8JsonWriter writer, byte value, JsonEncodedText propertyName, JsonSerializerOptions options)
        {
            writer.WriteNumber(propertyName, value);
        }
    }
}
