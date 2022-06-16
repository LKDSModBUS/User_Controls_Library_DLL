using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LKDS_Type;

namespace DeviceManagerLKDS
{
    public partial class UserControl_PKD_2_16 : UserControl
    {
        public UserControl_PKD_2_16()
        {
            InitializeComponent();
        }
        public void SetData(byte[] array)
        {

            //string str =dlajskldj.GetNameOfEnum();

            if (array.Length >= 32)
            {
                EnumHelper.CAN_Devices type = (EnumHelper.CAN_Devices)array[1];
                EnumHelper.Device_Status status = (EnumHelper.Device_Status)array[0];
                EnumHelper.Key_Format format = (EnumHelper.Key_Format)array[15];
                if (type == EnumHelper.CAN_Devices.ATU)
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
                    out_pb3.BackColor = ((array[7] & 0x04) != 0) ? Color.Green : Color.White;
                    out_pb4.BackColor = ((array[7] & 0x08) != 0) ? Color.Green : Color.White;
                    out_pb5.BackColor = ((array[7] & 0x10) != 0) ? Color.Green : Color.White;
                    out_pb6.BackColor = ((array[7] & 0x20) != 0) ? Color.Green : Color.White;
                    out_pb7.BackColor = ((array[7] & 0x40) != 0) ? Color.Green : Color.White;
                    out_pb8.BackColor = ((array[7] & 0x80) != 0) ? Color.Green : Color.White;
                    out_pb9.BackColor = ((array[6] & 0x01) != 0) ? Color.Green : Color.White;
                    out_pb10.BackColor = ((array[6] & 0x02) != 0) ? Color.Green : Color.White;
                    out_pb11.BackColor = ((array[6] & 0x04) != 0) ? Color.Green : Color.White;
                    out_pb12.BackColor = ((array[6] & 0x08) != 0) ? Color.Green : Color.White;
                    out_pb13.BackColor = ((array[6] & 0x10) != 0) ? Color.Green : Color.White;
                    out_pb14.BackColor = ((array[6] & 0x20) != 0) ? Color.Green : Color.White;
                    out_pb15.BackColor = ((array[6] & 0x40) != 0) ? Color.Green : Color.White;
                    out_pb16.BackColor = ((array[6] & 0x80) != 0) ? Color.Green : Color.White;

                    software_version_tb.Text = $"{array[8]}.{array[9]}.{array[10]}";
                    key_number_tb.Text = $"{array[17].ToString("X2")} {array[18].ToString("X2")} {array[19].ToString("X2")} {array[20].ToString("X2")} {array[21].ToString("X2")} {array[22].ToString("X2")} {array[23].ToString("X2")} {array[24].ToString("X2")} {array[25].ToString("X2")} {array[26].ToString("X2")}";
                }
            }
        }
    }
}
