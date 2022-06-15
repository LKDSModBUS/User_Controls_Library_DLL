using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DeviceManagerLKDS.Classes
{
    public static class Enums
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Union16
        {
            [FieldOffset(0)]
            public Int16 Value;
            [NonSerialized]
            [FieldOffset(0)]
            public UInt16 UValue;
            [FieldOffset(0)]
            public byte Byte0;
            [FieldOffset(1)]
            public byte Byte1;
            public bool isBitSet(byte index)
            {
                if (index >= 15)
                    return false;
                return (Value & (1L << index)) != 0;
            }
            [System.Xml.Serialization.XmlIgnore]
            public byte[] ToArray => new byte[]
            {
            Byte0,
            Byte1
            };
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Union32
        {
            [FieldOffset(0)]
            public Int32 Value;
            [NonSerialized]
            [FieldOffset(0)]
            public UInt32 UValue;
            [FieldOffset(0)]
            public byte Byte0;
            [FieldOffset(1)]
            public byte Byte1;
            [FieldOffset(2)]
            public byte Byte2;
            [FieldOffset(3)]
            public byte Byte3;
            public bool isBitSet(byte index)
            {
                if (index >= 31)
                    return false;
                return (Value & (1L << index)) != 0;
            }
            [System.Xml.Serialization.XmlIgnore]
            public byte[] ToArray => new byte[]
            {
            Byte0,
            Byte1,
            Byte2,
            Byte3
            };
        }

        public static string GetNameOfEnum(this Enum enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            try
            {
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? ((DescriptionAttribute)attributes[0]).Description : "";
            }
            catch
            {
                return Convert.ToInt16(enumVal).ToString("X4");
            }

        }

        public enum Device_Status
        {
            [Description("Инициализация-нет данных")]
            ninitialization = 0,
            [Description("Ожидание готовности устройства-нет жанных")]
            nwaiting_readiness = 1,
            [Description("Ожидание данных устройства-нет данных")]
            waiting_data = 2,
            [Description("Данные устарели-не обновлялись более 30 сек")]
            data_outdated = 3,
            [Description("Данные актуальны-подлежат интерпретации")]
            data_actual = 4,
            [Description("Обнаружен рестарт устройства-нет данных")]
            restart = 5,
        }

        public enum Key_Format
        {
            [Description("Неизвестный формат ключа")]
            unknown_format = 0x00,
            [Description("Формат ключа Dallas")]
            dallas = 0x01,
            [Description("EM-Marine")]
            em_marine = 0x02,
            [Description("EM-Marine (ручной ввод)")]
            em_marine_manual_input = 0x03,
            [Description("Mifare Classic")]
            mifare_classic = 0x04,
            [Description("Mifare Classic (ручной ввод)")]
            mifare_classic_manual_input = 0x05,
            [Description("Mifare 1K")]
            mifare_1K = 0x06,
            [Description("Mifare 1K (ручной ввод)")]
            mifare_1K_manual_input = 0x07,
            [Description("Mifare 4K")]
            mifare_4K = 0x08,
            [Description("Mifare 4K (ручной ввод)")]
            mifare_4K_manual_input = 0x09,
            [Description("Mifare UltraLight")]
            mifare_ultra_light = 0x0A,
            [Description("Mifare UltraLight (ручной ввод)")]
            mifare_ultra_light_manual_input = 0x0B,
            [Description("HID ProxCard II")]
            HID_Prox_Card_II = 0x0C,
            [Description("HID ProxCard II (ручной ввод)")]
            HID_Prox_Card_II_manual_input = 0x0D,
            [Description("клавиатура")]
            keyboard = 0x0E,
            [Description("RF-433тип 1")]
            rf = 0x0F,
            [Description("Wiegand - абстрактный ключ, полученный в формате Wiegand")]
            wiegand = 0x10,
            [Description("кнопка (открывания)")]
            opening_button = 0x11,
        }
        public enum AdressTest
        {
             [Description("0x12 0x00")] Adres32 = 0x00,
             [Description("0x12 0x10")] Adres33 = 0x01,
             [Description("0x12 0x20")] Adres34 = 0x02,
             [Description("0x12 0x30")] Adres35 = 0x03,
             [Description("0x12 0x40")] Adres36 = 0x04,
             [Description("0x12 0x50")] Adres37 = 0x05,
             [Description("0x12 0x60")] Adres38 = 0x06,
             [Description("0x12 0x70")] Adres39 = 0x07,
             [Description("0x12 0x80")] Adres40 = 0x08,
             [Description("0x12 0x90")] Adres41 = 0x09,
             [Description("0x12 0xA0")] Adres42 = 0x0A,
             [Description("0x12 0xB0")] Adres43 = 0x0B,
             [Description("0x12 0xC0")] Adres44 = 0x0C,
             [Description("0x12 0xD0")] Adres45 = 0x0D,
             [Description("0x12 0xE0")] Adres46 = 0x0E,
             [Description("0x12 0xF0")] Adres47 = 0x0F,
             [Description("0x13 0x00")] Adres48 = 0x10,
             [Description("0x13 0x10")] Adres49 = 0x11,
             [Description("0x13 0x20")] Adres50 = 0x12,
             [Description("0x13 0x30")] Adres51 = 0x13,
             [Description("0x13 0x40")] Adres52 = 0x14,
             [Description("0x13 0x50")] Adres53 = 0x15,
             [Description("0x13 0x60")] Adres54 = 0x16,
             [Description("0x13 0x70")] Adres55 = 0x17,
             [Description("0x13 0x80")] Adres56 = 0x18,
             [Description("0x13 0x90")] Adres57 = 0x19,
             [Description("0x13 0xA0")] Adres58 = 0x1A,
             [Description("0x13 0xB0")] Adres59 = 0x1B,
             [Description("0x13 0xC0")] Adres60 = 0x1C,
             [Description("0x13 0xD0")] Adres61 = 0x1D,
             [Description("0x13 0xE0")] Adres62 = 0x1E,
             [Description("0x13 0xF0")] Adres63 = 0x1F

        }
        public enum CAN_Devices
        {
            [Description("ЛБ/Концентратор")]
            LB = 0,
            [Description("USB - VOICE converter")]
            USB = 2,
            [Description("VRP - VIDEO converter")]
            VRP = 3,
            [Description("Переговорное устройство v7(ПУv7)")]
            PU = 4,
            [Description("Переговорное устройство этажное v7(ЭПУv7)")]
            EPU = 5,
            [Description("Удлинитель WiFi v7")]
            wifi = 6,
            [Description("Адаптер входов v7(АСК-16)")]
            ASK = 7,
            [Description("Адаптер ТУ v7(АТУ-8*2)")]
            ATU = 8,
            [Description("Адаптер ПУ v7(АПУ-1)")]
            APU = 9,
            [Description("Адаптер Последовательного Интерфейса(АПИ-1)")]
            API = 10,
            [Description("Портал Контроллер Доступа (ПКД2*2)")]
            PKD22 = 11,
            [Description("Портал Контроллер Доступа (ПКД2*16)")]
            PKD216 = 12,
            [Description("Переговорное устр. Аккум. платформы (ПУ АП)")]
            PUAP = 13,
            [Description("Адаптер релейных выходов (АРВ-8*6)")]
            ARV = 14,
            [Description("Адаптер Лампа Индикаторная (АЛИ-1)")]
            ALI = 15,
            [Description("Адаптер Токовых Сигналов (АТС-4*4)")]
            ATS = 16,
            [Description("Адаптер ModBUS (АМБ-1)")]
            AMB = 17,
            [Description("Адаптер Звукового Оповещения (АЗО-1)")]
            AZO = 18,
            [Description("Адаптер Переговорного Устройства 2 (АПУ-2)")]
            APU2 = 19,
            [Description("Переговорное устройство посадоч. площ.(ПУ ПП)")]
            PUPP = 20,
            [Description("Выносной Модуль Управления (ВМУ)")]
            VMU = 21,
            [Description("Адаптер шлейфов (АШЛ-6*4)")]
            ASHL = 22,
            [Description("Портал Контроллер Доступа (ПКД1*2)")]
            PKD12 = 24,
            [Description("ПКД2*2-режим Команд")]
            PKD22CR = 26,
            [Description("ПКД2*16-режим Команд")]
            PKD216CR = 27,
            [Description("ПКД2*1-режим Команд")]
            PKD21CR = 28,
            [Description("Тип не определен")]
            notype = 255,
        }
    }
}
