using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DeviceManagerLKDS.Classes.Enums;

namespace DeviceManagerLKDS
{
    public partial class UserControl_ASK : UserControl
    {
        public UserControl_ASK()
        {
            InitializeComponent();
        }
        public void SetData(byte[] array)
        {

            //string str =dlajskldj.GetNameOfEnum();

            if (array.Length>=32)
            {
                CAN_Devices type = (CAN_Devices)array[1];
                Device_Status status = (Device_Status)array[0];
                if(type == CAN_Devices.ASK)
                {
                    device_status_tb.Text = status.GetNameOfEnum();
                    device_name_tb.Text = type.GetNameOfEnum();

                    in_1_pb_sk.BackColor = ((array[3] & 0x01) != 0) ? Color.Green : Color.White;
                    in_2_pb_sk.BackColor = ((array[3] & 0x02) != 0) ? Color.Green : Color.White;
                    in_3_pb_sk.BackColor = ((array[3] & 0x04) != 0) ? Color.Green : Color.White;
                    in_4_pb_sk.BackColor = ((array[3] & 0x08) != 0) ? Color.Green : Color.White;
                    in_5_pb_sk.BackColor = ((array[3] & 0x10) != 0) ? Color.Green : Color.White;
                    in_6_pb_sk.BackColor = ((array[3] & 0x20) != 0) ? Color.Green : Color.White;
                    in_7_pb_sk.BackColor = ((array[3] & 0x40) != 0) ? Color.Green : Color.White;
                    in_8_pb_sk.BackColor = ((array[3] & 0x80) != 0) ? Color.Green : Color.White;
                    in_9_pb_sk.BackColor = ((array[2] & 0x01) != 0) ? Color.Green : Color.White;
                    in_10_pb_sk.BackColor = ((array[2] & 0x02) != 0) ? Color.Green : Color.White;
                    in_11_pb_sk.BackColor = ((array[2] & 0x04) != 0) ? Color.Green : Color.White;
                    in_12_pb_sk.BackColor = ((array[2] & 0x08) != 0) ? Color.Green : Color.White;
                    in_13_pb_sk.BackColor = ((array[2] & 0x10) != 0) ? Color.Green : Color.White;
                    in_14_pb_sk.BackColor = ((array[2] & 0x20) != 0) ? Color.Green : Color.White;
                    in_15_pb_sk.BackColor = ((array[2] & 0x40) != 0) ? Color.Green : Color.White;
                    in_16_pb_sk.BackColor = ((array[2] & 0x80) != 0) ? Color.Green : Color.White;

                    in_1_pb_ts.BackColor = ((array[5] & 0x01) != 0) ? Color.Green : Color.White;
                    in_2_pb_ts.BackColor = ((array[5] & 0x02) != 0) ? Color.Green : Color.White;
                    in_3_pb_ts.BackColor = ((array[5] & 0x04) != 0) ? Color.Green : Color.White;
                    in_4_pb_ts.BackColor = ((array[5] & 0x08) != 0) ? Color.Green : Color.White;
                    in_5_pb_ts.BackColor = ((array[5] & 0x10) != 0) ? Color.Green : Color.White;
                    in_6_pb_ts.BackColor = ((array[5] & 0x20) != 0) ? Color.Green : Color.White;
                    in_7_pb_ts.BackColor = ((array[5] & 0x40) != 0) ? Color.Green : Color.White;
                    in_8_pb_ts.BackColor = ((array[5] & 0x80) != 0) ? Color.Green : Color.White;
                    in_9_pb_ts.BackColor = ((array[4] & 0x01) != 0) ? Color.Green : Color.White;
                    in_10_pb_ts.BackColor = ((array[4] & 0x02) != 0) ? Color.Green : Color.White;
                    in_11_pb_ts.BackColor = ((array[4] & 0x04) != 0) ? Color.Green : Color.White;
                    in_12_pb_ts.BackColor = ((array[4] & 0x08) != 0) ? Color.Green : Color.White;
                    in_13_pb_ts.BackColor = ((array[4] & 0x10) != 0) ? Color.Green : Color.White;
                    in_14_pb_ts.BackColor = ((array[4] & 0x20) != 0) ? Color.Green : Color.White;
                    in_15_pb_ts.BackColor = ((array[4] & 0x40) != 0) ? Color.Green : Color.White;
                    in_16_pb_ts.BackColor = ((array[4] & 0x80) != 0) ? Color.Green : Color.White;
                    software_version_tb.Text = $"{array[8]}.{array[9]}.{array[10]}";
                }
            }
        }
    }
}
