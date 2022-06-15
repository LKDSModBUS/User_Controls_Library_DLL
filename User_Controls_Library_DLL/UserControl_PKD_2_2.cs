using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DeviceManagerLKDS.Classes.Enums;

namespace DeviceManagerLKDS
{
    public partial class UserControl_PKD_2_2 : UserControl
    {
        public UserControl_PKD_2_2()
        {
            InitializeComponent();
        }
        public void SetData(byte[] array)
        {

            //string str =dlajskldj.GetNameOfEnum();

            if (array.Length >= 32)
            {
                CAN_Devices type = (CAN_Devices)array[1];
                Device_Status status = (Device_Status)array[0];
                Key_Format format = (Key_Format)array[15];
                if (type == CAN_Devices.ATU)
                {
                    device_status_tb.Text = status.GetNameOfEnum();
                    device_name_tb.Text = type.GetNameOfEnum();
                    key_format_tb.Text = format.GetNameOfEnum();

                    in_1_pb_sk.BackColor = ((array[3] & 0x01) != 0) ? Color.Green : Color.White;
                    in_2_pb_sk.BackColor = ((array[3] & 0x02) != 0) ? Color.Green : Color.White;
                    in_3_pb_sk.BackColor = ((array[3] & 0x04) != 0) ? Color.Green : Color.White;
                    in_4_pb_sk.BackColor = ((array[3] & 0x08) != 0) ? Color.Green : Color.White;
                    in_5_pb_sk.BackColor = ((array[3] & 0x10) != 0) ? Color.Green : Color.White;
                    in_6_pb_sk.BackColor = ((array[3] & 0x20) != 0) ? Color.Green : Color.White;
                 

                    in_1_pb_ts.BackColor = ((array[5] & 0x01) != 0) ? Color.Green : Color.White;
                    in_2_pb_ts.BackColor = ((array[5] & 0x02) != 0) ? Color.Green : Color.White;
                    in_3_pb_ts.BackColor = ((array[5] & 0x04) != 0) ? Color.Green : Color.White;
                    in_4_pb_ts.BackColor = ((array[5] & 0x08) != 0) ? Color.Green : Color.White;
                    in_5_pb_ts.BackColor = ((array[5] & 0x10) != 0) ? Color.Green : Color.White;
                    in_6_pb_ts.BackColor = ((array[5] & 0x20) != 0) ? Color.Green : Color.White;

                    out_pb1.BackColor = ((array[7] & 0x01) != 0) ? Color.Green : Color.White;
                    out_pb2.BackColor = ((array[7] & 0x02) != 0) ? Color.Green : Color.White;

                    software_version_tb.Text = $"{array[8]}.{array[9]}.{array[10]}";
                    key_number_tb.Text = $"{array[17].ToString("X2")} {array[18].ToString("X2")} {array[19].ToString("X2")} {array[20].ToString("X2")} {array[21].ToString("X2")} {array[22].ToString("X2")} {array[23].ToString("X2")} {array[24].ToString("X2")} {array[25].ToString("X2")} {array[26].ToString("X2")}";

                }
            }
        }
    }
}
