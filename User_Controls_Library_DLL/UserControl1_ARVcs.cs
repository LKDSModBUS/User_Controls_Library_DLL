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
    public partial class UserControl1_ARVcs : UserControl
    {
        public UserControl1_ARVcs()
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
                if (type == EnumHelper.CAN_Devices.ARV)
                {
                    device_status_tb.Text = status.GetNameOfEnum();
                    device_name_tb.Text = type.GetNameOfEnum();

                    in_1_pb_sk.BackColor = ((array[3] & 0x01) != 0) ? Color.Green : Color.White;
                    in_2_pb_sk.BackColor = ((array[3] & 0x02) != 0) ? Color.Green : Color.White;
                    in_3_pb_sk.BackColor = ((array[3] & 0x04) != 0) ? Color.Green : Color.White;
                    in_4_pb_sk.BackColor = ((array[3] & 0x08) != 0) ? Color.Green : Color.White;
                    in_5_pb_sk.BackColor = ((array[3] & 0x10) != 0) ? Color.Green : Color.White;
                    in_6_pb_sk.BackColor = ((array[3] & 0x020) != 0) ? Color.Green : Color.White;
                    in_7_pb_sk.BackColor = ((array[3] & 0x40) != 0) ? Color.Green : Color.White;
                    in_8_pb_sk.BackColor = ((array[3] & 0x80) != 0) ? Color.Green : Color.White;
               

                    in_1_pb_ts.BackColor = ((array[5] & 0x01) != 0) ? Color.Green : Color.White;
                    in_2_pb_ts.BackColor = ((array[5] & 0x02) != 0) ? Color.Green : Color.White;
                    in_3_pb_ts.BackColor = ((array[5] & 0x04) != 0) ? Color.Green : Color.White;
                    in_4_pb_ts.BackColor = ((array[5] & 0x08) != 0) ? Color.Green : Color.White;
                    in_5_pb_ts.BackColor = ((array[5] & 0x010) != 0) ? Color.Green : Color.White;
                    in_6_pb_ts.BackColor = ((array[5] & 0x020) != 0) ? Color.Green : Color.White;
                    in_7_pb_ts.BackColor = ((array[5] & 0x040) != 0) ? Color.Green : Color.White;
                    in_8_pb_ts.BackColor = ((array[5] & 0x080) != 0) ? Color.Green : Color.White;

                    out_pb1.BackColor = ((array[7] & 0x01) != 0) ? Color.Green : Color.White;
                    out_pb2.BackColor = ((array[7] & 0x02) != 0) ? Color.Green : Color.White;
                    out_pb3.BackColor = ((array[7] & 0x04) != 0) ? Color.Green : Color.White;
                    out_pb4.BackColor = ((array[7] & 0x08) != 0) ? Color.Green : Color.White;
                    out_pb5.BackColor = ((array[7] & 0x10) != 0) ? Color.Green : Color.White;
                    out_pb6.BackColor = ((array[7] & 0x20) != 0) ? Color.Green : Color.White;


                    software_version_tb.Text = $"{array[8]}.{array[9]}.{array[10]}";
                }
            }
        }

      
    }
}
